using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Livraria.Interfaces.Repositorios.Generics
{
    public interface IGenericRepository<T> where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        T FindById(params object[] ids);
        IEnumerable<T> GetAll();
        void Update(T entity);
    }
}