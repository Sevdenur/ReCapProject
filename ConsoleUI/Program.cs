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
            //BrandTest();
            ColorTest();
            //CarTest();
        }
      
        private static void GetCarDetailsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Console.WriteLine(string.Format("{0,-5} | {1,-10} | {2,-25} | {3,-10} | {4,-5} | {5,-5}", 
                "ID", "Brand Name", "Car Name", "Model Year", "Color", "Daily Price"));

            foreach (var item in carManager.GetCarDetails())
            {
                Console.WriteLine(string.Format("{0,-5} | {1,-10} | {2,-25} | {3,-10} | {4,-5} | {5,-5}", 
                    item.CarId, item.BrandName, item.CarName, item.ModelYear, item.ColorName, item.DailyPrice));
            }
        }
        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            //Yeni araç ekleme
            carManager.Add(new Car
            {
                BrandId = 8,
                ColorId = 1,
                DailyPrice = 600,
                ModelYear = "2019",
                Description = "Elentra Benzin Otomatik"
            });
            //Araç silme ve güncelleme
            carManager.Delete(new Car { CarId = 1009 });
            carManager.Update(new Car { CarId = 1015, BrandId = 17, ColorId = 3, DailyPrice = 485, ModelYear = "2017", Description = "Octavia Benzin Manuel" });
            //Araçların tümünün ve marka/renk id'ye göre listelenmesi
            Console.WriteLine("--------------------All Cars Listed-----------------------");
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
        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            //Yeni Marka Ekleme
            brandManager.Add(new Brand
            {
                BrandName = "Skoda"
            });
            //Marka Silme ve Güncelleme
            brandManager.Update(new Brand { BrandId = 9, BrandName = "Tesla" });
            brandManager.Delete(new Brand {BrandId = 16 });
            //Markaların tümünün ve ID'ye göre listelenmesi
            Console.WriteLine("--------------All brands listed-------------");
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
            Console.WriteLine("--------------Brands listed by ID-------------");
            Console.WriteLine(brandManager.GetById(4).BrandName);
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            //Yeni renk ekleme
            colorManager.Add(new Color
            {
                ColorName = "Kırmızı"
            });
            //Renk silme ve güncelleme
            colorManager.Update(new Color { ColorId = 5, ColorName = "Lacivert" });
            colorManager.Delete(new Color { ColorId = 7 });
            //Renklerin tümünün ve ID'ye göre istenen rengin listelenmesi
            Console.WriteLine("--------------All colors listed-------------");
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }
            Console.WriteLine("--------------Colors listed by ID-------------");
            Console.WriteLine(colorManager.GetById(2).ColorName);       
        }
    }
}
