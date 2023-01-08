using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace authentication.Application.Commands
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
    {
        public Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
