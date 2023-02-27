using SoftBankApp.Core;
using System.ComponentModel.DataAnnotations;

namespace SoftBankApp.Core.Domains.UserDomain.Queries
{
    public class GetNotificationForUserIdQuery : IQuery
    {
        [Required]
        public int UserId { get; set; }
    }
}
