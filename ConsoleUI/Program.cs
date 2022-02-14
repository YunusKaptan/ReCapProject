﻿using System;
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
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine(car.Description);
            }

            foreach (var car in carManager.GetCarsByColorId(2))
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("CAR ADD SECTION");

            Car car1 = new Car
            {
                BrandId = 1,
                ColorId = 1,
                ModelYear = "2016",
                DailyPrice = 0,
                Description = "Alfa Romeo"
            };

            carManager.Add(car1);

            Car car2 = new Car
            {
                BrandId = 1,
                ColorId = 1,
                ModelYear = "2018",
                DailyPrice = 0,
                Description = "a"
            };

            carManager.Add(car2);
        }
    }
}
