using SoftBankApp.Core;
using SoftBankApp.Core.Domains.UserDomain.Queries;
using SoftBankApp.Core.Models;
using SoftBankApp.Entities;
using SoftBankApp.Repositories;

namespace SoftBankApp.Core.Domains.UserDomain.QueryHandlers
{
    public class GetUserDetailsQueryHandler : IHandleQuery<GetUserDetailsQuery, UserDetailsModel>
    {
        private readonly GenericRepository<Users> _loginsRepository;

        public GetUserDetailsQueryHandler(GenericRepository<Users> loginsRepository)
        {
            _loginsRepository = loginsRepository;
        }
        public UserDetailsModel Handle(GetUserDetailsQuery query)
        {
            var user = _loginsRepository.GetById(query.UserId);
            return new UserDetailsModel { Login = user.Login };
        }
    }
}
