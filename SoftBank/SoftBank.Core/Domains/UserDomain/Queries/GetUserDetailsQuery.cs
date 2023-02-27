using SoftBankApp.Core;
using System.ComponentModel.DataAnnotations;

namespace SoftBankApp.Core.Domains.UserDomain.Queries
{
    public class GetUserDetailsQuery : IQuery
    {
        [Required]
        public int UserId { get; set; }
    }
}
