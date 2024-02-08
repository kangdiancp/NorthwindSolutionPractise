using AutoMapper;
using NorthwindWebMvc.Basic.Models;
using NorthwindWebMvc.Basic.Models.Dto;
using NorthwindWebMvc.Basic.Models.Record;
using NorthwindWebMvc.Basic.Repository;

namespace NorthwindWebMvc.Basic.Service
{
    public class CategoryService : ICategoryService<CategoryDto>
    {
        private readonly IRepositoryBase<Category> _repositoryBase;
        private readonly IMapper _mapper;

        public CategoryService(IRepositoryBase<Category> repositoryBase,IMapper mapper)
        {
            _repositoryBase = repositoryBase;
            _mapper = mapper;
        }

        public CategoryDto Create(CategoryDto entity)
        {
           var category = _mapper.Map<Category>(entity);

            //
           _repositoryBase.Save(category);

            entity = _mapper.Map<CategoryDto>(category);

            return entity;
            
        }

        public IEnumerable<CategoryDto> GetAll()
        {
            var categories = _repositoryBase.GetAll();
            /*var categoryDto = categories.Select(c => new CategoryDto
            {
                CategoryName = c.CategoryName,
                Description = c.Description,
                Photo = c.Photo
            }).ToList();*/

            var categoryRecord = categories.Select(c => new CategoryRecord(c.CategoryName,c.Description));

            var categoryDto = _mapper.Map<IEnumerable<CategoryDto>>(categories);
            return categoryDto;
        }


    }
}
