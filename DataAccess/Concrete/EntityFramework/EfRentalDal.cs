using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentCarDbContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (RentCarDbContext context = new RentCarDbContext())
            {
                var result = from rental in context.Rentals
                             join car in context.Cars
                             on rental.CarId equals car.CarId
                             join customer in context.Customers
                             on rental.CustomerId equals customer.CustomerId
                             join user in context.Users on customer.UserId equals user.UserId
                             join brand in context.Brands on car.BrandId equals brand.BrandId
                             select new RentalDetailDto
                             {
                                 RentalId = rental.Id,
                                 BrandName = brand.BrandName,
                                 CarDescription = car.Description,
                                 UserFirstName = user.FirstName,
                                 UserLastName = user.LastName,
                                 CompanyName = customer.CompanyName,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}
