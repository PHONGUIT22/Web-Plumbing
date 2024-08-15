using EntityLayer.WebApplication.ViewModels.Portfolio;
using FluentValidation;
using ServiceLayer.Messages.WebApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.FluentValidation.WebApplication.PortfolioValidation
{
    public class PortfolioAddValidation : AbstractValidator<PortfolioAddVM>
    {
        public PortfolioAddValidation() 
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Title"))
                .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Title"))
                .MaximumLength(200).WithMessage(ValidationMessages.MaximumCharacterAllowence("Title", 200)); 
            
            RuleFor(x => x.Photo)
                .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Photo"))
                .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Photo"));
        }
    }
}
