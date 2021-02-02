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
            return _carDal.GetById(carId);
        }
        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }
        public void Add(Car car)
        {
            _carDal.Add(car);
        }
        public void Update(Car car)
        {
            _carDal.Update(car);
        }
        public List<Car> GetByBrand(int brandId)
        {
            return _carDal.GetByBrand(brandId);
        }
    }
}
