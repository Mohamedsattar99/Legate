using System;
using System.Collections.Generic;
using System.Text;
using Application.Users.Commands.CreateUser;
using FluentValidation;

namespace Application.User.Commands.CreateUser {
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand> {
        public CreateUserCommandValidator () {

            //TODO: this length is too short
            RuleFor (r => r.Name).MaximumLength (15).NotEmpty ();
            //TODO: this length is too short
            RuleFor (r => r.Address).MaximumLength (25).NotEmpty ();
            RuleFor (r => r.Postion).MaximumLength (20).NotEmpty ();
            RuleFor (r => r.JoiningDate).NotEmpty ();
        }
    }
}