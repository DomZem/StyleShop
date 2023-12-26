using MediatR;
using StyleShop.Domain.Interfaces;

namespace StyleShop.Application.Product.Commands.EditProduct
{
    public class EditProductCommandHandler : IRequestHandler<EditProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public EditProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetById(request.Id);

            product.Name = request.Name;    
            product.Description = request.Description;
            product.Price = request.Price;
            product.ProductCategoryId = request.ProductCategoryId;

            await _productRepository.Commit();

            return Unit.Value;
        }
    }
}
