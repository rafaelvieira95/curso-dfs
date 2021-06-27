using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using ECommerce.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ECommerce.Util
{
    public static class CryptoFunction
    {

        public static string GenerateToken(IConfiguration configuration)
        {
            var key = Encoding.UTF8.GetBytes(configuration["SecurityKey"]);
            var symmetricSecurityKey = new SymmetricSecurityKey(key);
            var credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

           var tokenExpireTimeLapse = int.Parse(configuration["TokenExpireTimeLapse"]);
            var token = new JwtSecurityToken(
                issuer: configuration["Issuer"],
                audience: configuration["Audience"],
                expires: DateTime.Now.AddMinutes(tokenExpireTimeLapse),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}