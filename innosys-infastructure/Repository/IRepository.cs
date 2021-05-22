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
        IList<T> GetAllByExpression(Expression<Func<T, bool>> expression, params string[] includes);
        T GetByExpression(Expression<Func<T, bool>> expression, params string[] includes);
        void Add(T entity);
        void Update(T entity);
        Task Delete(Guid id);
        void Save();
    }
}
