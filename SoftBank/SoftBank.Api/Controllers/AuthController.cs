using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoftBank.Core;
using Microsoft.Extensions.Options;

namespace SoftBankApp.Api.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly AppSettings _appSettings;
        public AuthController(IUserService userService, IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _appSettings = appSettings.Value;
        }

        [HttpPost("Login")]
        public IActionResult Login(AuthenticateRequest login)
        {
            var user = _userService.Validate(login);

            if (user == null) { return Unauthorized(); }

            JWTTokenHelper jWTTokenHelper = new JWTTokenHelper(_appSettings);
            jWTTokenHelper.GenerateJwtToken(user);
            return Ok(jWTTokenHelper.GenerateJwtToken(user));
        }

        [HttpPost("Logout")]
        public IActionResult Logout(object logout)
        {
            return Ok();
        }
    }
}