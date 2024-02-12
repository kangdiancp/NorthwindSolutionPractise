using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Domain.Repositories
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> GetAll(bool trackChanges);

        IQueryable<T> GetByCondition(Expression<Func<T, bool>> expressions, bool trackChanges);

        void Create(T entity);

        void Delete(T entity);
    }
}
