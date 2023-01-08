using authentication.Application.Exceptions;
using authentication.Application.Util;
using authentication.Domain.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;

namespace authentication.Application.Commands
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly HashAlgorithm _hashAlgorithm = SHA512.Create();
        private readonly PasswordUtil _passwordUtil;
        private readonly IConfiguration _configuration;
        public LoginCommandHandler(IUserRepository _userRepository, IConfiguration _configuration)
        {
            this._userRepository = _userRepository ?? throw new ArgumentNullException(nameof(_userRepository));
            this._passwordUtil = new(_hashAlgorithm);
            this._configuration = _configuration ?? throw new ArgumentNullException(nameof(_configuration));
        }
        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByLogin(request.Login);
            var isUserChecked = _passwordUtil.CheckPassword(request.Password, user.Password, user.Salt);
            if (isUserChecked)
            {
                var token = user.GenerateToken(_configuration["Secrets:KeyTia"]);
                return token;
            }
            else
            {
                throw new ValidationException("Invalid login or password");
            }
        }
    }
}
