using Livraria.Interfaces.Repositorios.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Livraria.Repositorio.Repositorios.Generics
{
    public class GenericRepository<T> : IGenericRepository<T> where T: class
    {
        internal DataContext _context;
        internal DbSet<T> Set => _context.Set<T>();

        public GenericRepository(DataContext context)
        {
            _context = context;
        }


        public virtual void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }


        public virtual void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }


        public virtual IEnumerable<T> Find(Expression<Func<T,bool>> predicate)
        {
            return Set.Where(predicate);
        }

        public virtual T FindById(params object[] ids)
        {
            return Set.Find(ids);
        }

        public void Delete(T entity)
        {
            Set.Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return Set.ToList();
        }
    }
}
