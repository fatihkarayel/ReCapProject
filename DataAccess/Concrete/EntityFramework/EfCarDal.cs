using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entitites.Concrete;
using Entitites.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, DBCarContext>, ICarDal
    {
        //public void Add(Car entity)
        //{
        //    using (DBCarContext context = new DBCarContext())
        //    {
        //        var addedEntity = context.Entry(entity); //referansı yakala
        //        addedEntity.State = EntityState.Added; //o eklenecek nesne
        //        context.SaveChanges(); //ekle
        //    };
        //}

        //public void Delete(Car entity)
        //{
        //    using (DBCarContext context = new DBCarContext())
        //    {
        //        var deletedEntity = context.Entry(entity);
        //        deletedEntity.State = EntityState.Deleted;
        //        context.SaveChanges();
        //    };
        //}

        //public Car Get(Expression<Func<Car, bool>> filter)
        //{
        //    using (DBCarContext context = new DBCarContext())
        //    {
        //        return context.Set<Car>().SingleOrDefault(filter);
        //    };
        //}

        //public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        //{
        //    using (DBCarContext context = new DBCarContext())
        //    {
        //        //Eğer filtre göndermemişse tüm veriyi getir. filtre vermişse bunu filtreler
        //        return filter == null
        //            ? context.Set<Car>().ToList()
        //            : context.Set<Car>().Where(filter).ToList();
        //    }
        //}

        //public void Update(Car entity)
        //{
        //    using (DBCarContext context = new DBCarContext())
        //    {
        //        var updatedEntity = context.Entry(entity);
        //        updatedEntity.State = EntityState.Modified;
        //        context.SaveChanges();
        //    };
        //}
        public List<CarDetailDTO> GetCarDetails()
        {
            using (DBCarContext context = new DBCarContext())
            {

                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join cl in context.Colors
                             on c.ColorId equals cl.Id
                             select new CarDetailDTO
                             {
                                 CarId = c.Id,
                                 Name = c.Name,
                                 BrandName = b.Name,
                                 ColorName = cl.Name,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description

                             };
                return result.ToList();

            };
        }
    }
}
