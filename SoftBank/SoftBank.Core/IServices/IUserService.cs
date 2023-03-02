using SoftBank.Core.Models;
using SoftBankApp.Entities;
using SoftBankApp.Repositories;

namespace SoftBank.Core
{
    public interface IUserService 
    {
        Users Validate(AuthenticateRequest login);
        Users GetById(int userId);
    }
}
