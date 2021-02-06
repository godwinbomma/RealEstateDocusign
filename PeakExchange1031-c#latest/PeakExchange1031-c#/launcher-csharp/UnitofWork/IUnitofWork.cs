using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocuSign.CodeExamples.UnitofWork
{
    public interface IUnitofWork
    {
        IRepository<T> Repository<T>() where T : class;
        void SaveChanges();
        void Dispose();

    }
}
