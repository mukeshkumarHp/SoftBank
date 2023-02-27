using SoftBankApp.Core.Utils.Enums;

namespace SoftBank.Core.Models.Request
{
    public class TransferredRequest
    {
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public TransferMoneyStatus Status { get; set; }

        public TransferredRequest(int accountId, decimal amount, TransferMoneyStatus status)
        {
            AccountId = accountId;
            Amount = amount;
            Status = status;
        }
    }
}
