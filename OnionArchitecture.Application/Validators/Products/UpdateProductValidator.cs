using FluentValidation;
using OnionArchitecture.Application.Constants.Products;
using OnionArchitecture.Application.ViewModels.Products;

namespace OnionArchitecture.Application.Validators.Products
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductViewModel>
    {
        public UpdateProductValidator()
        {
            RuleFor(p => p.Id).Cascade(CascadeMode.Stop).NotEmpty().NotNull().WithMessage(Message.ProvideProductId);
            RuleFor(p => p.Name).Cascade(CascadeMode.Stop).NotEmpty().NotNull().WithMessage(Message.ProvideProductName).MinimumLength(2).MaximumLength(150).WithMessage(Message.InvalidProductNameLength);
            RuleFor(p => p.Stock).Cascade(CascadeMode.Stop).NotEmpty().NotNull().WithMessage(Message.InvalidProductStock).GreaterThanOrEqualTo(0).WithMessage(Message.InvalidProductStock);
            RuleFor(p => p.Price).Cascade(CascadeMode.Stop).NotEmpty().NotNull().WithMessage(Message.ProvideProductPrice).GreaterThan(0).WithMessage(Message.InvalidProductPrice);
        }
    }
}
