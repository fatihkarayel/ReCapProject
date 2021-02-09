using DataAccess.Abstarct;
using Entitites.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal:IBrandDal
    {
        public void Add(Brand entity)
        {
            using (DBCarContext context = new DBCarContext())
            {
                var addedEntity = context.Add(entity);//referansı yakala
                addedEntity.State = EntityState.Added; //o eklenecek nesne
                context.SaveChanges(); //ekle
            };
        }

        public void Delete(Brand entity)
        {
            using (DBCarContext context = new DBCarContext())
            {
                var deletedEntity = context.Remove(entity);//referansı yakala
                deletedEntity.State = EntityState.Deleted; //o eklenecek nesne
                context.SaveChanges(); //ekle
            };
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            using (DBCarContext context = new DBCarContext())
            {
                return context.Set<Brand>().SingleOrDefault(filter);
            };
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            using (DBCarContext context = new DBCarContext())
            {
                //Eğer filtre göndermemişse tüm veriyi getir. filtre vermişse bunu filtreler
                return filter == null
                    ? context.Set<Brand>().ToList()
                    : context.Set<Brand>().Where(filter).ToList();
            };
        }

        public void Update(Brand entity)
        {
            using (DBCarContext context = new DBCarContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            };
        }
    }
}
