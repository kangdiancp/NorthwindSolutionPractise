using Mapster;
using Northwind.Contract.Dto;
using Northwind.Domain.Entities.Master;
using Northwind.Domain.Exceptions;
using Northwind.Domain.Repositories;
using Northwind.Domain.RequestFeature;
using Northwind.Service.Abstraction.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Service.Master
{
    public class CategoryService : ICategoryService
    {

        private readonly IRepositoryManager _repositoryManager;

        public CategoryService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<CategoryDto> CreateAsync(CategoryDto entity)
        {
            var category = entity.Adapt<Category>();
            _repositoryManager.CategoryRepository.CreateEntity(category);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();

            return category.Adapt<CategoryDto>();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _repositoryManager.CategoryRepository.GetEntityById(id, false);
            if (category == null)
            {
                throw new EntityNotFoundException(id,"Category");
            }

            _repositoryManager.CategoryRepository.DeleteEntity(category);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync(bool trackChanges)
        {
            var categories = await _repositoryManager.CategoryRepository.GetAllEntity(false);
            var categoryDtos = categories.Adapt<IEnumerable<CategoryDto>>();
            return categoryDtos;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllPagingAsync(EntityParameter entityParameters, bool trackChanges)
        {
            var categories = await _repositoryManager.CategoryRepository.GetAllPaging(entityParameters, trackChanges);
            var categoryDtos = categories.Adapt<IEnumerable<CategoryDto>>();
            return categoryDtos;
        }

        public async Task<CategoryDto> GetyByIdAsync(int id, bool trackChanges)
        {
            var category = await _repositoryManager.CategoryRepository.GetEntityById(id, false);
            if (category == null)
            {
                throw new EntityNotFoundException(id, "Category");
            }
            var categoryDto = category.Adapt<CategoryDto>();
            return categoryDto;
        }

        public async Task UpdateAsync(int id, CategoryDto entity)
        {
            var category = await _repositoryManager.CategoryRepository.GetEntityById(id, true);
            if (category == null)
            {
                throw new EntityNotFoundException(id, "Category");
            }
            category.CategoryName = entity.CategoryName;
            category.Description = entity.Description;
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
        }
    }
}
