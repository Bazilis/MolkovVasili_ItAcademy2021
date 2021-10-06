using FluentValidation;
using Homework9.Models;

namespace Homework9.Validators
{
    public class UserValidator : AbstractValidator<UserItem>
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
