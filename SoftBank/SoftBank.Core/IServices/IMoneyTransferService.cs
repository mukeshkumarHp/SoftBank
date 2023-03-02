using SoftBank.Core.Models.Request;

using SoftBankApp.Core.Models;
using SoftBankApp.Entities;

using System.Collections.Generic;

namespace SoftBank.Core.IServices
{
    public interface IMoneyTransferService
    {
        void Send(MoneyTransferRequest command);
        IEnumerable<BankAccountModel> GetAccountForUser(int userId);
    }
}