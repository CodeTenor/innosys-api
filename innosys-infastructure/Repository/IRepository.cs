using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace innosys_infastructure.Repository
{
    public interface IRepository<T>
    {
        T GetById(Guid id, params string[] includes);
        IList<T> GetAll(params string[] includes);
        void Add(T entity);
        void Update(T entity);
    }
}
