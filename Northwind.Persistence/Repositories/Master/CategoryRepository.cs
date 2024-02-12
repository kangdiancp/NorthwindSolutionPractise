using Microsoft.EntityFrameworkCore;
using Northwind.Domain.Entities.Master;
using Northwind.Domain.Repositories;
using Northwind.Persistence.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Persistence.Repositories.Master
{
    public class CategoryRepository : RepositoryBase<Category>, IRepositoryEntityBase<Category>
    {
        public CategoryRepository(RepositoryDbContext dbContext) : base(dbContext)
        {
        }

        public void CreateEntity(Category entity)
        {
            Create(entity);
        }

        public void DeleteEntity(Category entity)
        {
            Delete(entity);
        }

        public async Task<IEnumerable<Category>> GetAllEntity(bool trackChanges)
        {
            return await GetAll(trackChanges).OrderBy(c => c.Id).ToListAsync();
        }

        public async Task<Category> GetEntityById(int id, bool trackChanges)
        {
            return await GetByCondition(c => c.Id.Equals(id), trackChanges).SingleOrDefaultAsync();
        }
    }
}
