using AutoMapper;
using MediatR;
using StyleShop.Application.ApplicationUser;
using StyleShop.Domain.Interfaces;

namespace StyleShop.Application.Product.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductRepository _productRepository;

        private readonly IMapper _mapper;   

        private readonly IUserContext _userContext; 

        public DeleteProductCommandHandler(IProductRepository productRepository, IMapper mapper, IUserContext userContext)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var currentUser = _userContext.GetCurrentUser();

            if (!currentUser.IsInRole("admin"))
            {
                return Unit.Value;
            }

            var product = _mapper.Map<Domain.Entities.Product>(request);
           
            _productRepository.Delete(product);

            await _productRepository.Commit();

            return Unit.Value;
        }
    }
}
