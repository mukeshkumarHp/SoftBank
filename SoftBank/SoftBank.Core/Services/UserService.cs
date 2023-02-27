using AutoMapper;
using SoftBank.Core.Models;
using SoftBankApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftBank.Core
{
    public class UserService : IUserService
    {
        private readonly LocalDataContext _db;

        private readonly IMapper _mapper;
        public UserService(LocalDataContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public void Create(Users entity, bool isUpdate = false)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Users> GetAll()
        {
           return _db.Users.ToList();
        }
        public Users GetUserById(int id)
        {
            try
            {
                var user = GetById(id);
                return user;
            }
            catch (Exception ex)
            {
                return new Users();
            }

        }
        public Users GetById(int id)
        {
            return _db.Users.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Users entity)
        {
            throw new NotImplementedException();
        }

        public Users Validate(AuthenticateRequest login)
        {
            return _db.Users.FirstOrDefault(x => x.Login?.ToUpper() == login?.UserName?.ToUpper() && x.Password == login.Password);
        }
    }
}
