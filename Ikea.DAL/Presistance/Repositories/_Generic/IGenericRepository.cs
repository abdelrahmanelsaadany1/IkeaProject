﻿using Ikea.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikea.DAL.Presistance.Repositories._Generic
{
    public interface IGenericRepository <T> where T : ModelBase
    {
        IEnumerable<T> GetAll(bool WithAsNoTracking = true);
        IQueryable<T> GetAllQueryable();
        T? GetById(int id);
        int Add(T entity);
        int Update(T entity);
        int Delete(T entity);
    }
}
