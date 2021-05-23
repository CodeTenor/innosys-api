using innosys_domain;
using Microsoft.EntityFrameworkCore;
using smart_cabinet_api.infastructure;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public T GetById(Guid id, params string[] includes)
        {
            return _context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            try
            {
                _context.Entry<T>(entity).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
