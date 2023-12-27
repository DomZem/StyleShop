using AutoMapper;
using MediatR;
using StyleShop.Application.ApplicationUser;
using StyleShop.Domain.Interfaces;

namespace StyleShop.Application.Product.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IProductRepository _productRepository;

        private readonly IMapper _mapper;

        private readonly IUserContext _userContext;

        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper, IUserContext userContext)
        {
            _productRepository = productRepository;  
            _mapper = mapper;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var currentUser = _userContext.GetCurrentUser();

            if(!currentUser.IsInRole("admin")) 
            {
                return Unit.Value;
            }

            var product = _mapper.Map<Domain.Entities.Product>(request);
            await _productRepository.Create(product);

            return Unit.Value;  
        }
    }
}
