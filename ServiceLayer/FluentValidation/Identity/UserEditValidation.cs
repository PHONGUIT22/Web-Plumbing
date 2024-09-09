using EntityLayer.Identity.ViewModels;
using FluentValidation;
using ServiceLayer.Messages.Identity;
using ServiceLayer.Messages.WebApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.FluentValidation.Identity
{
    public class UserEditValidation : AbstractValidator<UserEditVM>
    {
        public UserEditValidation() 
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Username"))
                .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Username"));
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Email"))
                .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Email"))
                .EmailAddress().WithMessage(IdentityMessages.CheckEmailAddress());
            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Password"))
                .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Password"));
            RuleFor(x => x.ConfirmNewPassword)
                .Equal(x => x.Password).WithMessage(IdentityMessages.ComparePassword());
        }
    }
}
