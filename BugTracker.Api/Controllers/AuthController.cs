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

        public AuthController(IAuthService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login(LoginRequest loginRequest)
        {
            LoginResponse response = await _authenticationService.Login(loginRequest);
            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegisterResponse>> Register(RegisterRequest registerRequest)
        {
            RegisterResponse response = await _authenticationService.Register(registerRequest);
            return Ok(response);
        }
    }
}
