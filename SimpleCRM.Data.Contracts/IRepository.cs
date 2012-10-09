﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleCRM.Data.Contracts
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);
        void Delete(int id);
    }
}
