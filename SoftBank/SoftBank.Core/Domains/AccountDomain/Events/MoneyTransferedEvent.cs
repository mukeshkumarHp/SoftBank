using SoftBankApp.Core.Utils.Enums;

namespace SoftBankApp.Core.Domains.AccountDomain.Events
{
    public class MoneyTransferedEventRequest
    {
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public TransferMoneyStatus Status { get; set; }

        public MoneyTransferedEventRequest(int accountId, decimal amount, TransferMoneyStatus status)
        {
            AccountId = accountId;
            Amount = amount;
            Status = status;
        }

    }
}
