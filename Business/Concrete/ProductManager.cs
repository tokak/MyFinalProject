using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
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

        public List<Product> GetAll()
        {
            //iş kodları
            //Yetkisi Varmı
          return  _producDal.GetAll();

        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _producDal.GetAll(p=>p.CategoryId==id);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _producDal.GetAll(p=>p.UnitPrice>=min && p.UnitPrice<=max);
        }
    }
}
