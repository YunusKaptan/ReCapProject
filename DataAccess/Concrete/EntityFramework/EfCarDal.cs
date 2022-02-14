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
                var result = from p in context.Cars
                    join c in context.Colors
                        on p.CarId equals c.ColorId
                    join b in context.Brands
                        on p.CarId equals b.BrandId
                    select new CarDetailDto
                    { 
                        CarId = p.CarId,
                        BrandName = b.BrandName,
                        ColorName = c.ColorName,
                        Description = p.Description
                    };
                return result.ToList();
            }
        }
    }
}
