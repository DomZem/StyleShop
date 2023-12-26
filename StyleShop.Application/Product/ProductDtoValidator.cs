using FluentValidation;

namespace StyleShop.Application.Product
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
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
