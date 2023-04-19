﻿using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    //Context : Db tabloları ile classları bağlamak
    public class NorthwindContext:DbContext
    {
        //Proje hangi veritabanı ile ilişkilendirdiğimiz yer
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Sql servera nasıl bağlanacagımızı belirtmemiz yeterli
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Northwind;Trusted_Connection=true");
        }
        //Nesnelerin hangisine karşılık geldiği kod
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
