using FluentValidation;
using OnionArchitecture.Application.Constants;
using OnionArchitecture.Application.ViewModels.Products;

namespace OnionArchitecture.Application.Validators.Products
{
    public class AddProductValidator : AbstractValidator<AddProductViewModel>
    {
        public AddProductValidator()
        {
            RuleFor(x => x.Name).Cascade(CascadeMode.Stop).NotEmpty().NotNull().WithMessage(Messages.ProvideProductName).MaximumLength(150).MinimumLength(2).WithMessage(Messages.InvalidProductNameLength);
            RuleFor(x => x.Price).Cascade(CascadeMode.Stop).NotEmpty().NotNull().WithMessage(Messages.ProvideProductPrice).GreaterThan(0).WithMessage(Messages.InvalidProductPrice);
            RuleFor(x => x.Stock).Cascade(CascadeMode.Stop).NotEmpty().NotNull().WithMessage(Messages.ProvideProductStock).GreaterThanOrEqualTo(0).WithMessage(Messages.InvalidProductStock);
        }
    }
}
