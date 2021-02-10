using Entitites.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {
        List<Brand> GetAllBrand();

        Brand GetById(int brandId);

        void Add(Brand brand);
        void Delete(Brand brand);
        void Update(Brand brand);
    }
}
