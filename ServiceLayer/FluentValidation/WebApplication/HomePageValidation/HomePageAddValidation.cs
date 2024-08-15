using EntityLayer.WebApplication.ViewModels.HomePage;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.FluentValidation.WebApplication.HomePageValidation
{
    public class HomePageAddValidation : AbstractValidator<HomePageAddVM>
    {
        public HomePageAddValidation()
        {
            RuleFor(x => x.Header)
            .NotEmpty()
            .NotNull()
            .MaximumLength(200);
            RuleFor(x => x.Description)
            .NotEmpty()
            .NotNull()
            .MaximumLength(2000);
            RuleFor(x => x.VideoLink)
            .NotEmpty()
            .NotNull();
            
        }
    }
}
