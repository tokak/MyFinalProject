using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        //Categori ile ilgili dış dünyaya neyi servis etmek istiyorsak o operasyonları yazdıgmız alan

        List<Category> GetAll();
        Category GetById(int categoryId);

    }
}
