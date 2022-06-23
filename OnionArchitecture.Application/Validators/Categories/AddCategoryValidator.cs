using FluentValidation;
using OnionArchitecture.Application.Constants.Categories;
using OnionArchitecture.Application.ViewModels.Categories;

namespace OnionArchitecture.Application.Validators.Categories
{
    public class AddCategoryValidator : AbstractValidator<AddCategoryViewModel>
    {
        public AddCategoryValidator()
        {
            RuleFor(c => c.Name).Cascade(CascadeMode.Stop).NotEmpty().NotNull().WithMessage(Message.ProvideCategoryName).MinimumLength(2).MaximumLength(50).WithMessage(Message.InvalidCategoryName);
        }
    }
}
