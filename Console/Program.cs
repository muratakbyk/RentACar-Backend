using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.Entity.Framework;
using Entities.Concrete;
using Core.Utilities.Results;
using System;
using Business.Constants;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)

        {
            //ColorTest();
            //BrandTest();
            //CarTest();
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            
            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine(customer.CompanyName + customer.CustomerId);

            }



        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.CarName);

            }

        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Brand brand1 = new Brand
            {
                BrandName = "Mercedes"
            };

            brandManager.Add(brand1);
            foreach(var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }


        }
  


        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Color color1 = new Color
            {
                ColorName = "Red"
            };
            colorManager.Add(color1);
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName + "/" + color.ColorId);

            }
            
           
        }
    }
}

