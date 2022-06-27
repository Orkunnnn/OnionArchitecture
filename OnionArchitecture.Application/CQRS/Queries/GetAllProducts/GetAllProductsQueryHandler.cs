using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnionArchitecture.Application.Repositories.Products;
using OnionArchitecture.Application.ViewModels.Products;

namespace OnionArchitecture.Application.CQRS.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, GetAllProductsQueryResponse>
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(IProductReadRepository productReadRepository, IMapper mapper)
        {
            _productReadRepository = productReadRepository;
            _mapper = mapper;
        }

        public Task<GetAllProductsQueryResponse> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var productViewModel = _mapper.Map<List<GetProductViewModel>>(_productReadRepository.GetAll().Include(p => p.Category));
            return Task.FromResult<GetAllProductsQueryResponse>(new() { Products = productViewModel });
        }
    }
}
