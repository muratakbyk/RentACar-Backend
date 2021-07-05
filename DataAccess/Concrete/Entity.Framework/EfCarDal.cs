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


        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (MyRecapContext reCapContext = new MyRecapContext())
            {
                var result = from c in reCapContext.Cars
                             join co in reCapContext.Colors on c.ColorId equals co.ColorId
                             join br in reCapContext.Brands on c.BrandId equals br.Id

                             /* join b in reCapContext.Brands
                              on c.BrandId equals b.Id
                              join cl in reCapContext.Colors
                              on c.ColorId equals cl.ColorId*/

                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 BrandName = br.BrandName,
                                 ColorName = co.ColorName,
                                 CarName = c.CarName,
                                 DailyPrice = (int)c.DailyPrice,
                                 ModelYear = c.ModelYear,
                                 BrandId = c.BrandId,
                                 ColorId = c.ColorId,
                                 CarImage = (from img in reCapContext.CarImages where(c.Id == img.CarId)
                                             select new CarImage { ImageId =img.ImageId,CarId=c.Id,Datee=img.Datee,ImagePath = img.ImagePath}).ToList()

                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();


            }
        }

       

    }
}