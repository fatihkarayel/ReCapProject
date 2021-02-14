using Core.DataAccess.EntityFramework;
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
    public class EfColorDal : EfEntityRepositoryBase<Color, DBCarContext>, IColorDal
    {
        //public void Add(Color entity)
        //{
        //    using (DBCarContext context = new DBCarContext())
        //    {
        //        var addedEntity = context.Add(entity);//referansı yakala
        //        addedEntity.State = EntityState.Added; //o eklenecek nesne
        //        context.SaveChanges(); //ekle
        //    };
        //}

        //public void Delete(Color entity)
        //{
        //    using (DBCarContext context = new DBCarContext())
        //    {
        //        var deletedEntity = context.Remove(entity);//referansı yakala
        //        deletedEntity.State = EntityState.Deleted; //o eklenecek nesne
        //        context.SaveChanges(); //ekle
        //    };
        //}

        //public Color Get(Expression<Func<Color, bool>> filter)
        //{
        //    using (DBCarContext context = new DBCarContext())
        //    {
        //        return context.Set<Color>().SingleOrDefault(filter);
        //    };
        //}

        //public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        //{
        //    using (DBCarContext context = new DBCarContext())
        //    {
        //        //Eğer filtre göndermemişse tüm veriyi getir. filtre vermişse bunu filtreler
        //        return filter == null
        //            ? context.Set<Color>().ToList()
        //            : context.Set<Color>().Where(filter).ToList();
        //    };
        //}

        //public void Update(Color entity)
        //{
        //    using (DBCarContext context = new DBCarContext())
        //    {
        //        var updatedEntity = context.Entry(entity);
        //        updatedEntity.State = EntityState.Modified;
        //        context.SaveChanges();
        //    };
        //}
    }
}
