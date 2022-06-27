using MediatR;

namespace OnionArchitecture.Application.CQRS.Queries.GetAllProducts
{
    public class GetAllProductsQueryRequest : IRequest<GetAllProductsQueryResponse>
    {
    }
}
