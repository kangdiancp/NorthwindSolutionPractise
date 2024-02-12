using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Domain.Repositories
{
    public interface IRepositoryEntityBase<T>
    {
        Task<IEnumerable<T>> GetAllEntity(bool trackChanges);

        Task<T> GetEntityById(int id, bool trackChanges);

        void CreateEntity(T entity);

        void DeleteEntity(T entity);
    }
}
