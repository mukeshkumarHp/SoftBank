using Microsoft.AspNetCore.Mvc;
using SoftBank.Core;
using SoftBank.Core.IServices;
using SoftBank.Core.Models.Request;
using AuthorizeAttribute = SoftBank.Core.AuthorizeAttribute;

namespace SoftBankApp.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("customer/[controller]")]
    public class BankAccountController : ControllerBase
    {
        private readonly IMoneyTransferService _moneyTransferService;
        private readonly IUserService _userService;

        public BankAccountController(IUserService userService, IMoneyTransferService moneyTransferService)
        {
            _userService = userService;
            _moneyTransferService = moneyTransferService;
        }

        [HttpPost("{userId}/Accounts")]
        public IActionResult GetAccountsForUser(int userId)
        {
            var user = _moneyTransferService.GetAccountForUser(userId);
            return Ok(user);
        }

        [HttpPost("TransferMoney")]
        public IActionResult TransferMoney(MoneyTransferRequest moneyTransfer)
        {
            _moneyTransferService.Send(moneyTransfer);
            return Ok();
        }
    }
}