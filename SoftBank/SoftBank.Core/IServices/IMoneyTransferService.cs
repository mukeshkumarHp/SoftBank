using SoftBank.Core.Models.Request;

namespace SoftBank.Core.IServices
{
    public interface IMoneyTransferService
    {
        void Send(MoneyTransferRequest command);
    }
}