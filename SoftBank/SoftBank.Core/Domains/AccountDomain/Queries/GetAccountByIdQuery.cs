using SoftBankApp.Core;
using System.ComponentModel.DataAnnotations;

namespace SoftBankApp.Core.Domains.AccountDomain.Queries
{
    public class GetAccountQueryById : IQuery
    {
        [Required]
        public int AccountId { get; set; }
    }
}
