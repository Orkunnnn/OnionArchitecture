using AutoMapper;
using MediatR;
using OnionArchitecture.Application.Repositories.Products;
using OnionArchitecture.Domain.Entities;

namespace OnionArchitecture.Application.CQRS.Commands.UpdateProduct
{
    public class UpdateProductCommandRequestHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IMapper _mapper;

        public UpdateProductCommandRequestHandler(IProductWriteRepository productWriteRepository, IMapper mapper)
        {
            _productWriteRepository = productWriteRepository;
            _mapper = mapper;
        }

        public Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request.UpdateProductViewModel);
            _productWriteRepository.Update(product);
            _productWriteRepository.Save();
            return Task.FromResult<UpdateProductCommandResponse>(new());
        }
    }
}
