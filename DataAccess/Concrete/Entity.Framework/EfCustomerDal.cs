using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
namespace DataAccess.Concrete.Entity.Framework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, MyRecapContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (MyRecapContext context = new MyRecapContext())
            {
                var result = from customer in context.Customers
                             join user in context.Users on customer.UserId equals user.UserId
                             select new CustomerDetailDto()
                             {
                                 CompanyName = customer.CompanyName,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 Id = customer.CustomerId
                             };
                return result.ToList();
            }
        }


    }
}
