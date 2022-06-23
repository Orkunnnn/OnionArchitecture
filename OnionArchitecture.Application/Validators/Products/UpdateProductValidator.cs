using FluentValidation;
using OnionArchitecture.Application.ViewModels.Products;

namespace OnionArchitecture.Application.Validators.Products
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductViewModel>
    {
        public UpdateProductValidator()
        {
            RuleFor(x => x.Id).Cascade(CascadeMode.Stop).NotEmpty().NotNull().WithMessage("Please enter a id value.");
            RuleFor(x => x.Name).Cascade(CascadeMode.Stop).NotEmpty().NotNull().WithMessage("Please enter a product name.").MinimumLength(2).MaximumLength(150).WithMessage("")
        }
    }
}
