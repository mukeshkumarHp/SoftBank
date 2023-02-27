using SoftBankApp.Core;
using SoftBankApp.Core.Domains.AccountDomain.Queries;
using SoftBankApp.Core.Models;
using SoftBankApp.Entities;
using SoftBankApp.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace SoftBankApp.Core.Domains.AccountDomain.QueryHandlers
{
    public class GetAccountsForUserIdQueryHandler : IHandleQuery<GetAccountForUserIdQuery, IEnumerable<BankAccountModel>>
    {
        private readonly GenericRepository<BankAccounts> _bankAccountRepository;

        public GetAccountsForUserIdQueryHandler(GenericRepository<BankAccounts> bankAccountRepository)
        {
            _bankAccountRepository = bankAccountRepository;
        }
        public IEnumerable<BankAccountModel> Handle(GetAccountForUserIdQuery query)
        {
            return _bankAccountRepository.GetAll().GroupBy(a => new { a.Id, a.Balance, a.AccountNo, a.UserEntity }).Where(a => a.Key.UserEntity.Id == query.UserId).Select(x => new BankAccountModel
            {
                AccountNo = x.Key.AccountNo,
                Balance = x.Key.Balance,
                Id = x.Key.Id
            });
        }
    }
}
