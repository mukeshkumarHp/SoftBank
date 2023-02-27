using AutoMapper;
using SoftBankApp.Entities;
using SoftBank.Core.Models;

namespace SoftBank.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
           CreateMap<Users, UserViewModel>().ReverseMap();
           CreateMap<BankAccounts, BankAccountViewModel>().ReverseMap();
        }
    }
}