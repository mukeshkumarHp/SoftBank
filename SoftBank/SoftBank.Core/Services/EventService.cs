using Newtonsoft.Json;
using SoftBank.Core.IServices;
using SoftBank.Core.Models.Request;
using SoftBankApp.Entities;
using SoftBankApp.Repositories;

namespace SoftBank.Core.Services
{
    public class EventService : IEventService
    {
        private readonly GenericRepository<Event> _eventRepository;

        public EventService(GenericRepository<Event> eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public void Create(TransferredRequest request)
        {
            var serializedEvent = JsonConvert.SerializeObject(request);
            _eventRepository.Create(new Event { JSON = serializedEvent });
        }
    }
}