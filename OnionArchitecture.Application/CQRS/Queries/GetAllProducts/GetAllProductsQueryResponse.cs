using OnionArchitecture.Application.ViewModels.Products;

namespace OnionArchitecture.Application.CQRS.Queries.GetAllProducts
{
    public class GetAllProductsQueryResponse
    {
        public List<GetProductViewModel> Products { get; set; } = default!;
    }
}
