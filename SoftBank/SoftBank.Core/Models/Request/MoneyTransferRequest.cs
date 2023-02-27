using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftBank.Core.Models.Request
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
