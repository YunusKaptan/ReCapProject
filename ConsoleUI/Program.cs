using System;
using Business.Concrete;
using Business.Constants;
using Core.Entities.Concrete;
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
            //CheckRentalManager();
            //AddCustomer();
            
        }

        private static void AddCustomer()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.Add(new Customer {UserId = 8, CompanyName = "Olx"});
            Console.WriteLine(result.Message);
        }



        private static void CheckRentalManager()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.Add(new Rental
            { CarId = 2, CustomerId = 2, RentDate = DateTime.Now.AddDays(-2), ReturnDate = null });
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
