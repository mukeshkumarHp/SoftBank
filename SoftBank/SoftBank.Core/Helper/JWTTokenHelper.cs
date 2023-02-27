using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SoftBankApp.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SoftBank.Core
{
    public class JWTTokenHelper
    {
        private readonly AppSettings _appSettings;

        public JWTTokenHelper(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public JWTTokenHelper(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        public string GenerateJwtToken(Users user)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.Secret));
#pragma warning restore CS8604 // Possible null reference argument.
            _ = int.TryParse(_appSettings.TokenValidityInMinutes.ToString(), out int tokenValidityInMinutes);

            var authClaims = new List<Claim>
                {
                    new Claim("id", user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

            var token = new JwtSecurityToken(
                issuer: _appSettings.ValidIssuer,
                audience: _appSettings.ValidAudience,
                expires: DateTime.Now.AddMinutes(tokenValidityInMinutes),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
