using System;
using Business.Concrete;
using Business.Constants;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //GetCarDetails();
            //AddUser();
            //CheckRentalManager();
            //UserGetAll();
            //AddCustomer();
            
        }

        private static void AddCustomer()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.Add(new Customer {UserId = 8, CompanyName = "Olx"});
            Console.WriteLine(result.Message);
        }

        private static void UserGetAll()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine(user.Id + "  " + user.FirstName + " " + user.LastName + " " + user.EMail + "  " +
                                  user.Password);
            }
        }

        private static void CheckRentalManager()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.Add(new Rental
            { CarId = 2, CustomerId = 2, RentDate = DateTime.Now.AddDays(-2), ReturnDate = null });
            Console.WriteLine(result.Message);
        }

        private static void AddUser()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var result = userManager.Add(new User { FirstName ="Arda",LastName = "Guler",EMail = "arda@gmail.com",Password = "arda123"});
            Console.WriteLine(result.Message);
        }

        private static void GetCarDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarId + "/" + car.ColorName + "/" + car.BrandName + "/" + car.Description);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
