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
    public class EfRentalDal : EfEntityRepositoryBase<Rental, MyRecapContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (MyRecapContext reCapContext = new MyRecapContext())
            {
                var result = from rental in reCapContext.Rentals
                             join car in reCapContext.Cars on rental.CarId equals car.Id
                             join customer in reCapContext.Customers on rental.CustomerId equals customer.CustomerId
                             join user in reCapContext.Users on customer.UserId equals user.UserId
                          
                                
                             /*
                             join b in reCapContext.Cars
                             on c.CarId equals b.Id
                             join cl in reCapContext.Brands
                             on b.BrandId equals cl.Id
                             join cu in reCapContext.Customers
                             on c.CustomerId equals cu.CustomerId*/

                             select new RentalDetailDto
                             {
                                 Id = rental.RentalId,
                                 CarName = car.CarName,
                                 CustomerName = user.FirstName + " " + user.LastName,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate,

                                 
                             };
                            return result.ToList();
            }
        }
    }
}
