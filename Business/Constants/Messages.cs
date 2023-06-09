﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        //Field
        public static string ProductAdded = "Ürün Eklendi.";
        public static string ProductNameInValid = "Ürün ismi geçersiz.";
        public static string MaintenanceTime = "Sistem Bakımda !!!";
        public static string ProductsListed = "Ürünler Listelendi.";
        public static string ProducutCountOfCategoryError="Categoride en fazla 10 ürün eklenebilir.";
        public static string ProducutNameAlreadyExists="Bu isimde başka bir ürün var";
        public static string CategoryLimitExceded="Categori Limiti aşıldı için yeni ürün eklenemiyor.";
        public static string AuthorizationDenied="Yetkiniz Yok!";
    }
}
