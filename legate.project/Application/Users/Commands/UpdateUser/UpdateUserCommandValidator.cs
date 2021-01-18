using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Users.Commands.UpdateUser
{
   public class UpdateUserCommandValidator: AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(r => r.Name).MaximumLength(15).NotEmpty();
            RuleFor(r => r.Address).MaximumLength(25).NotEmpty();
            RuleFor(r => r.Postion).MaximumLength(20).NotEmpty();
            RuleFor(r => r.JoiningDate).NotEmpty();
        }
    }
}
