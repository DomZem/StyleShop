using MediatR;
using StyleShop.Application.ApplicationUser;
using StyleShop.Domain.Interfaces;

namespace StyleShop.Application.Product.Commands.EditProduct
{
    public class EditProductCommandHandler : IRequestHandler<EditProductCommand>
    {
        private readonly IProductRepository _productRepository;

        private readonly IUserContext _userContext;

        public EditProductCommandHandler(IProductRepository productRepository, IUserContext userContext)
        {
            _productRepository = productRepository;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            var currentUser = _userContext.GetCurrentUser();

            if (!currentUser.IsInRole("admin"))
            {
                return Unit.Value;
            }

            var product = await _productRepository.GetById(request.Id);

            product.Name = request.Name;    
            product.Description = request.Description;
            product.Price = request.Price;
            product.Quantity = request.Quantity;
            product.ProductCategoryId = request.ProductCategoryId;

            await _productRepository.Commit();

            return Unit.Value;
        }
    }
}
