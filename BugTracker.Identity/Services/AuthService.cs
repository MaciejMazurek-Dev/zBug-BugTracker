using BugTracker.Application.Contracts.Identity;
using BugTracker.Application.Exceptions;
using BugTracker.Application.Models.Identity;
using BugTracker.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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

            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);
            string jwtToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            loginResponse.Token = jwtToken;
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

        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
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
                expires: DateTime.Now.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }
    }
}
