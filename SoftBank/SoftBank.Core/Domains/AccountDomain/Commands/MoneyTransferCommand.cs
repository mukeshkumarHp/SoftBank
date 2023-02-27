using SoftBankApp.Core;
using System.ComponentModel.DataAnnotations;

namespace SoftBankApp.Core.Domains.AccountDomain.Commands
{
    public class MoneyTransferRequest
    {
        [Required]
        public int ReceiverAccountId { get; set; }

        [Required]
        public int SenderAccountId { get; set; }

        [Required]
        public decimal Amount { get; set; }
    }
}