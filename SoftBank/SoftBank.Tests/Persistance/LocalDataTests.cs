using SoftBankApp.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace SoftBankApp.Tests.Entities
{
    [TestClass]
    public class LocalDataTests
    {
        [TestMethod]
        public void UsersFromLocalContextShouldReturnNonEmptyList()
        {
            using (var context = new LocalDataContext())
            {
                var list = context.Users;
                Assert.IsTrue(list.Any());
            }
        }
        [TestMethod]
        public void AccountsFromLocalContextShouldReturnNonEmptyList()
        {
            using (var context = new LocalDataContext())
            {
                var list = context.BankAccounts;
                Assert.IsTrue(list.Any());
            }
        }
        [TestMethod]
        public void NotificationsFromLocalContextShouldReturnEmptyList()
        {
            using (var context = new LocalDataContext())
            {
                var list = context.Notifications;
                Assert.IsTrue(!list.Any());
            }
        }
    }
}
