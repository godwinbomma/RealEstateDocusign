using System;
using System.Collections.Generic;
using System.Text;

namespace Docusign.Repository.UnitofWork
{
    public interface IUnitofWork
    {
        IRepository<T> Repository<T>() where T : class;
        void SaveChanges();
        void Dispose();

    }
}
