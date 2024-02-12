using Northwind.Domain.Entities.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Domain.Repositories
{
    public interface IRepositoryManager
    {
        IRepositoryEntityBase<Category> CategoryRepository { get; }
        IRepositoryEntityBase<CategoryDetail> CategoryDetailRepository { get; }

        IUnitOfWorks UnitOfWork { get; }
    }
}
