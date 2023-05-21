using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Performance;
using Core.Aspect.Autofac.Transaction;
using Core.Aspect.Autofac.Validation;
using Core.CrossCuttingCorncerns.Validation;
using Core.Utilities.Bussiness;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
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
        ICategoryService _categoryService;
        public ProductManager(IProductDal producDal, ICategoryService categoryService)
        {
            _producDal = producDal;
            _categoryService = categoryService;
        }
        //Yetkilendirme
        //[SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product product)//add methodu ValidationAspect(doğrula) ProductValidator methodunu kullanarak
        {
           IResult result= BussinessRules.Run(CheckIfProductCountOfCategoryCorrect(product.CategoryId), 
               CheckIfProductNameExists(product.ProductName),
               CheckIfCategoryLimitExceded());

            if (result != null )
            {
                return result;
            }
            _producDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);


        }
        [CacheAspect]//Key,value
        public IDataResult<List<Product>> GetAll()
        {
            //iş kodları
            //Yetkisi Varmı

            if (DateTime.Now.Hour == 12)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Product>>(_producDal.GetAll(), Messages.ProductsListed);

        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_producDal.GetAll(p => p.CategoryId == id));
            //SuccessDataResult içerisinde List<Product> var ctor'a _producDal.GetAll(p=>p.CategoryId==id) gönderiyoruz
        }
        [CacheAspect]
        [PerformanceAspect(5)]// bu method permormansı 5 sn geçerse uyarma yapılır
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_producDal.Get(p => p.ProductId == productId));

        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_producDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_producDal.GetProductDetails());
        }

        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]//IProductService.Get olan keyleri iptal et
        public IResult Update(Product product)
        {
            throw new NotImplementedException();
        }

        //Categoride ki ürünlerin doğrulugunu kontrol etme
        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            //Bir categoride en fazla 10 ürün olabilir 
            var result = _producDal.GetAll(item => item.CategoryId == categoryId).Count();

            if (result >= 10)
            {

                return new ErrorResult(Messages.ProducutCountOfCategoryError);
            }
            return new SuccessResult();
        }
        //Aynı ürün ismi bulma
        private IResult CheckIfProductNameExists(string productName)
        {
            //Bir categoride en fazla 10 ürün olabilir 
            var result = _producDal.GetAll(p => p.ProductName == productName).Any();

            if (result)
            {
                return new ErrorResult(Messages.ProducutNameAlreadyExists);
            }
            return new SuccessResult();
            //Veya
            //var result = _producDal.GetAll(p => p.ProductName == productName);

            //if (result!=null)
            //{
            //    return new ErrorResult(Messages.ProducutNameAlreadyExists);
            //}
            //Veya
            //if (_producDal.GetAll(p => p.ProductName == productName).Count() > 0)
            //{
            //    return new ErrorResult(Messages.ProducutNameAlreadyExists);;
            //}
        }
        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count>15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
