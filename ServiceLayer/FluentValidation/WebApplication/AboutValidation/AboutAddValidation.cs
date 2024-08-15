using EntityLayer.WebApplication.ViewModels.AboutVM;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.FluentValidation.WebApplication.AboutValidation
{
    public class AboutAddValidation : AbstractValidator<AboutAddVM>
    {
        public AboutAddValidation() 
        {
            RuleFor(x => x.Header)
            .NotEmpty()
            .NotNull()
            .MaximumLength(200);
            RuleFor(x => x.Description)
            .NotEmpty()
            .NotNull()
            .MaximumLength(5000);
            RuleFor(x => x.Clients)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0)
            .LessThan(1000);
            RuleFor(x=>x.Projects)
             .NotEmpty()
             .NotNull()
             .GreaterThan(0)
             .LessThan(1000);
            RuleFor(x => x.HoursOfSupport)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0)
            .LessThan(1000);
            RuleFor(x => x.HardWorkers)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0)
            .LessThan(99);
            RuleFor(x => x.Photo)
           .NotEmpty()
           .NotNull();
        }
    }
}
