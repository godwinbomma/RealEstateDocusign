using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Docusign.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace Docusign.Repository.UnitofWork
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        protected readonly RealEstateLocalContext dbContextApp;
        private DbSet<T> _objectSet;

        public GenericRepository(RealEstateLocalContext _dbContextApp)
        {
            dbContextApp = _dbContextApp;
            _objectSet = dbContextApp.Set<T>();
        }

        public void Add(T entity)
        {
            _objectSet.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _objectSet.AddRange(entities);
        }

        public bool Any(Func<T, bool> predicate = null)
        {
            return _objectSet.Any(predicate);
        }

        public void Attach(T entity)
        {
            _objectSet.Attach(entity);
        }

        public void Delete(T entity)
        {
            _objectSet.Remove(entity);
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return _objectSet.Find(predicate);
        }

        public T Get(object Id)
        {
            return _objectSet.Find(Id);
        }

        public IEnumerable<T> GetAll(Func<T, bool> predicate = null)
        {
            if (predicate != null)
            {
                return _objectSet.Where(predicate);
            }
            else
            {
                return _objectSet.AsEnumerable();
            }
        }

        public T GetFirstOrDefault(Func<T, bool> predicate)
        {
            return _objectSet.FirstOrDefault(predicate);
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> IQueryableGetAll(Func<T, bool> predicate = null)
        {
            if (predicate != null)
            {
                return _objectSet.Where(predicate).AsQueryable();
            }
            else
            {
                return _objectSet.AsQueryable();
            }
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _objectSet.RemoveRange(entities);
        }
    }
}
