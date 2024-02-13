using Northwind.Contract.Dto;
using Northwind.Domain.RequestFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Service.Abstraction.Base
{
    public interface ICategoryService : IServiceEntityBase<CategoryDto>
    {
        Task<IEnumerable<CategoryDto>> GetAllPagingAsync(EntityParameter entityParameters, bool trackChanges);
    }
}
