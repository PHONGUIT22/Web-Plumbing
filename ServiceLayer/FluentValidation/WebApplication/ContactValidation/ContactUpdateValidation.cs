using EntityLayer.WebApplication.ViewModels.Contact;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.FluentValidation.WebApplication.ContactValidation
{
    public class ContactUpdateValidation : AbstractValidator<ContactUpdateVM>
    {
        public ContactUpdateValidation()
        {
            RuleFor(x => x.Location)
            .NotEmpty()
            .NotNull()
            .MaximumLength(200);
            RuleFor(x => x.Email)
            .NotEmpty()
            .NotNull()
            .MaximumLength(100);
            RuleFor(x => x.Call)
            .NotEmpty()
            .NotNull()
            .MaximumLength(17);
            RuleFor(x => x.Map)
            .NotEmpty()
            .NotNull();
        }
    }
}
