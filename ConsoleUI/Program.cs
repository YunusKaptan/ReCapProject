using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // GetCarDetails();

            // AddUser();

            CheckRentalManager();
        }

        private static void CheckRentalManager()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.Add(new Rental
                {CarId = 2, CustomerId = 2, RentDate = DateTime.Now.AddDays(-2), ReturnDate = null});
            Console.WriteLine(result.Message);
        }

        private static void AddUser()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Add(new User
            { Id = 8, FirstName = "Agata", LastName = "Milewska", EMail = "Agata@gmail.com", Password = "12345" });
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
