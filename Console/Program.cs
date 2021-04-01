using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.Entity.Framework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)

        {
            //ColorTest();
            //BrandTest();
            CarTest();

        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            carManager.Add(new Car { BrandId = 1, ColorId = 1, ModelYear = 2020, DailyPrice = 100, CarName = "A6 Diesel" });

            foreach (var car in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine(car.CarName);
            }
            foreach (var car in carManager.GetCarsByColorId(3))
            {
                Console.WriteLine(car.CarName);
            }
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.CarName + " " + car.BrandName + " " + car.ColorName + " " + car.DailyPrice);
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
            Console.WriteLine("Brand data added");

            foreach (Brand brandd in brandManager.GetAll())
            {
                Console.WriteLine("--------------------");
                Console.WriteLine("Brand Name:" + brandd.BrandName);
                Console.WriteLine("--------------------");
            }
            var brand = brandManager.GetById(1);
            Console.WriteLine(brand.BrandName + " GetById method worked");

            brandManager.Delete(brand1);
            Console.WriteLine("Brand data has been deleted");
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Color color1 = new Color
            {
                ColorName = "Red"
            };
            colorManager.Add(color1);
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName + "/" + color.ColorId);

            }
            var renk = colorManager.GetById(1);
            Console.WriteLine(renk.ColorName + " GetById method worked.");
            colorManager.Delete(color1);
            Console.WriteLine("Color data has been deleted");
        }
    }
}
