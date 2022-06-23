using FluentValidation;
using OnionArchitecture.Application.Constants.Categories;
using OnionArchitecture.Application.ViewModels.Categories;

namespace OnionArchitecture.Application.Validators.Categories
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryViewModel>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(c => c.Id).Cascade(CascadeMode.Stop).NotEmpty().NotNull().WithMessage(Message.ProvideCategoryId);
            RuleFor(c => c.Name).Cascade(CascadeMode.Stop).NotEmpty().NotNull().WithMessage(Message.ProvideCategoryName).MinimumLength(2).MaximumLength(50).WithMessage(Message.InvalidCategoryName);
        }
    }
}
