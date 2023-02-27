using System.Collections.Generic;

namespace SoftBank.Core.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public virtual List<BankAccountViewModel> BankAccounts { get; set; }
        public virtual List<BankAccountViewModel> PreDefinedAccounts { get; set; }
    }
}
