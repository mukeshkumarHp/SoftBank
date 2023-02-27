using SoftBank.Core.Models.Request;
using SoftBankApp.Entities;

namespace SoftBankApp.Core.Domains.BusinessRules
{
    public class IsTransferedAmountOfMoneyAvailableBusinessRule : IBusinessRule
    {
        private BankAccounts _bankAccountFrom;
        private MoneyTransferRequest _moneyTransferRequest;

        public string ErrorMessage => "Not sufficient amount of money on your account.";

        public IsTransferedAmountOfMoneyAvailableBusinessRule(BankAccounts bankAccountFrom, MoneyTransferRequest request)
        {
            this._bankAccountFrom = bankAccountFrom;
            this._moneyTransferRequest = request;
        }

        public bool IsValid()
        {
            return (_bankAccountFrom.Balance > 0 && _bankAccountFrom.Balance > _moneyTransferRequest.Amount);
        }
    }
}
