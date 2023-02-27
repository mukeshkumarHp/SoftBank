using SoftBank.Core.Models.Request;

namespace SoftBank.Core.IServices
{
    public interface IEventService
    {
        void Create(TransferredRequest @event);
    }
}
