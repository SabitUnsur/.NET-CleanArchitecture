using AutoMapper;
using CleanArchitecture.Application.Abstractions;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.CreateNewTokenByRefreshToken;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.Login;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.Register;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistance.Services
{
    public sealed class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        //private readonly IMailService _mailService;
        private readonly IJwtProvider _jwtProvider;
        public AuthService(UserManager<User> userManager, IMapper mapper, IJwtProvider jwtProvider)
        {
            _userManager = userManager;
            _mapper = mapper;
            //_mailService = mailService;
            _jwtProvider = jwtProvider;
        }

        public async Task RegisterAsync(RegisterCommand request)
        {
            User user = _mapper.Map<User>(request);
            IdentityResult result =  await _userManager.CreateAsync(user, request.Password);
            if(!result.Succeeded)
            {
                throw new Exception(result.Errors.First().Description);
            }
            //List<string> emails = new();
            //emails.Add(request.Email);
            //string body = "Please click the link below to verify your email address";
            //await _mailService.SendMailAsync(emails.First(), "Mail Verification", body);
        }

        public async Task<LoginCommandResponse> LoginAsync(LoginCommand request,CancellationToken cancellationToken)
        {
            var user = _userManager.Users.Where(x => x.Email == request.Email).FirstOrDefaultAsync(cancellationToken);
            if(user == null)
            {
                throw new Exception("User not found");
            }
            var result = await _userManager.CheckPasswordAsync(user.Result, request.Password);
            if(!result)
            {
                throw new Exception("Password is incorrect");
            }
           
            LoginCommandResponse response = await _jwtProvider.CreateTokenAsync(user.Result);
            return response;
        }

        //BU metodun yazılma sebebi, kullanıcının token süresi dolunca refresh token ile yeni bir token alabilmesi için yazılmıştır.
        public async Task<LoginCommandResponse> CreateTokenByRefreshTokenAsync(CreateNewTokenByRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.Users.Where(x => x.RefreshToken == request.RefreshToken).FirstOrDefaultAsync(cancellationToken);

            if(user?.RefreshToken == request.RefreshToken)
            {
                throw new Exception("refresh token is invalid.");
            }

            if(user?.RefreshTokenExpires < DateTime.Now)
            {
                throw new Exception("refresh token is expired.");
            }

            LoginCommandResponse response = await _jwtProvider.CreateTokenAsync(user);
            return response;
        }
    }
}
