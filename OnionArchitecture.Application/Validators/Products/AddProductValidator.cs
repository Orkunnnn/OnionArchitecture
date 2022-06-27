using FluentValidation;
using OnionArchitecture.Application.Constants.Products;
using OnionArchitecture.Application.ViewModels.Products;

namespace OnionArchitecture.Application.Validators.Products
{
    public class AddProductValidator : AbstractValidator<AddProductViewModel>
    {
        public AddProductValidator()
        {
            RuleFor(p => p.Name).Cascade(CascadeMode.Stop).NotEmpty().NotNull().WithMessage(Message.ProvideProductName).MaximumLength(150).MinimumLength(2).WithMessage(Message.InvalidProductNameLength);
            RuleFor(p => p.Price).Cascade(CascadeMode.Stop).NotEmpty().NotNull().WithMessage(Message.ProvideProductPrice).GreaterThan(0).ScalePrecision(2, 8, true).WithMessage(Message.InvalidProductPrice);
            RuleFor(p => p.Stock).Cascade(CascadeMode.Stop).NotEmpty().NotNull().WithMessage(Message.ProvideProductStock).GreaterThanOrEqualTo(0).WithMessage(Message.InvalidProductStock);
        }
    }
}
