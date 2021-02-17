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
            //ColorTest();
            //CarTest();
        }
      
        private static void GetCarDetailsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Console.WriteLine(string.Format("{0,-5} | {1,-10} | {2,-25} | {3,-10} | {4,-5} | {5,-5}", 
                "ID", "Brand Name", "Car Name", "Model Year", "Color", "Daily Price"));
            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine(string.Format("{0,-5} | {1,-10} | {2,-25} | {3,-10} | {4,-5} | {5,-5}",
                        item.CarId, item.BrandName, item.CarName, item.ModelYear, item.ColorName, item.DailyPrice));
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }
        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            //Yeni araç ekleme
            var carAdded = carManager.Add(new Car
            {
                BrandId = 3,
                ColorId = 5,
                DailyPrice = 400,
                ModelYear = "2011",
                Description = "Corolla Benzin Manuel"
            });
            Console.WriteLine(carAdded.Message);

            //Araç silme ve güncelleme
            var cardeleted = carManager.Delete(new Car { CarId = 1014 });
            Console.WriteLine(cardeleted.Message);
            var updated = carManager.Update(new Car {
                CarId = 1015, BrandId = 17, ColorId = 1, DailyPrice = 475,
                ModelYear = "2018", Description = "Octavia Benzin Otomatik"
            });
            Console.WriteLine(updated.Message);

            //Araçların tümünün ve marka/renk id'ye göre listelenmesi
            Console.WriteLine("--------------------All Cars Listed-----------------------");
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(string.Format("{0,-5} | {1,-10}", car.CarId, car.Description));
            }

            Console.WriteLine("-------------------Cars listed by Brand Id------------------------");
            foreach (var car in carManager.GetCarsByBrandId(2).Data)
            {
                Console.WriteLine(string.Format("{0,-5} | {1,-25} | {2,-10}", car.CarId, car.Description, car.BrandId));
            }

            Console.WriteLine("--------------Cars listed by Color Id----------------------------");
            foreach (var car in carManager.GetCarsByColorId(3).Data)
            {
                Console.WriteLine(string.Format("{0,-5} | {1,-25} | {2,-5}", car.CarId, car.Description, car.ColorId));
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            //Yeni Marka Ekleme
            var brandAdded = brandManager.Add(new Brand
            {
                BrandName = "Suzuki"
            });
            Console.WriteLine(brandAdded.Message);

            //Marka Silme ve Güncelleme
            var updatedBrand = brandManager.Update(new Brand { BrandId = 1017, BrandName = "BMW" });
            Console.WriteLine(updatedBrand.Message);
            var deletedBrand = brandManager.Delete(new Brand { BrandId = 2017 });
            Console.WriteLine(deletedBrand.Message);

            //Markaların tümünün ve ID'ye göre listelenmesi
            Console.WriteLine("--------------All brands listed-------------");
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }

            Console.WriteLine("--------------Brands listed by ID-------------");
            var result = brandManager.GetById(1);
            Console.WriteLine(result.Data);
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            //Yeni renk ekleme
            var colorAdded = colorManager.Add(new Color
            {
                ColorName = "Bej"
            });
            Console.WriteLine(colorAdded.Message);

            //Renk silme ve güncelleme
            var colorUpdated = colorManager.Update(new Color { ColorId = 1007, ColorName = "Mavi" });
            Console.WriteLine(colorUpdated.Message);
            var colorDeleted = colorManager.Delete(new Color { ColorId = 2007 });
            Console.WriteLine(colorDeleted.Message);

            //Renklerin tümünün ve ID'ye göre istenen rengin listelenmesi
            Console.WriteLine("--------------All colors listed-------------");
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }

            Console.WriteLine("--------------Colors listed by ID-------------");
            Console.WriteLine(colorManager.GetById(2).Data);       
        }
    }
}
