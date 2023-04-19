using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            //Oracle,Sql Server,Postgres,MongoDb
            _products = new List<Product>() {
            new  Product{ProductId=1,CategoryId=1, ProductName="Bardak",UnitPrice=15,UnitsInStock=15},
            new  Product{ProductId=2,CategoryId=1, ProductName="Kamera",UnitPrice=500,UnitsInStock=3},
            new  Product{ProductId=3,CategoryId=2, ProductName="Telefon",UnitPrice=1500,UnitsInStock=2},
            new  Product{ProductId=4,CategoryId=2, ProductName="Klavye",UnitPrice=150,UnitsInStock=65},
            new  Product{ProductId=5,CategoryId=2, ProductName="Mouse",UnitPrice=85,UnitsInStock=1}

            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = null;
            //foreach (var item in _products)
            //{
            //    if (item.ProductId==product.ProductId)
            //    {
            //        productToDelete = item;
            //        break;
            //    }
            //}
            //_products.Remove(productToDelete);

            //Linq - Language Integrated Query          her item için item.ProductId gönderilen product.Id eşit ise item eşitle 
            productToDelete = _products.SingleOrDefault(item => item.ProductId == product.ProductId);
            _products.Remove(productToDelete);

        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {

            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoriId)
        {
            //List<Product> results = null;
            //foreach (var item in _products)
            //{
            //    if (item.CategoryId==categoriId)
            //    {
            //        results.Add(item);
            //    }
            //}
            //return results;
            return _products.Where(item => item.CategoryId == categoriId).ToList();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(item => item.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;

            Console.WriteLine($"{productToUpdate.ProductName} {productToUpdate.UnitPrice} güncellendi.");
        }
    }
}
