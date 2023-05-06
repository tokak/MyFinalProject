using Business.Abstract;
using Core.DataAccess.EntitiyFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
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
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
    
        public IDataResult<List<Category>> GetAll()
        {
            //Var ise iş kodlarımızı yazdıgımız yer
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
        }
        //Select * from Categories where CategoryId = ?
        public IDataResult<Category> GetById(int categoryId)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(item=>item.CategoryId==categoryId));
        }
    }
}
