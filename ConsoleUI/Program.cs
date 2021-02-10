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
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

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
                Console.WriteLine("[7] List Brands");
                Console.WriteLine("[8] Add new Brand");
                Console.WriteLine("[9] List Colors");
                Console.WriteLine("[10] Add new Color");
                Console.WriteLine("[11] Delete Brand");
                Console.WriteLine("[99] Exit");
                Console.WriteLine("\nBir İşlem seçiniz.....");
                int choise = Convert.ToInt32(Console.ReadLine());

                switch (choise)
                {
                    case 1:
                        GetCarDetails(carManager);
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
                    case 7:
                        GetAllBrand(brandManager);
                        Console.ReadKey();
                        break;
                    case 8:
                        AddBrand(brandManager);
                        Console.ReadKey();
                        break;
                    case 9:
                        GetAllColor(colorManager);
                        Console.ReadKey();
                        break;
                    case 10:
                        AddColor(colorManager);
                        Console.ReadKey();
                        break;
                    case 11:
                        DeleteBrand(brandManager);
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
        private static void AddBrand(BrandManager brandManager)
        {
            GetAllBrand(brandManager);
            Console.WriteLine("Bir Marka Adı giriniz: ");
            string name = Console.ReadLine();
            brandManager.Add(new Brand {Name=name });
        }
        private static void DeleteBrand(BrandManager brandManager) 
        {
            GetAllBrand(brandManager);
            Console.WriteLine("Silinecek Marka Id değerini girin: ");
            int deletedBrand = Convert.ToInt32(Console.ReadLine());
            Brand brand = brandManager.GetById(deletedBrand);
            brandManager.Delete(brand); //new Brand {Id=deletedBrand }

        }

        private static void GetAllBrand(BrandManager brandManager)
        {
            Console.WriteLine("Marka Listesi");
            foreach (var brand in brandManager.GetAllBrand())
            {
                Console.WriteLine("[{0}] {1}",brand.Id, brand.Name);
            }
        }
        private static void AddColor(ColorManager colorManager)
        {
            GetAllColor(colorManager);
            Console.WriteLine("Bir Renk Adı giriniz: ");
            string name = Console.ReadLine();
           colorManager.Add(new Color { Name = name });
        }
        private static void GetAllColor(ColorManager colorManager)
        {
            Console.WriteLine("Renk Listesi");
            foreach (var color in colorManager.GetAllColor())
            {
                Console.WriteLine("[{0}] {1}", color.Id, color.Name);
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
            GetCarDetails(carManager);
            Console.WriteLine("Silinecek aracın Id değeri? ");
            int carToDelete = Convert.ToInt32(Console.ReadLine());
            Car car = carManager.GetById(carToDelete);

            carManager.Delete(new Car { Id = carToDelete });
            Console.WriteLine("{0} Id li, {1} markalı araç silindi!" , carToDelete, car.BrandId);
        }
        private static void GetCarDetails(CarManager carManager)
        {
            Console.WriteLine("ID\tName\tBrand\tColor\tYıl\tPrice\tDesc");
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}", car.CarId,car.Name,car.BrandName,car.ColorName,car.ModelYear,car.DailyPrice,car.Description);
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
