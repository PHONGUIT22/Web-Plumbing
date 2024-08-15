using EntityLayer.WebApplication.ViewModels.Category;
using FluentValidation;
using ServiceLayer.Messages.WebApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.FluentValidation.WebApplication.CategoryValidation
{
    public class CategoryUpdateValidation : AbstractValidator<CategoryUpdateVM>
    {
        public CategoryUpdateValidation()
        {
            RuleFor(x => x.Name)
              .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Name"))
              .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Name"))
              .MaximumLength(50).WithMessage(ValidationMessages.MaximumCharacterAllowence("Name", 50));

        }
    }
}
