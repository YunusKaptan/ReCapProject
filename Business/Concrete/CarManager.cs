using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(p => p.BrandId ==id );
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(p => p.ColorId == id);
        }

        public void Add(Car car)
        {
            if (car.Description.Length < 2)
            {
                Console.WriteLine("Car description must be at least 2 characters");
            }
            else if (car.DailyPrice <= 0)
            {
                Console.WriteLine("Car daily price must be greater than 0.");
            }
            else
            {
                _carDal.Add(car);
                Console.WriteLine("Car successfully Added!");
            }
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
            Console.WriteLine("Car successfully updated!");
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
            Console.WriteLine("Car successfully  deleted!");
        }
    }
}
