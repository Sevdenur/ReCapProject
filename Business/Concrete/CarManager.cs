using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            if (car.DailyPrice > 0 && (car.Description).Length >= 2)
            {
                _CarDal.Add(car);
                return new SuccessResult(Messages.CarAdded);
            }
            else
            {
                return new ErrorResult(Messages.NameInvalid);
            }
        }

        public IResult Delete(Car car)
        {
            _CarDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
            
        }

        public IResult Update(Car car)
        {
            _CarDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        public IDataResult<List<Car>> GetAll()
        {
            //iş kodları kurallar yetki kontrolleri vs.
            return new SuccessDataResult<List<Car>>(_CarDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_CarDal.GetAll(c => c.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_CarDal.GetAll(c => c.ColorId == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_CarDal.GetCarDetails());
        }

        
    }
}
