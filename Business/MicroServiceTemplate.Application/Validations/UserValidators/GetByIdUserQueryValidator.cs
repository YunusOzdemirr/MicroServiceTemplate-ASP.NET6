using System;
using MicroServiceTemplate.Application.Features.Queries.UserQueries;

namespace MicroServiceTemplate.Application.Validations.UserValidators
{
    public class GetByIdUserQueryValidator:AbstractValidator<GetByIdUserQuery>
    {
        public GetByIdUserQueryValidator()
        {
            RuleFor(a => a.Id).NotNull().NotEmpty();
        }
    }
}

