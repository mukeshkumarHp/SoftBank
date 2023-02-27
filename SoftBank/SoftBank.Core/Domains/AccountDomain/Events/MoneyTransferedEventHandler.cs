using SoftBankApp.Core;
using SoftBankApp.Entities;
using SoftBankApp.Repositories;
using Newtonsoft.Json;

namespace SoftBankApp.Core.Domains.AccountDomain.Events
{
    public class MoneyTransferedEventHandler : IHandleEvent<MoneyTransferedEventRequest>
    {
        private readonly GenericRepository<Event> _eventRepository;

        public MoneyTransferedEventHandler(GenericRepository<Event> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public void Handle(MoneyTransferedEventRequest @event)
        {
            var serializedEvent = JsonConvert.SerializeObject(@event);

            _eventRepository.Create(new Event { JSON = serializedEvent});
        }
    }
}
