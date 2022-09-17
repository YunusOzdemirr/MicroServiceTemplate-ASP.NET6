using System;
using FluentValidation;
using MicroServiceTemplate.Application.Features.Commands.UserCommands;

namespace MicroServiceTemplate.Application.Validations.UserValidators
{
    public class CreateUserCommandValidator:AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(a => a.FirstName).NotNull().NotEmpty().MaximumLength(50);
        }
    }
}

