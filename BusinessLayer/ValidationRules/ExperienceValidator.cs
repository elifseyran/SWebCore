using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ExperienceValidator:AbstractValidator<Experience>
    {
        public ExperienceValidator()
        {
            RuleFor(x => x.CompanyName).NotEmpty().WithMessage(" boş geçilemez");
            RuleFor(x => x.Position).NotEmpty().WithMessage(" boş geçilemez");
            RuleFor(x => x.StartingDate).NotEmpty().WithMessage(" boş geçilemez");
            RuleFor(x => x.CompanySector).NotEmpty().WithMessage(" boş geçilemez");
            RuleFor(x => x.BusinessArea).NotEmpty().WithMessage(" boş geçilemez");
        }

    }
}
