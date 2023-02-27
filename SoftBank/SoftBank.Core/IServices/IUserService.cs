using SoftBank.Core.Models;
using SoftBankApp.Entities;
using SoftBankApp.Repositories;

namespace SoftBank.Core
{
    public interface IUserService : IGenericRepository<Users>
    {
        Users Validate(AuthenticateRequest login);
        Users GetUserById(int id);
    }
}
