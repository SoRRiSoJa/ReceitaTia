using authentication.Application.Util;
using authentication.Domain.Entities;
using authentication.Domain.Repositories;
using AutoMapper;
using MediatR;
using System.Security.Cryptography;

namespace authentication.Application.Commands
{
    internal class AddNewUserCommandHandler : IRequestHandler<AddNewUserCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly HashAlgorithm _hashAlgorithm =  SHA512.Create();
        private readonly PasswordUtil _passwordUtil;
        private readonly IMapper _mapper;
        public AddNewUserCommandHandler(IUserRepository _userRepository, PasswordUtil _passwordUtil, IMapper _mapper)
        {
            this._mapper = _mapper ?? throw new ArgumentNullException(nameof(_mapper));
            this._userRepository = _userRepository ?? throw new ArgumentNullException(nameof(_userRepository));
            this._passwordUtil = new(_hashAlgorithm);
        }
        public Task<Guid> Handle(AddNewUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            user.SetSalt(_passwordUtil);
            user.SetPassword(request.Password, _passwordUtil);
            var userId=_userRepository.Add(user);
            return userId;
        }
    }
}
