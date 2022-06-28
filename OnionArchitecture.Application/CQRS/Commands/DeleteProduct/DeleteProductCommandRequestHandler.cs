using MediatR;
using OnionArchitecture.Application.Repositories.Products;

namespace OnionArchitecture.Application.CQRS.Commands.DeleteProduct
{
    public class DeleteProductCommandRequestHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
    {
        private readonly IProductWriteRepository _productWriteRepository;
        public DeleteProductCommandRequestHandler(IProductWriteRepository productWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
        }

        public Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var result = _productWriteRepository.Remove(request.DeleteProductViewModel.Id);
            _productWriteRepository.Save();
            return Task.FromResult<DeleteProductCommandResponse>(new() { Result = result });
        }
    }
}
