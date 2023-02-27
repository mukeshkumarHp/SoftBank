using Autofac;
using SoftBankApp.Core;
using SoftBankApp.Core.Models;
using SoftBankApp.Entities;
using SoftBankApp.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using SoftBank.Core;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using System.Runtime;
using System;

namespace SoftBankApp.Tests.Core
{
    [TestClass]
    public class AuthenticationTests
    {
        private IConfiguration _configuration;
        private Users _user;
        private Users _wrongLoginModel;
        private JWTTokenHelper jwtTokenHelper;
        private IUserService _userService;

        [TestInitialize]
        public void Init()
        {
            var assembly = typeof(ICoreAssemblyMarker).Assembly;
            _configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
               .AddJsonFile("appsettings.json")
                .Build();

            jwtTokenHelper = new JWTTokenHelper(new AppSettings()
            {
                Secret = _configuration["AppSettings:Secret"],
                TokenValidityInMinutes = Convert.ToInt32(_configuration["AppSettings:TokenValidityInMinutes"]),
                ValidIssuer = _configuration["AppSettings:ValidIssuer"],
                ValidAudience = _configuration["AppSettings:ValidAudience"],
                RefreshTokenValidityInDays = Convert.ToInt32(_configuration["AppSettings:RefreshTokenValidityInDays"])
            });

            //Init user login model
            _user = new Users
            {
                Login = "mukesh".ToUpper()
            };
        }

        [TestMethod]
        public void QueryHandlerShouldBeAbleToAuthenticateUser()
        {
            var token = jwtTokenHelper.GenerateJwtToken(_user);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(token));
        }

        [TestMethod]
        public void UserShouldGetUniqueTokenAfterLogin()
        {
            var tokenAfterFirstLogin = jwtTokenHelper.GenerateJwtToken(_user);
            var tokenAfterSecondLogin = jwtTokenHelper.GenerateJwtToken(_user);

            Assert.AreNotEqual(tokenAfterFirstLogin, tokenAfterSecondLogin);
        }
    }
}
