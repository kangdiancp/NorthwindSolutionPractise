using Northwind.Domain.Entities.Master;
using Northwind.Domain.Repositories;
using Northwind.Persistence.Repositories;
using Northwind.Persistence.Repositories.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Persistence.Base
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IUnitOfWorks> _unitOfWorks;
        private readonly Lazy<IRepositoryEntityBase<Category>> _categoryRepository;
        private readonly Lazy<IRepositoryEntityBase<CategoryDetail>> _categoryDetailRepository;

        public RepositoryManager(RepositoryDbContext dbContext)
        {
            _unitOfWorks = new Lazy<IUnitOfWorks>(()=> new UnitOfWorks(dbContext));
            _categoryRepository = new Lazy<IRepositoryEntityBase<Category>>(()=> new CategoryRepository(dbContext));
            _categoryDetailRepository = new Lazy<IRepositoryEntityBase<CategoryDetail>>(() => new CategoryDetailRepository(dbContext));
        }

        public IRepositoryEntityBase<Category> CategoryRepository => _categoryRepository.Value;

        public IRepositoryEntityBase<CategoryDetail> CategoryDetailRepository => _categoryDetailRepository.Value;

        public IUnitOfWorks UnitOfWork => _unitOfWorks.Value;
    }
}
