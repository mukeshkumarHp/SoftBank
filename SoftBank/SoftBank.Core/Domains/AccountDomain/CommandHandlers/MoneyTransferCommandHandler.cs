using SoftBankApp.Core;
using SoftBankApp.Core.Domains.AccountDomain.Commands;
using SoftBankApp.Core.Domains.AccountDomain.Events;
using SoftBankApp.Core.Domains.BusinessRules;
using SoftBankApp.Core.Utils.Enums;
using SoftBankApp.Entities;
using SoftBankApp.Repositories;

namespace SoftBankApp.Core.Domains.AccountDomain.CommandHandlers
{
    public class MoneyTransferCommandHandler : IHandleCommand<MoneyTransferCommand>
    {
        private readonly GenericRepository<BankAccounts> _bankAccountRepository;
        private readonly IEventsBus _eventBus;

        public MoneyTransferCommandHandler(GenericRepository<BankAccounts> bankAccountRepository,IEventsBus eventBus)
        {
            _bankAccountRepository = bankAccountRepository;
            _eventBus = eventBus;
        }
        public void Handle(MoneyTransferCommand command)
        {
            var bankAccountFrom = _bankAccountRepository.GetById(command.SenderAccountId);

            BusinessRuleChecker.Handle(new IsTransferedAmountOfMoneyAvailableBusinessRule(bankAccountFrom, command));

            bankAccountFrom.Balance -= command.Amount;

            _bankAccountRepository.Update(bankAccountFrom);
            _eventBus.Publish(new MoneyTransferedEvent(command.SenderAccountId,command.Amount,TransferMoneyStatus.SEND));

            var bankAccountTo = _bankAccountRepository.GetById(command.ReceiverAccountId);
            bankAccountTo.Balance += command.Amount;

            _bankAccountRepository.Update(bankAccountTo);
            _eventBus.Publish(new MoneyTransferedEvent(command.ReceiverAccountId, command.Amount, TransferMoneyStatus.RECEIVE));
        }
    }
}
