using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace CleanArchitectureTemplate.Shared.Security.JwtToken
{
    public static class ValidateToken
    {
        public static ClaimsPrincipal GetValidToken(string token)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            ClaimsPrincipal principal;
            bool canRead = tokenHandler.CanReadToken(token);
            if (canRead)
            {
                var security = tokenHandler.ReadToken(token);

                TokenValidationParameters parameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("In%The^Name(Of*God$In(the$name!ofـthe«great:benefactor"))
                };

                if (security.ValidTo >= DateTime.Now)
                {
                    principal = new ClaimsPrincipal();
                    principal = tokenHandler.ValidateToken(token, parameters, out SecurityToken securityToken);
                    return principal;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                throw new Exception();
            }
        }
        public static IEnumerable<Claim> GetClaims(ClaimsPrincipal claimsPrincipal)
        {
            var identity = (ClaimsIdentity)claimsPrincipal.Identity;
            //var claims = identity.FindAll("UserId");
            var claims = identity.Claims;
            return claims;
        }
    }
}
