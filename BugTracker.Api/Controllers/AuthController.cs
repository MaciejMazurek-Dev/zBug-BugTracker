using BugTracker.Application.Contracts.Identity;
using BugTracker.Application.Models.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authenticationService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAuthService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<LoginResponse>> Login(LoginRequest loginRequest)
        {
            LoginResponse response = await _authenticationService.Login(loginRequest);
            if(response.AccessToken == string.Empty)
            {
                return Unauthorized();
            }

            return Ok(response);
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RegisterResponse>> Register(RegisterRequest registerRequest)
        {
            RegisterResponse response = await _authenticationService.Register(registerRequest);
            if(response.UserId == string.Empty)
            {
                return BadRequest();
            }

            return Ok(response);
        }

        [HttpPost("refresh")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<RefreshTokenResponse>> RefreshToken(RefreshTokenRequest request)
        {
            RefreshTokenResponse response = await _authenticationService.RefreshToken(request);
            return Ok(response);
        }
    }
}
