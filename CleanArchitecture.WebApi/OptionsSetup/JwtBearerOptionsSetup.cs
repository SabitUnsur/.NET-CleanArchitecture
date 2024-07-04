using CleanArchitecture.Infrastructure.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CleanArchitecture.WebApi.OptionsSetup
{
    //Bu sınıfın amacı JwtBearerOptions nesnesini set etmektir.
    public sealed class JwtBearerOptionsSetup : IPostConfigureOptions<JwtBearerOptions>
    {
        private readonly JwtOptions _jwtOptions;

        public JwtBearerOptionsSetup(IOptions<JwtOptions> jwtOptions)
        {
            _jwtOptions = jwtOptions.Value;
        }
        //IOptions<JwtOptions> ile appsettings.json dosyasındaki Jwt alanındaki değerleri JwtOptions nesnesine atıyoruz.

        //program.cs dosyasında AddJwtBearer metodunda options => { } içerisindeki değerlerin set edilmesi için kullanılır.
        public void PostConfigure(string? name, JwtBearerOptions options)
        {
            options.TokenValidationParameters.ValidateIssuer = true;
            options.TokenValidationParameters.ValidateAudience = true;
            options.TokenValidationParameters.ValidateLifetime = true;
            options.TokenValidationParameters.ValidateIssuerSigningKey = true; 
            options.TokenValidationParameters.ValidIssuer = _jwtOptions.Issuer;
            options.TokenValidationParameters.ValidAudience = _jwtOptions.Audience;
            options.TokenValidationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey));
        }
    }
}   
