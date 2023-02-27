using SoftBankApp.Core;
using System.ComponentModel.DataAnnotations;

namespace SoftBankApp.Core.Domains.UserDomain.Commands
{
    public class UserLogoutCommand : ICommand
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public string Key { get; set; }
    }
}
