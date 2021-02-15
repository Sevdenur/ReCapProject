using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentCarDbContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentCarDbContext context = new RentCarDbContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join d in context.Colors
                             on c.ColorId equals d.ColorId
                             select new CarDetailDto
                             {
                                 BrandName = b.BrandName,
                                 CarName = c.Description,
                                 ColorName = d.ColorName,
                                 DailyPrice = c.DailyPrice
                             };
                return result.ToList();
            }
        }
    }
}
