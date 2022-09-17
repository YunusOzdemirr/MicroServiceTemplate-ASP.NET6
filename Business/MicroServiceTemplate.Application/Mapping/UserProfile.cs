using System;
using MicroServiceTemplate.Application.Features.Commands.UserCommands;

namespace MicroServiceTemplate.Application.Mapping
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<User, CreateUserCommand>().ReverseMap();
            CreateMap<User, UpdateUserCommand>().ReverseMap();
        }
    }
}

