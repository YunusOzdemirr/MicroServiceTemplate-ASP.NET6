using System;
namespace MicroServiceTemplate.Application.Features.Queries.UserQueries
{
    public class GetByIdUserQuery : IRequest<IResult>
    {
        public Guid Id { get; set; }
    }
    public class GetUserQueryHandler : IRequestHandler<GetByIdUserQuery, IResult>
    {
        IUserRepository _userRepository;
        IMapper _mapper;
        public GetUserQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<IResult> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user is not null)
                return Result.Success(SuccessMessage.GetSuccess("User"), user);
            return Result.Fail(ErrorMessage.GetFail("User"));
        }
    }
}

