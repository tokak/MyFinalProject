using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class program
    {
        static void Main(string[] args)
        {
            //GetAllProductTest();

            //GetCategoriTest();

            //GetAllProductDelailDtoTest();
        }

        private static void GetAllProductDelailDtoTest()
        {
            //İlişkili tablodan veri çekme
            ProductManager productManager = new ProductManager(new EfProductDal());
            var result = productManager.GetProductDetails();
            foreach (var item in result.Data)
            {
                if (result.Success==true)
                {
                    Console.WriteLine($"{item.ProductId} {item.ProductName} {item.CategoryName} {item.UnitsInStock}");
                }
                else
                {
                    Console.WriteLine($"{result.Message}");
                }
            }
        }

        private static void GetCategoriTest()
        {
            //Categorileri listeleme
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

            foreach (var item in categoryManager.GetAll().Data)
            {
                Console.WriteLine($"{item.CategoryName}");
            }
            Console.WriteLine("-------------------------");
            var getCategori = categoryManager.GetById(5);
            Console.WriteLine(getCategori.Data.CategoryName);
        }

        private static void GetAllProductTest()
        {
            //Ürünle, fiyatlarına göre listeleme
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var item in productManager.GetByUnitPrice(4, 1000).Data)
            {
                Console.WriteLine($"{item.ProductName} {item.UnitPrice} {item.CategoryId}");
            }
        }
    }
}