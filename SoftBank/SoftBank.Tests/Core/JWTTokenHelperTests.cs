using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoftBank.Core;
using SoftBankApp.Entities;

using System;

namespace SoftBankApp.Tests.Core
{
    [TestClass]
    public class JWTTokenServiceTest
    {
        private IConfiguration _configuration;
        private JWTTokenHelper _jWTTokenHelper;
        private Users _user;

        [TestInitialize]
        public void Init()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
               .AddJsonFile("appsettings.json")
                .Build();

            _jWTTokenHelper = new JWTTokenHelper(new AppSettings()
            {
                Secret = _configuration["AppSettings:Secret"],
                TokenValidityInMinutes = Convert.ToInt32(_configuration["AppSettings:TokenValidityInMinutes"]),
                ValidIssuer = _configuration["AppSettings:ValidIssuer"],
                ValidAudience = _configuration["AppSettings:ValidAudience"],
                RefreshTokenValidityInDays = Convert.ToInt32(_configuration["AppSettings:RefreshTokenValidityInDays"])
            });
            _user = new Users
            {
                Login = "mukesh".ToUpper()
            };
        }

        [TestMethod]
        public void ReturnNonEmptyTokenForUser()
        {
            var token = _jWTTokenHelper.GenerateJwtToken(_user);
            Assert.IsTrue(!string.IsNullOrWhiteSpace(token));
        }
    }
}
