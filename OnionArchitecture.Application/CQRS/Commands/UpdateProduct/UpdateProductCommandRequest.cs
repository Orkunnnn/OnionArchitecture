using MediatR;
using OnionArchitecture.Application.ViewModels.Products;

namespace OnionArchitecture.Application.CQRS.Commands.UpdateProduct
{
    public class UpdateProductCommandRequest : IRequest<UpdateProductCommandResponse>
    {
        public UpdateProductViewModel UpdateProductViewModel { get; set; } = default!;
    }
}
