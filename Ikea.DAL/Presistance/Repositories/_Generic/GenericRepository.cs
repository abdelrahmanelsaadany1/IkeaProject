﻿using Ikea.DAL.Models;

using Ikea.DAL.Presistance.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



using System.Threading.Tasks;

namespace Ikea.DAL.Presistance.Repositories._Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : ModelBase


    {
        private readonly ApplicationDbContext _dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<T> GetAll(bool WithAsNoTracking = true)
        {
            if (WithAsNoTracking)
            {
                _dbContext.Set<T>().Where(x=>!x.IsDeleted).AsNoTracking().ToList();
            }
            return _dbContext.Set<T>().Where(x => !x.IsDeleted).ToList();
        }

        public T? GetById(int id)
        {
            //  var T = _dbContext.Ts.Local.FirstOrDefault(D=>D.Id==id);
            var T = _dbContext.Set<T>().Find(id);
            return T;
        }
        public int Add(T entity)
        {

            _dbContext.Set<T>().Add(entity);
            return _dbContext.SaveChanges();
        }

        public int Update(T entity)
        {

            _dbContext.Set<T>().Update(entity);
            return _dbContext.SaveChanges();
        }
        public int Delete(T entity)
        {
            entity.IsDeleted = true;
            _dbContext.Set<T>().Update(entity);
            return _dbContext.SaveChanges();
        }

        public IQueryable<T> GetAllQueryable()
        {
            return _dbContext.Set<T>();
        }
    }
}
