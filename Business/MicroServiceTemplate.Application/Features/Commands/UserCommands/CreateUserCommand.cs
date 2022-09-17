using System;
using MicroServiceTemplate.Application.Interfaces.Repositories;

namespace MicroServiceTemplate.Application.Features.Commands.UserCommands
{
    public class CreateUserCommand:IRequest<IResult>
    {
        public string FirstName { get; set; }
    }
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, IResult>
    {
        IUserRepository _userRepository;
        IMapper _mapper;
        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            user.Id = Guid.NewGuid();
            user.CreatedBy = user.Id;
            await _userRepository.AddAsync(user);
            return Result.Success(SuccessMessage.CreateSuccess("User"), user);
        }
    }
}

