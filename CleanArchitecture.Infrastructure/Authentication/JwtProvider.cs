using CleanArchitecture.Application.Abstractions;
using CleanArchitecture.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Authentication
{
    public sealed class JwtProvider : IJwtProvider
    {
        private readonly JwtOptions _jwtOptions;

        public JwtProvider(IOptions<JwtOptions> jwtOptions)
        {
            _jwtOptions = jwtOptions.Value;
        }

        public string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            JwtSecurityToken jwtSecurityToken = new(
             issuer: _jwtOptions.Issuer,
             audience: _jwtOptions.Audience,
             claims: claims,
             notBefore: DateTime.Now, // Token oluşturulduğu andan itibaren geçerli olacak
             expires: DateTime.Now.AddHours(1), // Token'ın ne kadar süre geçerli olacağı
             signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)), SecurityAlgorithms.HmacSha256) 
             );

            string token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            
            return token;
        }
    }
}
