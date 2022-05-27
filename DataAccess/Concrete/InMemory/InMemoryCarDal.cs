using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal:ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId = 1,CategoryId = 1,BrandId = 2,ColorId = 1,DailyPrice = 100000,
                    ModelYear = "2017",Description = "Ikinci El 2017 model BMW 80000 km de"},
                new Car{CarId = 2,CategoryId = 1,BrandId = 2,ColorId = 2,DailyPrice = 110000,
                    ModelYear = "2019",Description = "Ikinci El 2019 model BMW 60000  km de."},
                new Car{CarId = 3,CategoryId = 2,BrandId = 2,ColorId = 1,DailyPrice = 90000,
                    ModelYear = "2017",Description = "Ikinci El 2017 model Mercedes 45000 km de"},
                new Car{CarId = 4,CategoryId = 2,BrandId = 1,ColorId = 2,DailyPrice = 120000,
                    ModelYear = "2016",Description = "Ikinci El 2016 model Mercedes 35000 km de"},
                new Car{CarId = 5,CategoryId = 1,BrandId = 1,ColorId = 1,DailyPrice = 115000,
                    ModelYear = "2016",Description = "Ikinci El 2016 model BMW 25000 km de"},
            };
        }

        public List<Car> GetAll()
        {
            return _cars;
        }
        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            carToUpdate.CategoryId = car.CategoryId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.BrandId == car.BrandId);
            _cars.Remove(carToDelete);
        }

        public List<CarDetailDto> GetCarsByBrandId(int BrandId)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarsByColorId(int ColorId)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetailsByColorAndByBrand(int colorId, int brandId)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetailsByCarId(int carId)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int categoryId)
        {
            return _cars.Where(p => p.CategoryId == categoryId).ToList();
        }

    }
}
