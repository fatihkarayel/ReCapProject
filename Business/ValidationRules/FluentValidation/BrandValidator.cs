using Business.Constants;
using Entitites.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            //kuralları contructor içine yazıyoruz.
            RuleFor(p => p.Name).NotEmpty().MinimumLength(3).WithMessage(Messages.BrandNameInvalid);
 
        }
    }
}
