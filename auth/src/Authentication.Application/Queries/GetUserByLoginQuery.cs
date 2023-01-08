using authentication.Application.DTOs;
using MediatR;

namespace authentication.Application.Queries
{
    public class GetUserByLoginQuery : IRequest<UsersDto>
    {
        public string Login { get; set; }
    }
}
