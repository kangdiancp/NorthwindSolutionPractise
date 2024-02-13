using Northwind.Domain.Entities.Master;
using Northwind.Domain.RequestFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Domain.Repositories
{
    public interface ICategoryRepository : IRepositoryEntityBase<Category>
    {
        Task<PagedList<Category>> GetAllPaging(EntityParameter entityParams, bool trackChanges);
    }
}
