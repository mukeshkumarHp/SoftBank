using SoftBankApp.Core;
using SoftBankApp.Entities;
using SoftBankApp.Repositories;
using Newtonsoft.Json;
using System;

namespace SoftBankApp.Core.Domains.UserDomain.Events
{
    public class UserLogoutEventHandler : IHandleEvent<UserLogoutEvent>
    {
        private readonly GenericRepository<Event> _eventRepository;

        public UserLogoutEventHandler(GenericRepository<Event> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public void Handle(UserLogoutEvent @event)
        {
            var serializedEvent = JsonConvert.SerializeObject(@event);

            _eventRepository.Create(new Event { JSON = serializedEvent });
        }
    }
}
