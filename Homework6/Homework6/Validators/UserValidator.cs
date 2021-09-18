using FluentValidation;
using Homework6.Models;

namespace Homework6.Validators
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
