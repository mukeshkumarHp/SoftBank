using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftBankApp.Core
{
    public class EventsBus : IEventsBus
    {
        private readonly Func<Type, IEnumerable<IHandleEvent>> _handlersFactory;
        public EventsBus(Func<Type, IEnumerable<IHandleEvent>> handlersFactory)
        {
            _handlersFactory = handlersFactory;
        }

        public void Publish<TEvent>(TEvent @event) where TEvent : IEvent
        {
            
            var handlers = _handlersFactory(typeof(TEvent));
            foreach (IHandleEvent<TEvent> handler in handlers)
            {
                handler.Handle(@event);
            }
        }
    }
}
