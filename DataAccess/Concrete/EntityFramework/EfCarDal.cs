using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, DbRecapContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (DbRecapContext context = new DbRecapContext())
            {
                var result = from c in context.Cars
                    join b in context.Brands
                        on c.BrandId equals b.BrandId
                    join co in context.Colors
                        on c.ColorId equals co.ColorId

                    select new CarDetailDto
                    {
                        CarId = c.CarId,
                        BrandName = b.BrandName,
                        ColorName = co.ColorName,
                        ModelYear = c.ModelYear,
                        DailyPrice = c.DailyPrice,
                        BrandId = b.BrandId,
                        ColorId = co.ColorId,
                        Description = c.Description,
                        ImagePath = (from m in context.CarImages where m.CarId == c.CarId select m.ImagePath).FirstOrDefault()
                    };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsByColorAndByBrand(int colorId, int brandId)
        {
            using (DbRecapContext context = new DbRecapContext())
            {
                var result = from c in context.Cars
                    join b in context.Brands
                        on c.BrandId equals b.BrandId
                    join co in context.Colors
                        on c.ColorId equals co.ColorId
                    where co.ColorId == colorId & b.BrandId == brandId
                    select new CarDetailDto
                    {
                        CarId = c.CarId,
                        BrandName = b.BrandName,
                        ColorName = co.ColorName,
                        ModelYear = c.ModelYear,
                        DailyPrice = c.DailyPrice,
                        BrandId = b.BrandId,
                        ColorId = co.ColorId,
                        Description = c.Description,
                        ImagePath = (from m in context.CarImages where m.CarId == c.CarId select m.ImagePath).FirstOrDefault()
                    };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsByCarId(int carId)
        {
            using (DbRecapContext context = new DbRecapContext())
            {
                var result = from c in context.Cars
                    join b in context.Brands
                        on c.BrandId equals b.BrandId
                    join co in context.Colors
                        on c.ColorId equals co.ColorId
                    where c.CarId == carId
                    select new CarDetailDto
                    {
                        CarId = c.CarId,
                        BrandName = b.BrandName,
                        ColorName = co.ColorName,
                        ModelYear = c.ModelYear,
                        DailyPrice = c.DailyPrice,
                        BrandId = b.BrandId,
                        ColorId = co.ColorId,
                        Description = c.Description,
                        ImagePath = (from m in context.CarImages where m.CarId == c.CarId select m.ImagePath).FirstOrDefault()
                    };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarsByBrandId(int BrandId)
        {
            using (DbRecapContext context = new DbRecapContext())
            {
                var result = from car in context.Cars
                    join brand in context.Brands
                        on car.BrandId equals brand.BrandId
                    join color in context.Colors
                        on car.ColorId equals color.ColorId
                    where car.BrandId == BrandId
                    select new CarDetailDto
                    {
                        ColorName = color.ColorName,
                        Description = car.Description,
                        BrandName = brand.BrandName,
                        DailyPrice = car.DailyPrice,
                        CarId = car.CarId,
                        ModelYear = car.ModelYear
                    };

                return result.ToList();
            }
        }
        public List<CarDetailDto> GetCarsByColorId(int ColorId)
        {
            using (DbRecapContext context = new DbRecapContext())
            {
                var result = from car in context.Cars
                    join brand in context.Brands
                        on car.BrandId equals brand.BrandId
                    join color in context.Colors
                        on car.ColorId equals color.ColorId
                    where car.ColorId == ColorId
                    select new CarDetailDto
                    {
                        ColorName = color.ColorName,
                        Description = car.Description,
                        BrandName = brand.BrandName,
                        DailyPrice = car.DailyPrice,
                        CarId = car.CarId,
                        ModelYear = car.ModelYear
                    };

                return result.ToList();
            }
        }
    }
}
