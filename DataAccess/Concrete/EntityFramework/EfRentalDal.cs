
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
    public class EfRentalDal : EfEntityRepositoryBase<Rental, DBCarContext>, IRentalDal
    {
        public List<RentalDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {

            using (DBCarContext context = new DBCarContext())
            {

                var result = from r in filter is null ? context.Rentals: context.Rentals.Where(filter)
                             join c in context.Cars
                             on r.CarId equals c.Id
                             join cl in context.Customers
                             on r.CustomerId equals cl.Id
                             join u in context.Users
                             on cl.UserId equals u.Id
                             select new RentalDto
                             {
                                 Id = r.Id,
                                 CarName = c.Name,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();

            };

        }
    }
}
