using System.Runtime.CompilerServices;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Homework7.Models;
using Microsoft.AspNetCore.Mvc;

namespace Homework7.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.Name)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(30)
                .WithMessage("Name of User is null or empty or invalid length");
        }
    }
}
