﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entities.Abstract;

namespace DataAccess.Abstract
{
    //Generic Constrain
    //Class : Referans tip olabilir.
    //IEntity : IEntity olabilir veya IEntity implemente eden bir nesne  olabilir
    //new (): new lenebilir olmalı.
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        //null olması filtreleme vermeyedebilir.
        List<T> GetAll(Expression<Func<T,bool>>filter = null);
        //Filtreleme
        T Get(Expression<Func<T, bool>> filter );
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}