using DataAccess.Abstarct;
using Entitites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car {Id=1, BrandId=1, ColorId=1, ModelYear=2020, DailyPrice=2000, Description="Düşük yakıt tüketimi, Dizel motor ve Otomatik Şanzıman"},
                new Car {Id=2, BrandId=1, ColorId=1, ModelYear=2019, DailyPrice=1500, Description= "Dizel motor ve Manuel Şanzıman"},
                new Car {Id=3, BrandId=2, ColorId=2, ModelYear=2019, DailyPrice=1500, Description="Düşük yakıt tüketimi, Benzinli motor ve Otomatik Şanzıman"},
                new Car {Id=4, BrandId=2, ColorId=3, ModelYear=2018, DailyPrice=1000, Description="Benzinli motor ve Otomatik Şanzıman"}
            };
        }
        public void Add(Car car)
        {
            car.Id = _cars.Last().Id + 1;
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c=> c.Id==car.Id);
            _cars.Remove(carToDelete);

        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetByBrand(int brandId)
        {
            return _cars.Where(c=> c.BrandId==brandId).ToList();
        }

        public Car GetById(int carId)
        {
            Car carById = _cars.SingleOrDefault(c => c.Id == carId);
            return carById ;
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c=> c.Id == car.Id);
            carToUpdate.BrandId =car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
