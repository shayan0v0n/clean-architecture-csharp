using CleanArchitectureTemplate.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CleanArchitectureTemplate.Shared.Security.JwtToken
{
    public static partial class Token
    {
        public static string GenerateToken(User user, int duration = 6)
        {

            var claims = new[]
            {
                new Claim("UserId", user.Id),
                new Claim("UserName", user.Id),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("In%The^Name(Of*God$In(the$name!ofـthe«great:benefactor"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(duration),
                signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
