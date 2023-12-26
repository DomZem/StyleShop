using FluentValidation;

namespace StyleShop.Application.Product.Commands.EditProduct
{
    public class EditProductCommandValidator : AbstractValidator<EditProductCommand>
    {
        public EditProductCommandValidator()
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
