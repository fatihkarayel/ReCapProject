using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
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
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            //aşağıdaki kural için validasyon koyduk.
            //if (brand.Name.Length<2)
            //{
            //    return new ErrorResult(Messages.BrandNameInvalid);
            //}
            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
            //Console.WriteLine("Marka Eklendi: " + brand.Name);
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
            //Console.WriteLine("Marka Silindi: " + brand.Name);
        }

        public IDataResult<List<Brand>> GetAllBrand()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),Messages.BrandsListed);
        }

        public IDataResult<Brand> GetById(int brandId)
        {
            //select * from dbo.Categories where Id=3
            return new SuccessDataResult<Brand>(_brandDal.Get(b=> b.Id==brandId),Messages.BrandDetail);
        }

        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }
    }
}
