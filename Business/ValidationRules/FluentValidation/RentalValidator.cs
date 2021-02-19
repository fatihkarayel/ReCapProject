using Business.Constants;
using Entitites.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental> //gerekirse DTO lar içinde yapabiliriz
    {
        public RentalValidator()
        {
            //kuralları contructor içine yazıyoruz.
            RuleFor(p => p.CarId).NotEmpty().WithMessage(Messages.CarInvalid);
            RuleFor(p => p.CustomerId).NotEmpty().WithMessage(Messages.CustomerInvalid);
            RuleFor(p => p.RentDate).NotEmpty().WithMessage(Messages.RentDateInvalid);

            //BrandId 1 kategorisinin ürünleri en az 10 olmalı
            //RuleFor(p => p.DailyPrice).GreaterThanOrEqualTo(10).When(p => p.BrandId == 1);
            //olmayan bir şey bile yazılabilir. mesela ürün ismi A ile başlamalı gibi bir kural koymak istesek. böyle bir metod oluşturabiliriz.
            //RuleFor(p => p.Name).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalı.");

        }

        //private bool StartWithA(string arg)
        //{
        //    return arg.StartsWith("A");
        //}

    }
}
