using System;
using System.Linq;
using System.Collections.Generic;

namespace SoftBankApp.Entities
{
    public class LocalDataContext : IDisposable
    {
        public IEnumerable<Users> Users { set; get; }
        public IEnumerable<BankAccounts> BankAccounts { set; get; }
        public IEnumerable<Notifications> Notifications { set; get; }
        public IEnumerable<InvalidKeys> InvalidKeys { set; get; }
        public IEnumerable<Event> Events { set; get; }

        public LocalDataContext()
        {
            LocalData();
        }

        private void LocalData()
        {
            Users = new List<Users>
            {
                new Users
                {
                    Id= 1,
                    BankAccounts = null,
                    Login = "mukesh".ToUpper(),
                    PreDefinedAccounts = new List<BankAccounts>()
                },
                new Users
                {
                    Id= 2,
                    BankAccounts = null,
                    Login = "anmol".ToUpper(),
                    PreDefinedAccounts = new List<BankAccounts>()
                }
            };


            BankAccounts = new List<BankAccounts>
            {  
                new BankAccounts
                {
                    Id = 1,
                    AccountNo = "SBI012121020101",
                    Balance = 500,
                    UserEntity = Users.FirstOrDefault(x=>x.Login == "mukesh".ToUpper())
                },
                new BankAccounts
                {
                    Id = 2,
                    AccountNo = "SBI012121020102",
                    Balance = 655,
                    UserEntity = Users.FirstOrDefault(x=>x.Login == "mukesh".ToUpper())
                },
                new BankAccounts
                {
                    Id = 3,
                    AccountNo = "SBI012121020103",
                    Balance = 1000,
                    UserEntity = Users.FirstOrDefault(x=>x.Login == "anmol".ToUpper())
                }
               
            };

            Users.FirstOrDefault(x => x.Login == "mukesh".ToUpper()).PreDefinedAccounts.Add(
               BankAccounts.FirstOrDefault(x => x.Id == 2)
                );

            Users.FirstOrDefault(x => x.Login == "anmol".ToUpper()).PreDefinedAccounts.Add(
               BankAccounts.FirstOrDefault(x => x.Id == 3)
                );


            Notifications = new List<Notifications>();
            InvalidKeys = new List<InvalidKeys>();
            Events = new List<Event>();
        }

        public void Dispose()
        {
        }
    }
}
