using AutoMapper;
using SoftBank.Core.Models;
using SoftBankApp.Entities;
using SoftBankApp.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftBank.Core
{
    public class UserService : IUserService
    {
        //private readonly LocalDataContext _db;
        private readonly GenericRepository<Users> _genericRepository;
        private readonly IMapper _mapper;
        public UserService(LocalDataContext db, IMapper mapper, GenericRepository<Users> genericRepository)
        {
           // _db = db;
            _mapper = mapper;
            _genericRepository = genericRepository;
        }

        public void Create(Users entity, bool isUpdate = false)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Users> GetAllUsers()
        {
            return _genericRepository.GetAll().ToList();
        }

        public Users GetById(int id)
        {
            return _genericRepository.GetById(id);
        }

        public void Update(Users entity)
        {
            throw new NotImplementedException();
        }

        public Users Validate(AuthenticateRequest login)
        {
            return _genericRepository.GetAll().FirstOrDefault(x => x.Login?.ToUpper() == login?.UserName?.ToUpper() && x.Password == login.Password);
        }
    }
}
