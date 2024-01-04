using FluentValidation;
using StyleShop.Domain.Interfaces;

namespace StyleShop.Application.Order.Commands.CreateOrder
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator(IProductRepository productRepository)
        {
            int productId = 0;

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

            RuleFor(o => o.ProductId)
                .Must(value =>
                {
                    productId = value;
                    return true; // This is where you put your validation logic
                })
                .WithMessage("Invalid product ID");

            RuleFor(o => o.ProductQuantity)
                .Custom((value, context) =>
                {
                    var product = productRepository.GetById(productId).Result;

                    if(product != null) 
                    { 
                        if(product.Quantity < value)
                        {
                            context.AddFailure("You cannot order biiger amount than available");
                        }
                    }
                });
        }
    }
}
