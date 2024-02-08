using NorthwindWebMvc.Basic.Models;
using NorthwindWebMvc.Basic.RepositoryContext;

namespace NorthwindWebMvc.Basic.Repository
{
    public class CategoryRepository : IRepositoryBase<Category>
    {
        private readonly RepositoryDbContext _context;

        public CategoryRepository(RepositoryDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public Category Save(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
