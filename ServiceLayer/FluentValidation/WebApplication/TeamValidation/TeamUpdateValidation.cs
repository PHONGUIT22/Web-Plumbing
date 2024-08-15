using EntityLayer.WebApplication.ViewModels.Team;
using FluentValidation;
using ServiceLayer.Messages.WebApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.FluentValidation.WebApplication.TeamValidation
{
    public class TeamUpdateValidation : AbstractValidator<TeamUpdateVM>
    {
        public TeamUpdateValidation()
        {
            RuleFor(x => x.FullName)
                 .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("FullName"))
                 .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("FullName"))
                 .MaximumLength(100).WithMessage(ValidationMessages.MaximumCharacterAllowence("FullName", 100));
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Title"))
                .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Title"))
                .MaximumLength(100).WithMessage(ValidationMessages.MaximumCharacterAllowence("Title", 100));

        }
    }
}
