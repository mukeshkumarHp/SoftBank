using SoftBankApp.Core;
using SoftBankApp.Core.Models;
using SoftBankApp.Core.Services;
using SoftBankApp.Entities;
using System.Linq;
using SoftBankApp.Repositories;
using SoftBankApp.Core.Domains.UserDomain.Queries;

namespace SoftBankApp.Core.Domains.UserDomain.QueryHandlers
{
    public class GetTokenForUserQueryHanlder : IHandleQuery<LoginQuery, JWTModel>
    {
        private readonly JWTTokenService _tokenService;
        private readonly GenericRepository<Users> _loginsRepository;

        public GetTokenForUserQueryHanlder(JWTTokenService tokenService, GenericRepository<Users> loginsRepository)
        {
            _tokenService = tokenService;
            _loginsRepository = loginsRepository;
        }
        public JWTModel Handle(LoginQuery query)
        {
            var userAuthDetails = _loginsRepository.GetAll().FirstOrDefault(x => x.Login == query.Login.ToUpper() && x.Password == query.Password);

            if (userAuthDetails != null)
            {
                return new JWTModel
                {
                    Token = _tokenService.GenerateJWT(query),
                    UserId = userAuthDetails.Id
                };
            }

            return new JWTModel { Token = string.Empty, UserId = -1 };
        }
    }
}
