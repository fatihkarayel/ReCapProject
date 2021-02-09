using Business.Abstract;
using DataAccess.Abstarct;
using Entitites.Concrete;
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
        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }
        public Car GetById(int carId)
        {
            return _carDal.Get(p=> p.Id == carId);
        }
        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }
        public void Add(Car car)
        {
            if (car.Name.Length>2)
            {
                if (car.DailyPrice>0)
                {
                    _carDal.Add(car);
                    Console.WriteLine("Araba eklendi");
                }
                else
                {
                    Console.WriteLine("Arabanın günlük fiyatı sıfırdan büyük olmalı!");
                }                             
            }
            else
            {
                Console.WriteLine("Arabanın ismi en az üç karakter olmalı!");
            }
            
            
        }
        public void Update(Car car)
        {
            _carDal.Update(car);
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(p => p.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(p => p.ColorId == colorId);
        }
    }
}
