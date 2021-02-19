using DataAccess.Abstract;
using Entitites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryBrandDal : IBrandDal
    {
        List<Brand> _brands;
        public InMemoryBrandDal()
        {
            _brands = new List<Brand>
            {
                new Brand {Id=1, Name="Siyah"},
                new Brand {Id=2, Name="Beyaz"},
                new Brand {Id=3, Name="Kırmızı"}
            };
        }
        public void Add(Brand brand)
        {
            brand.Id = _brands.Last().Id + 1;//listedeki son id nin üstüne +1 yapıyoruz. Bu kısım DB tarafında AutoIncrement özelliği ile de yönetilebilir. Ama inMemory olunca burada yapıyoruz.
           
            _brands.Add(brand);
            Console.WriteLine("Marka silindi");
        }

        public void Delete(Brand brand)
        {
            Brand brandToDelete = _brands.SingleOrDefault(b => b.Id == brand.Id);
            _brands.Remove(brandToDelete);
            Console.WriteLine("Marka silindi");
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Brand> GetAll()
        {
            Console.WriteLine("Marka Listesi:\n---------------");
            return _brands;
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            return _brands;
        }

        public Brand GetById(int brandId)
        {
            Brand brandToGetByID = _brands.SingleOrDefault(b=> b.Id==brandId);
            return brandToGetByID;
        }

        public void Update(Brand brand)
        {
            Brand brandToUpdate = _brands.SingleOrDefault(b=> b.Id == brand.Id);
            brandToUpdate.Name = brand.Name;
        }
    }
}
