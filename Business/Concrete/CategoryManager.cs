using Business.Abstract;
using Core.DataAccess.EntitiyFramework;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        EfEntityRepositoryBase<Category,NorthwindContext> _efCategory;

        public CategoryManager(EfEntityRepositoryBase<Category, NorthwindContext> efCategory)
        {
            _efCategory = efCategory;
        }

        public List<Category> GetAll()
        {
            //Var ise iş kodlarımızı yazdıgımız yer
            return _efCategory.GetAll();
        }
        //Select * from Categories where CategoryId = ?
        public Category GetById(int categoryId)
        {
            return _efCategory.Get(item=>item.CategoryId==categoryId);
        }
    }
}
