using MediatR;
using OnionArchitecture.Application.Repositories.Categories;
using OnionArchitecture.Application.Repositories.Products;

namespace OnionArchitecture.Application.CQRS.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly ICategoryWriteRepository _categoryWriteRepository;

        public CreateProductCommandHandler(IProductWriteRepository productWriteRepository, ICategoryWriteRepository categoryWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
            this._categoryWriteRepository = categoryWriteRepository;
        }

        public Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            _productWriteRepository.Add(new() { Name = request.AddProductViewModel.Name, Price = request.AddProductViewModel.Price, Stock = request.AddProductViewModel.Stock, CategoryId = request.AddProductViewModel.CategoryId });
            _productWriteRepository.Save();
            return Task.FromResult<CreateProductCommandResponse>(new());
        }
    }
}
