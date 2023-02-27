using Autofac;
using SoftBankApp.Core;
using SoftBankApp.Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using SoftBank.Core.Models.Request;
using SoftBank.Core.IServices;

namespace SoftBankApp.Tests.Core
{
    [TestClass]
    public class NotificationEventHandlerTests
    {
        private IContainer _container;
        private MoneyTransferRequest _moneyTransfer;
        private GetNotificationForUserIdQuery _notificationQuery;

        [TestInitialize]
        public void Init()
        {

            var assembly = typeof(ICoreAssemblyMarker).Assembly;
            var builder = new ContainerBuilder();

            //Initialize all autofac modules in assembly
            builder.RegisterAssemblyModules(assembly);
            _container = builder.Build();

            _moneyTransfer = new MoneyTransferRequest
            {
                Amount = 100,
                ReceiverAccountId = 1,
                SenderAccountId = 2
            };

            _notificationQuery = new GetNotificationForUserIdQuery
            {
                UserId = 1
            };
        }

        [TestMethod]
        public void CheckNotificationsDuringTransferBetweenTwoAccounts()
        {
            var notificationsCounterBeforeTransfer = _container
                .Resolve<IQueryBus>()
                .Send<GetNotificationForUserIdQuery, IEnumerable<NotificationModel>>(_notificationQuery)
                .Count();

            _container.Resolve<IMoneyTransferService>().Send(_moneyTransfer);

            var notificationsCounterAfterTransfer = _container
                .Resolve<IQueryBus>()
                .Send<GetNotificationForUserIdQuery, IEnumerable<NotificationModel>>(_notificationQuery)
                .Count();

            Assert.AreNotEqual(notificationsCounterBeforeTransfer, notificationsCounterAfterTransfer);
        }
    }
}
