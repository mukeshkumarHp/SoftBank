using Autofac;
using SoftBankApp.Core;
using SoftBankApp.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoftBank.Core.Models.Request;
using SoftBank.Core.IServices;
using SoftBankApp.Repositories;
using SoftBank.Core.Services;

namespace SoftBankApp.Tests.Core
{
    [TestClass]
    public class TransferMoneyTests
    {
        private MoneyTransferRequest _moneyTransfer;
        private int _senderBankAccount;
        private int _receiverBankAccount;
        private IMoneyTransferService _moneyTransferService;
        private GenericRepository<BankAccounts> _bankAccountRepository;
        private IEventService _eventService;
        private GenericRepository<Event> _eventRepository;
        [TestInitialize]
        public void Init()
        {

            var assembly = typeof(ICoreAssemblyMarker).Assembly;
            var builder = new ContainerBuilder();

            //Initialize all autofac modules in assembly
            builder.RegisterAssemblyModules(assembly);
            _eventRepository = new GenericRepository<Event>();
            _eventService = new EventService(_eventRepository);
            _bankAccountRepository = new GenericRepository<BankAccounts>();
            _moneyTransferService = new MoneyTransferService(_bankAccountRepository, _eventService);
            _moneyTransfer = new MoneyTransferRequest
            {
                Amount = 100,
                ReceiverAccountId = 1,
                SenderAccountId = 2
            };

            _senderBankAccount = 1;

            _receiverBankAccount = 2;
        }

        [TestMethod]
        public void CheckTransferBetweenTwoAccounts()
        {
            var senderBalance = _bankAccountRepository.GetById(_senderBankAccount)?.Balance;
            var receiverBalance = _bankAccountRepository.GetById(_receiverBankAccount)?.Balance;
            _moneyTransferService.Send(_moneyTransfer);

            var senderBalanceAfterTransfer = _bankAccountRepository.GetById(_senderBankAccount)?.Balance;
            var receiverBalanceAfterTransfer = _bankAccountRepository.GetById(_receiverBankAccount)?.Balance;

            Assert.AreEqual(senderBalance, senderBalanceAfterTransfer - _moneyTransfer.Amount);
            Assert.AreEqual(receiverBalance, receiverBalanceAfterTransfer + _moneyTransfer.Amount);

        }
    }
}
