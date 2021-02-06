using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId=1, BrandId=1, ColorId=1, DailyPrice=255, ModelYear="2015", Description="Otomatik, Dizel, Ford Focus"},
                new Car{CarId=2, BrandId=2, ColorId=2, DailyPrice=235, ModelYear="2012", Description="Manuel, Benzin, Opel Astra"},
                new Car{CarId=3, BrandId=3, ColorId=2, DailyPrice=210, ModelYear="2010", Description="Otomatik, Dizel, Renault Megane"},
                new Car{CarId=4, BrandId=4, ColorId=3, DailyPrice=152, ModelYear="2014", Description="Manuel, Benzin, Hyundai Accent"}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(c => c.CarId == carId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
