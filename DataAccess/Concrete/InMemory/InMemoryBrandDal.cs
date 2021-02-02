using DataAccess.Abstarct;
using Entitites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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
                new Brand {BrandId=1, BrandName="Siyah"},
                new Brand {BrandId=2, BrandName="Beyaz"},
                new Brand {BrandId=3, BrandName="Kırmızı"}
            };
        }
        public void Add(Brand brand)
        {
            brand.BrandId = _brands.Last().BrandId + 1;//listedeki son id nin üstüne +1 yapıyoruz. Bu kısım DB tarafında AutoIncrement özelliği ile de yönetilebilir. Ama inMemory olunca burada yapıyoruz.
           
            _brands.Add(brand);
            Console.WriteLine("Marka silindi");
        }

        public void Delete(Brand brand)
        {
            Brand brandToDelete = _brands.SingleOrDefault(b => b.BrandId == brand.BrandId);
            _brands.Remove(brandToDelete);
            Console.WriteLine("Marka silindi");
        }

        public List<Brand> GetAll()
        {
            Console.WriteLine("Marka Listesi:\n---------------");
            return _brands;
        }

        public Brand GetById(int brandId)
        {
            Brand brandToGetByID = _brands.SingleOrDefault(b=> b.BrandId==brandId);
            return brandToGetByID;
        }

        public void Update(Brand brand)
        {
            Brand brandToUpdate = _brands.SingleOrDefault(b=> b.BrandId == brand.BrandId);
            brandToUpdate.BrandName = brand.BrandName;
        }
    }
}
