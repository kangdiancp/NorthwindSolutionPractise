using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Service.Abstraction.Base
{
    public interface IServiceEntityBase<T>
    {
        Task<IEnumerable<T>> GetAllAsync(bool trackChanges);

        Task<T> GetyByIdAsync(int id, bool trackChanges);

        Task<T> CreateAsync(T entity);

        Task UpdateAsync(int id, T entity);

        Task DeleteAsync(int id);
    }
}
