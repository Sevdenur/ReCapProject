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
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            foreach (var car in carManager.GetCarsByBrandId(2))
            {
                Console.WriteLine(car.CarId + " " + car.Description + " Marka ID:  " + car.BrandId);
            }

            foreach (var car in carManager.GetCarsByColorId(3))
            {
                Console.WriteLine(car.CarId + car.Description +  " Color ID " + car.ColorId);
            }

            CarManager carManager1 = new CarManager(new EfCarDal());

            carManager1.Add(new Car
            {
                CarId = 6,
                BrandId = 5,
                ColorId = 2,
                DailyPrice = 485,
                ModelYear = "2013",
                Description = "Astra Dizel Manuel"
            });
        }
    }
}
