using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        /* List<Car> GetAll();
         List<Car> GetByBrandId(string brandId);
         void Add(Car car);
         void Update(Car car);
         void Delete(Car car);*/
        List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null);

    }
}
