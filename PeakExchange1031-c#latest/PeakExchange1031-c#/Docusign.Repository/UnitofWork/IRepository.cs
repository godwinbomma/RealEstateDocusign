using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Docusign.Repository.UnitofWork
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Func<T, bool> predicate = null);

        T Get(Expression<Func<T, bool>> predicate);

        T GetFirstOrDefault(Func<T, bool> predicate);

        T Get(object Id);

        void Add(T entity);

        void Attach(T entity);

        void AddRange(IEnumerable<T> entities);

        void Delete(T entity);

        void RemoveRange(IEnumerable<T> entities);

        bool Any(Func<T, bool> predicate = null);

        IQueryable<T> IQueryableGetAll(Func<T, bool> predicate = null);
    }
}
