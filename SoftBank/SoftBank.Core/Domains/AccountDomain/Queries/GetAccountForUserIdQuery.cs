using SoftBankApp.Core;
using System.ComponentModel.DataAnnotations;

namespace SoftBankApp.Core.Domains.AccountDomain.Queries
{
    public class GetAccountForUserIdQuery: IQuery
    {
        [Required]
        public int UserId { get; set; }
    }
}
