using MediatR;
using OnionArchitecture.Application.ViewModels.Products;

namespace OnionArchitecture.Application.CQRS.Commands.DeleteProduct
{
    public class DeleteProductCommandRequest : IRequest<DeleteProductCommandResponse>
    {
        public DeleteProductViewModel DeleteProductViewModel { get; set; } = default!;
    }
}
