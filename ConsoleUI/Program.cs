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
            UserManager userManager = new UserManager(new EfUserDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

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
                Console.WriteLine("[12] Add new User");
                Console.WriteLine("[13] List Users");
                Console.WriteLine("[14] Delete Users");
                Console.WriteLine("[15] Rent a Car");
                Console.WriteLine("[16] List Rentals");
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
                    case 12:
                        AddUser(userManager);
                        Console.ReadKey();
                        break;
                    case 13:
                        GetAllUsers(userManager);
                        Console.ReadKey();
                         break;
                    case 14:
                        DeleteUser(userManager);
                        Console.ReadKey();
                        break;
                    case 15:
                        RentCar(rentalManager);
                        Console.ReadKey();
                        break;
                    case 16:
                        GetRentals(rentalManager);
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

        private static void RentCar(RentalManager rentalManager)
        {
            GetRentals(rentalManager);
            Console.WriteLine("Kiralanacak Aracın id değerini girin.");
            int carId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Müşteri Id değerini girin. ");
            int customerId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Kira başlangıç tarihini girin. ");
            DateTime rentDate= Convert.ToDateTime(Console.ReadLine());
            var result = rentalManager.Add(new Rental { CarId = carId, CustomerId = customerId, RentDate = rentDate });
            Console.WriteLine(result.Message);
        }
        private static void GetRentals(RentalManager rentalManager)
        {
            var result = rentalManager.GetRentalDetails();
            if (result.Success)
            {
                foreach (var rental in result.Data)
                {
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", rental.Id, rental.CarName, rental.FirstName, rental.LastName, rental.RentDate, rental.ReturnDate);
                }
                Console.WriteLine(result.Message);

            }

        }
        private static void GetAllUsers(UserManager userManager)
        {
            var result = userManager.GetAll();
            if (result.Success)
            {
                foreach (var user in result.Data)
                {
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}", user.Id, user.FirstName, user.LastName, user.Email);
                }
                Console.WriteLine(result.Message);
            }
        }

        private static void AddUser(UserManager userManager)
        {
            Console.WriteLine("Adı: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Soyadı: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("E-Mail: ");
            string mail = Console.ReadLine();
            var result = userManager.Add(new User {FirstName=firstName, LastName=lastName, Email=mail });
            Console.WriteLine(result.Message);
            GetAllUsers(userManager);
        }
        private static void DeleteUser(UserManager userManager)
        {
            GetAllUsers(userManager);
            Console.WriteLine("Silinecek Kullanıcı Id değerini girin.");
            var deletedUser = Convert.ToInt32(Console.ReadLine());
            var user = userManager.GetById(deletedUser).Data;
            var result = userManager.Delete(new User {Id=user.Id });
            Console.WriteLine(result.Message);
        }

        private static void AddBrand(BrandManager brandManager)
        {
            GetAllBrand(brandManager);
            Console.WriteLine("Bir Marka Adı giriniz: ");

            string name = Console.ReadLine();
            var result = brandManager.Add(new Brand { Name = name });
            Console.WriteLine(result.Message);
            GetAllBrand(brandManager);


            //if (result.Success)
            //{
            //Console.WriteLine(result.Message);
            //}
        }
        private static void DeleteBrand(BrandManager brandManager) 
        {
            GetAllBrand(brandManager);
            Console.WriteLine("Silinecek Marka Id değerini girin: ");
            int deletedBrand = Convert.ToInt32(Console.ReadLine());
            var brand = brandManager.GetById(deletedBrand).Data;
            var result = brandManager.Delete(new Brand {Id=brand.Id}); //new Brand {Id=deletedBrand }
            Console.WriteLine(result.Message);

        }

        private static void GetAllBrand(BrandManager brandManager)
        {
            //Console.WriteLine("Marka Listesi");
            var result = brandManager.GetAllBrand();
            if (result.Success)
            {
                foreach (var brand in result.Data)
                {
                    Console.WriteLine("[{0}] {1}", brand.Id, brand.Name);                    
                }
                Console.WriteLine(result.Message);
            }

        }
        private static void AddColor(ColorManager colorManager)
        {
            GetAllColor(colorManager);
            Console.WriteLine("Bir Renk Adı giriniz: ");
            string name = Console.ReadLine();
            var result = colorManager.Add(new Color { Name = name });
            Console.WriteLine(result.Message);
        }
        private static void GetAllColor(ColorManager colorManager)
        {
            Console.WriteLine("Renk Listesi");
            var result = colorManager.GetAllColor();
            foreach (var color in result.Data)
            {
                Console.WriteLine("[{0}] {1}", color.Id, color.Name);
            }
            Console.WriteLine(result.Message);
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

            var result = carManager.Add(new Car {Name= name, BrandId = brandId, ColorId = colorId, ModelYear = modelYear, Description= description, DailyPrice = dailyPrice});
            Console.WriteLine(result.Message);


        }
        private static void DeleteCar(CarManager carManager)
        {
            GetCarDetails(carManager);
            Console.WriteLine("Silinecek aracın Id değeri? ");
            int carToDelete = Convert.ToInt32(Console.ReadLine());
            var car = carManager.GetById(carToDelete);
            var result = carManager.Delete(new Car { Id = carToDelete });
            Console.WriteLine(result.Message);
        }


        private static void GetCarById(CarManager carManager)
        {
            Console.WriteLine("Araç Id? ");
            int carId = Convert.ToInt32(Console.ReadLine());
            var result = carManager.GetById(carId);
            Car car = result.Data;
            Console.WriteLine("Model Yıl: " + car.ModelYear);
            Console.WriteLine("Renk: " + car.ColorId);
            Console.WriteLine("Marka: " + car.BrandId);
            Console.WriteLine("Desc: " + car.Description);
            Console.WriteLine("Fiyat: " + car.DailyPrice);
            Console.WriteLine(result.Message);

        }
        private static void Update(CarManager carManager)
        {
            Console.WriteLine("Araç Id? ");
            int carId = Convert.ToInt32(Console.ReadLine());
            var resultDetail = carManager.GetById(carId);
            Car car = resultDetail.Data;
            Console.WriteLine("ARAÇ BİLGİLERİ");
            Console.WriteLine("Model Yıl: " + car.ModelYear);
            Console.WriteLine("Renk: " + car.ColorId);
            Console.WriteLine("Marka: " + car.BrandId);
            Console.WriteLine("Desc: " + car.Description);
            Console.WriteLine("Fiyat: " + car.DailyPrice);
            Console.WriteLine(resultDetail.Message);


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
            var resultUpdate = carManager.Update(new Car { Id = carId, BrandId = brandId, ColorId = colorId, ModelYear = modelYear, Description = description, DailyPrice = dailyPrice });
            Console.WriteLine(resultUpdate.Message);


        }
        private static void GetCarsByBrand(CarManager carManager)
        {
            Console.WriteLine("BrandId? ");
            int carsToGetByBrand = Convert.ToInt32(Console.ReadLine());
            var result = carManager.GetCarsByBrandId(carsToGetByBrand);
            foreach (var car in result.Data)
            {
                Console.WriteLine("{0}\t {1}\t {2}\t {3}\t {4}", car.Id, car.Name, car.ModelYear, car.ColorId, car.BrandId);
            }

            Console.WriteLine(result.Message);
        }
        private static void GetCarDetails(CarManager carManager)
        {
            //Console.WriteLine("CarId? ");
            //int carsToGet = Convert.ToInt32(Console.ReadLine());
            var result = carManager.GetCarDetails();
            Console.WriteLine(result.Message);
        }
    }
}
