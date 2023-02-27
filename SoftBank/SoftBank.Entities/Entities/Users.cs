using System.Collections.Generic;

namespace SoftBankApp.Entities
{
    public class Users : IEntity
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password => "admin123";
        public virtual List<BankAccounts> BankAccounts { get; set; }
        public virtual List<BankAccounts> PreDefinedAccounts { get; set; }
    }
}