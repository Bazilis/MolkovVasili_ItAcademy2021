using ControlWorkApp.BLL.DTO;
using FluentValidation;

namespace ControlWorkApp.BLL.Validators
{
    public class OrderValidator : AbstractValidator<OrderDto>
    {
        public OrderValidator()
        {
            RuleFor(order => order.Name)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(30)
                .WithMessage("Name of Order is null or empty or invalid length");
        }
    }
}
