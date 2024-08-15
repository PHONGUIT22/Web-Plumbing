using EntityLayer.WebApplication.ViewModels.Service;
using FluentValidation;
using ServiceLayer.Messages.WebApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.FluentValidation.WebApplication.ServiceValidation
{
    public class ServiceAddValidation : AbstractValidator<ServiceAddVM>
    {
        public ServiceAddValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Name"))
                .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Name"))
                .MaximumLength(200).WithMessage(ValidationMessages.MaximumCharacterAllowence("Name", 200)); 
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Description"))
                .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Description"))
                .MaximumLength(2000).WithMessage(ValidationMessages.MaximumCharacterAllowence("Description", 2000));
            RuleFor(x => x.Icon)
                .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Icon"))
                .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Icon"))
                .MaximumLength(100).WithMessage(ValidationMessages.MaximumCharacterAllowence("Icon", 100));
        }
    }
}
