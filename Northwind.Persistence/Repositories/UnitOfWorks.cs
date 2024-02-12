using Northwind.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Persistence.Repositories
{
    public class UnitOfWorks : IUnitOfWorks
    {
        private readonly RepositoryDbContext _dbContext;

        public UnitOfWorks(RepositoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<int> SaveChangesAsync() => 
            _dbContext.SaveChangesAsync();
    }
}
