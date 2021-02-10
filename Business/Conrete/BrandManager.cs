using Business.Abstract;
using DataAccess.Abstarct;
using Entitites.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Conrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        public void Add(Brand brand)
        {
            _brandDal.Add(brand);
            Console.WriteLine("Marka Eklendi: " + brand.Name);
        }

        public void Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            Console.WriteLine("Marka Silindi: " + brand.Name);
        }

        public List<Brand> GetAllBrand()
        {
            return _brandDal.GetAll();
        }

        public Brand GetById(int brandId)
        {
            //select * from dbo.Categories where Id=3
            return _brandDal.Get(b=> b.Id==brandId);
        }

        public void Update(Brand brand)
        {
            _brandDal.Update(brand);
        }
    }
}
