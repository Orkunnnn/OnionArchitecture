using MediatR;
using OnionArchitecture.Application.ViewModels.Products;

namespace OnionArchitecture.Application.CQRS.Commands.CreateProduct
{
    public class CreateProductCommandRequest : IRequest<CreateProductCommandResponse>
    {
        public AddProductViewModel AddProductViewModel { get; set; } = default!;
    }
}
