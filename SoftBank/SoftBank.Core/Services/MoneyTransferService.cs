using SoftBank.Core.IServices;
using SoftBank.Core.Models.Request;
using SoftBankApp.Core.Domains.BusinessRules;
using SoftBankApp.Core.Utils.Enums;
using SoftBankApp.Entities;
using SoftBankApp.Repositories;

using MoneyTransferedEventRequest = SoftBank.Core.Models.Request.TransferredRequest;

namespace SoftBank.Core.Services
{
    public class MoneyTransferService : IMoneyTransferService
    {
        private readonly GenericRepository<BankAccounts> _bankAccountRepository;
        private readonly IEventService _moneyTransferEventService;
        public MoneyTransferService(GenericRepository<BankAccounts> bankAccountRepository, IEventService moneyTransferEventService)
        {
            _bankAccountRepository = bankAccountRepository;
            _moneyTransferEventService = moneyTransferEventService;
        }
        public void Send(MoneyTransferRequest request)
        {
            var bankAccountFrom = _bankAccountRepository.GetById(request.SenderAccountId);
            BusinessRuleChecker.Handle(new IsTransferedAmountOfMoneyAvailableBusinessRule(bankAccountFrom, request));
            bankAccountFrom.Balance -= request.Amount;
            _bankAccountRepository.Update(bankAccountFrom);
            _moneyTransferEventService.Create(new MoneyTransferedEventRequest(request.SenderAccountId, request.Amount, TransferMoneyStatus.Send));

            var bankAccountTo = _bankAccountRepository.GetById(request.ReceiverAccountId);
            bankAccountTo.Balance += request.Amount;
            _bankAccountRepository.Update(bankAccountTo);
            _moneyTransferEventService.Create(new MoneyTransferedEventRequest(request.ReceiverAccountId, request.Amount, TransferMoneyStatus.Receive));
        }
    }
}