using EntityLayer.WebApplication.ViewModels.Testimonial;
using FluentValidation;
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
                .NotEmpty()
                .NotEmpty()
                .MaximumLength(100);
            RuleFor(x => x.Title)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100);
            RuleFor(x => x.Comment)
                .NotEmpty()
                .NotNull()
                .MaximumLength(2000);
            RuleFor(x => x.FileName)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.FileType)
                .NotEmpty()
                .NotNull();
        }
    }
}
