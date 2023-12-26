using FluentValidation;

namespace StyleShop.Application.Product.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .MinimumLength(1)
                .MaximumLength(50);

            RuleFor(p => p.Description)
                .MaximumLength(150);

            RuleFor(p => p.Quantity)
                .GreaterThanOrEqualTo(1);
        }
    }
}
