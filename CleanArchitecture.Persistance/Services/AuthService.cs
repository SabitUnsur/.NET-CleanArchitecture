﻿using AutoMapper;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.Register;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using Microsoft.AspNetCore.Identity;
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
        private readonly IMailService _mailService;
        public AuthService(UserManager<User> userManager, IMapper mapper, IMailService mailService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _mailService = mailService;
        }

        public async Task RegisterAsync(RegisterCommand request)
        {
            User user = _mapper.Map<User>(request);
            IdentityResult result =  await _userManager.CreateAsync(user, request.Password);
            if(!result.Succeeded)
            {
                throw new Exception(result.Errors.First().Description);
            }
            List<string> emails = new();
            emails.Add(request.Email);
            string body = "Please click the link below to verify your email address";
            await _mailService.SendMailAsync(emails.First(), "Mail Verification", body);
        }
    }
}
