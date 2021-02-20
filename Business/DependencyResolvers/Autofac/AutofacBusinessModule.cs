using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Conrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;

using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();
            builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();

            builder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance();
            builder.RegisterType<EfBrandDal>().As<IBrandDal>().SingleInstance();

            builder.RegisterType<RentalManager>().As<IRentalService>().SingleInstance();
            builder.RegisterType<EfRentalDal>().As<IRentalDal>().SingleInstance();

            builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance();

         

            var assembly = System.Reflection.Assembly.GetExecutingAssembly(); //Çalışan uygulamaları yakala
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces() // Yukarıdaki kayıtlı snıflar için, içlerinde implemente edilmiş interfaceleri bul
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector() //bunlar için AspectInterceptorSelector u çağırır ve Bir Aspect varmı bakar. Yani metodun başına [Köşeli parantezle yazdıklarımız]
                }).SingleInstance();
        }
    }
}
