using SoftBankApp.Core;
using SoftBankApp.Core.Domains.UserDomain.Events;
using SoftBankApp.Entities;
using SoftBankApp.Repositories;

namespace SoftBankApp.Core.Domains.AccountDomain.Events
{
    public class NotificationEventHandler : IHandleEvent<MoneyTransferedEventRequest>, IHandleEvent<UserLogoutEvent>
    {
        private readonly GenericRepository<Notifications> _notificationRepository;
        private readonly GenericRepository<Users> _loginRepository;

        public NotificationEventHandler(GenericRepository<Notifications> notificationRepository, GenericRepository<Users> loginRepository)
        {
            _notificationRepository = notificationRepository;
            _loginRepository = loginRepository;
        }
        public void Handle(MoneyTransferedEventRequest @event)
        {
            var notification = new Notifications {
                IsDisplayed = false,
                Login = _loginRepository.GetById(@event.AccountId),
                Message = string.Format($"{@event.Amount} transfered: {@event.OccurredOn}.")
            };
            _notificationRepository.Create(notification);
        }

        public void Handle(UserLogoutEvent @event)
        {
            var notification = new Notifications
            {
                IsDisplayed = false,
                Login = _loginRepository.GetById(@event.UserId),
                Message = string.Format($"User logout: {@event.OccurredOn}.")
            };
            _notificationRepository.Create(notification);
        }
    }
}
