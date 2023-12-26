using MediatR;

namespace StyleShop.Application.Order.Queries.GetOrderDetailsById
{
    public class GetOrderDetailsByIdQuery : IRequest<OrderDto>
    {
        public int Id { get; set; }

        public GetOrderDetailsByIdQuery(int id)
        {
            Id = id;
        }
    }
}
