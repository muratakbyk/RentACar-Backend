using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.Entity.Framework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, MyRecapContext>, ICarDal
    {
        CarDetailDto _carDetailDto;

        public List<CarDetailDto> GetCarDetails()
        {
            using (MyRecapContext reCapContext = new MyRecapContext())
            {
                var result = from c in reCapContext.Cars
                             join b in reCapContext.Brands
                             on c.BrandId equals b.Id
                             join cl in reCapContext.Colors
                             on c.ColorId equals cl.ColorId

                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 BrandName = b.BrandName,
                                 ColorName = cl.ColorName,
                                 CarName = c.CarName,
                                 DailyPrice = (int)c.DailyPrice,
                                 ModelYear = c.ModelYear
                             };
                             return result.ToList();
            }
        }
    }
}
