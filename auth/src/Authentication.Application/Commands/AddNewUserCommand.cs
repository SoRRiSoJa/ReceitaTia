using MediatR;

namespace authentication.Application.Commands
{
    public class AddNewUserCommand : IRequest<Guid>
    {
        public string Username { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
