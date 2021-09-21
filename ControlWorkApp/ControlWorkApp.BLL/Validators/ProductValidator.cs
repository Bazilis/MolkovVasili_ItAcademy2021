using ControlWorkApp.BLL.DTO;
using FluentValidation;

namespace ControlWorkApp.BLL.Validators
{
    public class ProductValidator : AbstractValidator<ProductDto>
    {
        public ProductValidator()
        {
            RuleFor(product => product.Name)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(30)
                .WithMessage("Name of Product is null or empty or invalid length");
        }
    }
}
