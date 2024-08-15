using EntityLayer.WebApplication.ViewModels.Testimonial;
using FluentValidation;
using ServiceLayer.Messages.WebApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.FluentValidation.WebApplication.TestimonialValidation
{
    public class TestimonialUpdateValidation : AbstractValidator<TestimonialUpdateVM>
    {
        public TestimonialUpdateValidation()
        {
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("FullName"))
                .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("FullName"))
                .MaximumLength(100).WithMessage(ValidationMessages.MaximumCharacterAllowence("FullName", 100));
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Title"))
                .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Title"))
                .MaximumLength(100).WithMessage(ValidationMessages.MaximumCharacterAllowence("Title", 100));
            RuleFor(x => x.Comment)
                .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Comment"))
                .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Comment"))
                .MaximumLength(2000).WithMessage(ValidationMessages.MaximumCharacterAllowence("Comment", 2000));

        }
    }
}
