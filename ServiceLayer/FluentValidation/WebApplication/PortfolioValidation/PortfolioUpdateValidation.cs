using EntityLayer.WebApplication.ViewModels.Portfolio;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.FluentValidation.WebApplication.PortfolioValidation
{
    public class PortfolioUpdateValidation : AbstractValidator<PortfolioUpdateVM>
    {
        public PortfolioUpdateValidation()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .NotNull()
                .MaximumLength(200);
            RuleFor(x => x.FileName)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.FileType)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.Photo)
                .NotEmpty()
                .NotNull();
        }
    }
}
