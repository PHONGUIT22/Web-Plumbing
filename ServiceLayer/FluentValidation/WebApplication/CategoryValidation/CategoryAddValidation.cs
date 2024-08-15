using EntityLayer.WebApplication.ViewModels.Category;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.FluentValidation.WebApplication.CategoryValidation
{
    public class CategoryAddValidation : AbstractValidator<CategoryAddVM>
    {
        public CategoryAddValidation()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().MaximumLength(50);
        }
    }
}
