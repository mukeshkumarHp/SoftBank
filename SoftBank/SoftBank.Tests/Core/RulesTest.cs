using SoftBank.Core.Models.Request;
using SoftBankApp.Core.Domains.BusinessRules;
using SoftBankApp.Core.Utils;
using SoftBankApp.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SoftBankApp.Tests.Core
{
    [TestClass]
    public class RulesTest
    {
        private BankAccounts _bankAccountFrom;
        private MoneyTransferRequest _moneyTransferCommand;

        [TestInitialize]
        public void Init()
        {
            _bankAccountFrom = new BankAccounts
            {
                Balance = 100
            };

            _moneyTransferCommand = new MoneyTransferRequest
            {
                Amount = 120
            };
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessRuleException))]
        public void TransferedAmountShouldntBeLessThanActualBalance()
        {
            BusinessRuleChecker.Handle(new IsTransferedAmountOfMoneyAvailableBusinessRule(_bankAccountFrom, _moneyTransferCommand));
        }
    }
}
