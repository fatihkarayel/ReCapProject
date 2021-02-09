using Business.Conrete;
using DataAccess.Concrete.EntityFramework;
using Entitites.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            //BrandManager brandManager = new BrandManager(new EfBrandDal());

            bool loop = true;
            while (loop)
            {
                Console.Clear();
                Console.WriteLine("MENU");
                Console.WriteLine("------------------------");
                Console.WriteLine("[1] List All Cars");
                Console.WriteLine("[2] Find a car by Id");
                Console.WriteLine("[3] List a car by Brand");
                Console.WriteLine("[4] Add a new car");
                Console.WriteLine("[5] Update a car's info");
                Console.WriteLine("[6] Delete a car");
                Console.WriteLine("[99] Exit");
                Console.WriteLine("\nBir İşlem seçiniz.....");
                int choise = Convert.ToInt32(Console.ReadLine());

                switch (choise)
                {
                    case 1:
                        GetAllCars(carManager);
                        Console.ReadKey();
                        break;
                    case 2:
                        GetCarById(carManager);
                        Console.ReadKey();
                        break;
                    case 3:
                        GetCarsByBrand(carManager);
                        Console.ReadKey();
                        break;
                    case 4:
                        AddCar(carManager);
                        Console.ReadKey();
                        break;
                    case 5:
                        Update(carManager);
                        Console.ReadKey();
                        break;
                    case 6:
                        DeleteCar(carManager);
                        Console.ReadKey();
                        break;
                    case 99:
                        Console.WriteLine("Hope you enjoy your program.\nSee you again...");
                        loop = false;
                        break;

                    default:
                        break;
                }
            }
        }
        private static void AddCar(CarManager carManager)
        {
            Console.WriteLine("Arabanın Adı? ");
            string name = Console.ReadLine();

            Console.WriteLine("Brand Id? ");
            int brandId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Color Id? ");
            int colorId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Model Yıl? ");
            int modelYear = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Günlük Kiralama Ücreti? ");
            decimal dailyPrice = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Açıklama? ");
            string description = Console.ReadLine();

            carManager.Add(new Car {Name= name, BrandId = brandId, ColorId = colorId, ModelYear = modelYear, Description= description, DailyPrice = dailyPrice});

        }
        private static void DeleteCar(CarManager carManager)
        {
            GetAllCars(carManager);
            Console.WriteLine("Silinecek aracın Id değeri? ");
            int carToDelete = Convert.ToInt32(Console.ReadLine());
            Car car = carManager.GetById(carToDelete);

            carManager.Delete(new Car { Id = carToDelete });
            Console.WriteLine("{0} Id li, {1} markalı araç silindi!" , carToDelete, car.BrandId);
        }
        private static void GetAllCars(CarManager carManager)
        {
            Console.WriteLine("ID\tName\tBrand\tColor\tModel\tPrice\tDesc");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}", car.Id,car.Name,car.BrandId,car.ColorId,car.ModelYear,car.DailyPrice,car.Description);
            }
            
        }
        private static void GetCarById(CarManager carManager)
        {
            Console.WriteLine("Araç Id? ");
            int carId = Convert.ToInt32(Console.ReadLine());
            Car car = carManager.GetById(carId);
            Console.WriteLine("Model Yıl: " + car.ModelYear);
            Console.WriteLine("Renk: " + car.ColorId);
            Console.WriteLine("Marka: " + car.BrandId);
            Console.WriteLine("Desc: " + car.Description);
            Console.WriteLine("Fiyat: " + car.DailyPrice);

        }
        private static void Update(CarManager carManager)
        {
            Console.WriteLine("Araç Id? ");
            int carId = Convert.ToInt32(Console.ReadLine());
            Car car = carManager.GetById(carId);
            Console.WriteLine("ARAÇ BİLGİLERİ");
            Console.WriteLine("Model Yıl: " + car.ModelYear);
            Console.WriteLine("Renk: " + car.ColorId);
            Console.WriteLine("Marka: " + car.BrandId);
            Console.WriteLine("Desc: " + car.Description);
            Console.WriteLine("Fiyat: " + car.DailyPrice);



            Console.WriteLine("Yeni Brand Id? ");
            int brandId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Yeni Color Id? ");
            int colorId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Yeni Model Yıl? ");
            int modelYear = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Yeni Günlük Kiralama Ücreti? ");
            decimal dailyPrice = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Yeni Açıklama? ");
            string description = Console.ReadLine();
            carManager.Update(new Car { Id = carId, BrandId = brandId, ColorId = colorId, ModelYear = modelYear, Description = description, DailyPrice = dailyPrice });
            Console.WriteLine("Araç güncellendi.");

        }
        private static void GetCarsByBrand(CarManager carManager)
        {
            Console.WriteLine("BrandId? ");
            int carsToGetByBrand = Convert.ToInt32(Console.ReadLine());
            ;
            foreach (var car in carManager.GetCarsByBrandId(carsToGetByBrand))
            {
                Console.WriteLine(
                    "ID: " + car.Id + " | " +
                    "Brand: " + car.BrandId + " | " +
                    "Color: " + car.ColorId + " | " +
                    "Model Year: " + car.ModelYear + " | " +
                    "Desc: " + car.Description + " | " +
                    "Price: " + car.DailyPrice);
            }
        }
    }
}
