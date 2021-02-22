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
            //UserTest();
            //RentalTest();
            GetRentalDetailsTest();
        }

        private static void GetRentalDetailsTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var rental = rentalManager.GetRentalDetails();
            Console.WriteLine("-------------------------RENTAL DETAİL LİST------------------------");
            if (rental.Success)
            {
                foreach (var item in rental.Data)
                {
                    Console.WriteLine(string.Format("{0,-5} | {1,-10} | {2,-25} | {3,-10} | {4,-10} | {5,-20} | {6,-20} | {7,-20}",
                        item.RentalId, item.BrandName, item.CarDescription, item.UserFirstName, item.UserLastName, item.CompanyName, item.RentDate, item.ReturnDate));
                }
            }
            else
            {
                Console.WriteLine(rental.Message);
            }
        }

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var rental = rentalManager.Add(new Rental
            {
                CarId = 1,
                CustomerId = 4,
                RentDate = DateTime.Now,
                ReturnDate = new DateTime(2021,03,01)

            });
            Console.WriteLine(rental.Message);
        }

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var useradd = userManager.Add(new User
            {
                FirstName = "Nur",
                LastName = "Demirel",
                Email = "demirel@gmail.com",
                Password = "1234"
            });
            Console.WriteLine(useradd.Message);

            var result = userManager.GetAll();
            if (result.Success)
            {
                foreach (var user in result.Data)
                {
                    Console.WriteLine(string.Format("{0,-5} | {1,-10} | {2,-10} | {3,-15} | {4,-5}",
                        user.UserId, user.FirstName, user.LastName, user.Email, user.Password));
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void GetCarDetailsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("-----------------------CAR DETAİL LİST--------------------------");
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
    }
}
