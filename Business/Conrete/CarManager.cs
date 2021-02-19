using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entitites.Concrete;
using Entitites.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Conrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarsListed);
        }
        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c=> c.Id == carId),Messages.CarDetail);
        }
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);

        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            //Artık aşağıdaki doğrulamaya gerek yok çünkü validasyon yönetimi için FluentValidation kurduk
            //if (car.Name.Length>2)
            //{
            //    if (car.DailyPrice>0)
            //    {
            //        _carDal.Add(car);
            //        return new SuccessResult(Messages.CarAdded);
            //        //Console.WriteLine("Araba eklendi");
            //    }
            //    else
            //    {
            //        return new ErrorResult(Messages.CarPriceInvalid);
            //        //Console.WriteLine("Arabanın günlük fiyatı sıfırdan büyük olmalı!");
            //    }                             
            //}
            //else
            //{
            //    return new ErrorResult(Messages.CarNameInvalid);
            //    //Console.WriteLine("Arabanın ismi en az üç karakter olmalı!");
            //}

            //Aşağıdaki validasyonu generic kullanım için Core a taşıdık. Bu metodun üstüne attribute olarak koyduk
            //var context = new ValidationContext<Car>(car);
            //CarValidator carValidator = new CarValidator();
            //var result = carValidator.Validate(context);
            //if (!result.IsValid)
            //{
            //    throw new ValidationException(result.Errors);
            //}

            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == brandId),Messages.CarsByBrand);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == colorId),Messages.CarsByColor);
        }

        public IDataResult<List<CarDetailDTO>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDTO>>(_carDal.GetCarDetails(),Messages.CarsDetailListed);
        }
    }
}
