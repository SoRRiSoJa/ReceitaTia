using authentication.Application.Commands;
using authentication.Application.DTOs;
using authentication.Domain.Entities;
using AutoMapper;

namespace authentication.Application.Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<User, UsersDto>().ReverseMap();
            CreateMap<User, AddNewUserCommand>().ReverseMap();
            CreateMap<User, LoginCommand>().ReverseMap();
        }
    }
}
