using System;

namespace MicroServiceTemplate.Application.Features.Commands.UserCommands
{
    public class UpdateUserCommand:IRequest<IResult>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
    }
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, IResult>
    {
        IUserRepository _userRepository;
        IMapper _mapper;
        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IResult> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            await _userRepository.UpdateAsync(user);
            return Result.Success(SuccessMessage.UpdateSuccess("User"));
        }
    }
}

