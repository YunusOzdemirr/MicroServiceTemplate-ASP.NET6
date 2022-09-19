using System;

namespace MicroServiceTemplate.Application.Features.Queries.UserQueries
{
    public class GetAllUsersQuery:IRequest<IResult>
    {
        public GetAllUsersQuery()
        {
        }
    }
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IResult>
    {
        IUserRepository _userRepository;
        IMapper mapper;
        public GetAllUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IResult> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync();
            return Result.Success(SuccessMessage.GetSuccess(), users);
        }
    }
}

