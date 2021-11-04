using ControlWorkApp.BLL.DTO;
using FluentValidation;

namespace ControlWorkApp.BLL.Validators
{
    public class CustomerValidator : AbstractValidator<CustomerDto>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.Name)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(30)
                .WithMessage("Name of Customer is null or empty or invalid length");
        }
    }
}
