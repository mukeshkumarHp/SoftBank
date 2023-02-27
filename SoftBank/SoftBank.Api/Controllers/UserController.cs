using SoftBankApp.Core;
using Microsoft.AspNetCore.Mvc;
using SoftBank.Core;
using System;

namespace SoftBankApp.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet("Details")]
        public IActionResult GetUserDetails(int UserId)
        {
            try
            {
                var userDetailsQuery = _userService.GetUserById(UserId);
                return Ok(userDetailsQuery);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}