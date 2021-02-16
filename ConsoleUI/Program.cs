using Business.Concrete;
using DataAccess.Concrete.InMemory;
using DataAccess.Concrete.EntityFramework;
using System;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            GetCarDetailsTest();
        }
        private static void BrandListed()
        {
            Console.WriteLine("--------------All brands are listed-------------");
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
        }
        private static void GetCarDetailsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Console.WriteLine(string.Format("{0,-5} | {1,-10} | {2,-20} | {3,-10} | {4,-5} | {5,-5}", 
                "ID", "Brand Name", "Car Name", "Model Year", "Color", "Daily Price"));

            foreach (var item in carManager.GetCarDetails())
            {
                Console.WriteLine(string.Format("{0,-5} | {1,-10} | {2,-20} | {3,-10} | {4,-5} | {5,-5}", 
                    item.CarId, item.BrandName, item.CarName, item.ModelYear, item.ColorName, item.DailyPrice));
            }
        }
        private static void AddCarTest()
        {
            CarManager carManager1 = new CarManager(new EfCarDal());
            carManager1.Add(new Car
            {               
                BrandId = 5,
                ColorId = 2,
                DailyPrice = 480,
                ModelYear = "2015",
                Description = "Astra Dizel Manuel"
            });
        }
        private static void CarsDescriptionTest()
        {
            Console.WriteLine("--------------------All Cars Listed-----------------------");
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
            Console.WriteLine("-------------------Cars listed by Brand Id------------------------");
            foreach (var car in carManager.GetCarsByBrandId(2))
            {
                Console.WriteLine(car.CarId + " " + car.Description + " Marka ID:  " + car.BrandId);
            }
            Console.WriteLine("--------------Cars listed by Color Id----------------------------");
            foreach (var car in carManager.GetCarsByColorId(3))
            {
                Console.WriteLine(car.CarId + car.Description + " Color ID " + car.ColorId);
            }
        }
    }
}
