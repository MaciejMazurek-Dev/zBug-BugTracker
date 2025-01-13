using BugTracker.Application.Contracts.Identity;
using BugTracker.Application.Exceptions;
using BugTracker.Application.Models.Identity;
using BugTracker.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BugTracker.Identity.Services
{
    public class AuthService : IAuthService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtSettings _jwtSettings;

        public AuthService(
            SignInManager<ApplicationUser> signInManager, 
            UserManager<ApplicationUser> userManager, 
            IOptions<JwtSettings> jwtSettings )
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
        }


        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            LoginResponse loginResponse = new LoginResponse();

            var user = await _userManager.FindByEmailAsync(loginRequest.Email);
            if (user == null)
            {
                return loginResponse;
            }

            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, loginRequest.Password, false);
            if (signInResult.Succeeded == false)
            {
                return loginResponse;
            }

            JwtSecurityToken jwtSecurityToken = await GenerateAccessToken(user);
            string jwtToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            loginResponse.AccessToken = jwtToken;

            string refreshToken = await GenerateRefreshToken(user);
            loginResponse.RefreshToken = refreshToken;

            return loginResponse;
        }


        public async Task<RegisterResponse> Register(RegisterRequest registrationRequest)
        {
            RegisterResponse registerResponse = new RegisterResponse();

            var user = new ApplicationUser
            {
                UserName = registrationRequest.Email,
                Email = registrationRequest.Email,
                FirstName = registrationRequest.FirstName,
                LastName = registrationRequest.LastName,
                
            };

            var result = await _userManager.CreateAsync(user, registrationRequest.Password);
            if(result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
                registerResponse.UserId = user.Id;
                return registerResponse;
            }
            else
            {
                return registerResponse;
            }
        }


        public async Task<RefreshTokenResponse> RefreshToken(RefreshTokenRequest refreshTokenRequest)
        {
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateLifetime = false,
                ValidateAudience = true,
                ValidIssuer = _jwtSettings.Issuer,
                ValidAudience = _jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key)),
            };
            var claimsPrincipal = new JwtSecurityTokenHandler().ValidateToken(
                refreshTokenRequest.AccessToken, 
                validationParameters, 
                out _);
            var userName = claimsPrincipal.Claims.SingleOrDefault(u => u.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;
            var user = await _userManager.FindByNameAsync(userName);
            if(user == null 
                || user.RefreshToken != refreshTokenRequest.RefreshToken
                || user.RefreshTokenExpires < DateTime.UtcNow)
            {
                return new RefreshTokenResponse();
            }

            JwtSecurityToken jwtSecurityToken = await GenerateAccessToken(user);
            string accessToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            var refreshToken = await GenerateRefreshToken(user);

            var result = new RefreshTokenResponse
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };

            return result;
        }


        private async Task<JwtSecurityToken> GenerateAccessToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var userRoles = roles.Select(r => new Claim(ClaimTypes.Role, r)).ToList();

            var tokenClaims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(userRoles);
            
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: tokenClaims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.AccessTokenDurationInMinutes),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }


        private async Task<string> GenerateRefreshToken(ApplicationUser user)
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            string refreshToken = Convert.ToBase64String(randomNumber);

            user.RefreshToken = refreshToken;
            user.RefreshTokenCreated = DateTime.UtcNow;
            user.RefreshTokenExpires = DateTime.UtcNow.AddHours(_jwtSettings.RefreshTokenDurationInHours);

            IdentityResult identityResult = await _userManager.UpdateAsync(user);
            if(identityResult.Succeeded)
            {
                return refreshToken;
            }
            return string.Empty;
        }
    }
}
