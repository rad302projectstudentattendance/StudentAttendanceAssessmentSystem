﻿using StudentAALibrary;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace StudentAAWebApi.DAL
{
    public interface IRepository<T> where T: IEntity
    {
     
        IEnumerable<T> GetAll();
        T Get(int id);
        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);
        void Save();
        int Exists(int id);
    }
}