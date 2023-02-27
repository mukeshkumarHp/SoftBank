using SoftBankApp.Core;
using SoftBankApp.Core.Domains.UserDomain.Commands;
using SoftBankApp.Core.Domains.UserDomain.Events;
using SoftBankApp.Entities;
using SoftBankApp.Repositories;
using System.Linq;

namespace SoftBankApp.Core.Domains.UserDomain.CommandHandlers
{
    public class UserLogoutCommandHandler : IHandleCommand<UserLogoutCommand>
    {
        private readonly IEventsBus _eventBus;
        private readonly GenericRepository<InvalidKeys> _invalidKeysRepository;

        public UserLogoutCommandHandler(IEventsBus eventBus, GenericRepository<InvalidKeys> invalidKeysRepository)
        {
            _eventBus = eventBus;
            _invalidKeysRepository = invalidKeysRepository;
        }

        public void Handle(UserLogoutCommand command)
        {
            var invalidKey = new InvalidKeys
            {
                Key = command.Key,
                UserId = command.UserId
            };

            _invalidKeysRepository.Create(invalidKey);

            _eventBus.Publish(new UserLogoutEvent { UserId = command.UserId });
        }
    }
}
