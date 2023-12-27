using FluentValidation;
using FluentValidation;

namespace StyleShop.Application.Order.Commands.CreateOrder
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(o => o.Street)
                .NotEmpty()
                .MinimumLength(1)
                .MaximumLength(50);
            RuleFor(o => o.City)
                .NotEmpty()
                .MinimumLength(1)
                .MaximumLength(50);

            RuleFor(o => o.PostalCode)
                .NotEmpty()
                .MinimumLength(1)
                .MaximumLength(25);

            RuleFor(o => o.Country)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(50);

            RuleFor(o => o.ProductQuantity)
                .GreaterThanOrEqualTo(1);
        }
    }
}
