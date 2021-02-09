using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _CarDal;
        public CarManager(ICarDal carDal)
        {
            _CarDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.DailyPrice > 0 && (car.Description).Length > 2)
            {
                _CarDal.Add(car);
                Console.WriteLine("ekleme işlemi başarılı");
            }
            else
            {
                Console.WriteLine("Bilgileri kontrol ediniz");
            }
        }

        public List<Car> GetAll()
        {
            //iş kodları kurallar yetki kontrolleri vs.
            return _CarDal.GetAll();

        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _CarDal.GetAll(c => c.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _CarDal.GetAll(c => c.ColorId == id);
        }
    }
}
