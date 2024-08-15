using EntityLayer.WebApplication.ViewModels.Service;
using FluentValidation;
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
                .NotEmpty()
                .NotNull()
                .MaximumLength(200);
            RuleFor(x => x.Description)
                .NotEmpty()
                .NotNull()
                .MaximumLength(2000);
            RuleFor(x => x.Icon)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100);
        }
    }
}
