using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocuSign.CodeExamples.Data;

namespace DocuSign.CodeExamples.UnitofWork
{
    public class UnitofWork : IUnitofWork
    {

        private readonly RealEstateLocalContext realEstateContext;
        public Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public UnitofWork(RealEstateLocalContext _realEstateContext)
        {
            realEstateContext = _realEstateContext;
        }


        public IRepository<T> Repository<T>() where T : class
        {
            if (repositories.Keys.Contains(typeof(T)) == true)
            {
                return repositories[typeof(T)] as IRepository<T>;
            }
            IRepository<T> repo = new GenericRepository<T>(realEstateContext);
            repositories.Add(typeof(T), repo);
            return repo;
        }

        public void SaveChanges()
        {
            realEstateContext.SaveChanges();
        }

        public void Dispose()
        {
            realEstateContext.Dispose();
        }
    }
}
