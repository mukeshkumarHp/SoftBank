namespace SoftBankApp.Core
{
    public interface IEventsBus
    {
        void Publish<TEvent>(TEvent @event) where TEvent : IEvent;
    }
}
