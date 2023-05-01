using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        //Burası önemli Hangi veritabanı ile çalıştıgını interface ile belirtiyoruz.
        IProductDal _producDal;

        public ProductManager(IProductDal producDal)
        {
            _producDal = producDal;
        }

        public IResult Add(Product product)
        {
            if (product.ProductName.Length<2)
            {
                return new ErrorResult(Messages.ProductNameInValid);
            }
            _producDal.Add(product);
            return new SuccessResult(Messages.ProductAdded) ;
        }

        public IDataResult<List<Product>> GetAll()
        {
            //iş kodları
            //Yetkisi Varmı

            if (DateTime.Now.Hour==12)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);    
            }

          return  new SuccessDataResult<List<Product>>(_producDal.GetAll(),Messages.ProductsListed);

        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return  new SuccessDataResult<List<Product>>(_producDal.GetAll(p=>p.CategoryId==id));
            //SuccessDataResult içerisinde List<Product> var ctor'a _producDal.GetAll(p=>p.CategoryId==id) gönderiyoruz
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_producDal.Get(p=>p.ProductId==productId));
            
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_producDal.GetAll(p=>p.UnitPrice>=min && p.UnitPrice<=max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_producDal.GetProductDetails()) ;
        }
    }
}
