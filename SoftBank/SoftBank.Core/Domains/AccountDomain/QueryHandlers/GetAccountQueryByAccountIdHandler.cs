using SoftBankApp.Core;
using SoftBankApp.Core.Domains.AccountDomain.Queries;
using SoftBankApp.Entities;
using SoftBankApp.Repositories;

namespace SoftBankApp.Core.Domains.AccountDomain.QueryHandlers
{
    public class GetAccountQueryByAccountIdHandler : IHandleQuery<GetAccountQueryById, BankAccounts>
    {
        private GenericRepository<BankAccounts> _accounts;

        public GetAccountQueryByAccountIdHandler(GenericRepository<BankAccounts> accounts)
        {
            _accounts = accounts;
        }
        public BankAccounts Handle(GetAccountQueryById query)
        {
            return _accounts.GetById(query.AccountId);
        }
    }
}
