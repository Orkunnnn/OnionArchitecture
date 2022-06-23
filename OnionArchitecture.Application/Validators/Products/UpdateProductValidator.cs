using FluentValidation;
using OnionArchitecture.Application.Constants.Product;
using OnionArchitecture.Application.ViewModels.Products;

namespace OnionArchitecture.Application.Validators.Products
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductViewModel>
    {
        public UpdateProductValidator()
        {
            RuleFor(x => x.Id).Cascade(CascadeMode.Stop).NotEmpty().NotNull().WithMessage(Message.ProvideProductId);
            RuleFor(x => x.Name).Cascade(CascadeMode.Stop).NotEmpty().NotNull().WithMessage(Message.ProvideProductName).MinimumLength(2).MaximumLength(150).WithMessage(Message.InvalidProductNameLength);
            RuleFor(x => x.Stock).Cascade(CascadeMode.Stop).NotEmpty().NotNull().WithMessage(Message.InvalidProductStock).GreaterThanOrEqualTo(0).WithMessage(Message.InvalidProductStock);
            RuleFor(x => x.Price).Cascade(CascadeMode.Stop).NotEmpty().NotNull().WithMessage(Message.ProvideProductPrice).GreaterThan(0).WithMessage(Message.InvalidProductPrice);
        }
    }
}
