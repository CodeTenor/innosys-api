using innosys_domain;
using Microsoft.EntityFrameworkCore;
using smart_cabinet_api.infastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace innosys_infastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : Domain
    {
        private readonly InnosysContext _context = null;

        public Repository(InnosysContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            _context = context;
        }

        public void Add(T entity)
        {
            try
            {
                _context.Set<T>().Add(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<T> GetAll(params string[] includes)
        {
            return _context.Set<T>().IncludeMultiple(includes).ToList();
        }

        public IList<T> GetAllByExpression(Expression<Func<T, bool>> expression, params string[] includes)
        {
            return _context.Set<T>().Where(expression).IncludeMultiple(includes).ToList();
        }

        public T GetById(Guid id, params string[] includes)
        {
            return _context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            try
            {
                _context.Entry<T>(entity).State = EntityState.Modified;

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async System.Threading.Tasks.Task Delete(Guid id)
        {
            try
            {
                var entity = GetById(id);

                _context.Set<T>().Remove(entity);

                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public T GetByExpression(Expression<Func<T, bool>> expression, params string[] includes)
        {
            return _context.Set<T>().IncludeMultiple(includes).SingleOrDefault<T>(expression);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
