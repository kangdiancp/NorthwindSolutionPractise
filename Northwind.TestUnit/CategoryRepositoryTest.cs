using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Moq;

using Northwind.Contract.Dto;
using Northwind.Domain.Entities.Master;
using Northwind.Domain.Repositories;
using Northwind.Service;
using Northwind.Service.Abstraction;
using Northwind.Service.Abstraction.Base;
using Northwind.Service.Base;
using Northwind.WebAPI.Controllers;
using Shouldly;


namespace Northwind.TestUnit
{
    public class CategoryRepositoryTest
    {
        private readonly IServiceManager _serviceMgr;
        private readonly Mock<IRepositoryManager> _mockRepo;


        public CategoryRepositoryTest()
        {

            _mockRepo = new Mock<IRepositoryManager>();
            _serviceMgr = new ServiceManager(_mockRepo.Object);
        }

        [Fact]
        public async void GetCategoriesRepository_ShouldReturnAllData()
        {
            //Arrange: Create a testCommand and populate with initial values 

            var items = GetItemsTestData();
            _mockRepo.Setup(repo => repo.CategoryRepository.GetAllEntity(false))
                .ReturnsAsync(items);

            var result = await _serviceMgr.CategoryService.GetAllAsync(false);
            result.ShouldNotBeNull();
            result.Count().ShouldBe(3);
         }

        [Fact]
        public async void GetCategoriesValidate_ShouldReturnValidData()
        {
            var items = GetItemsTestData();
            _mockRepo.Setup(repo => repo.CategoryRepository.GetAllEntity(false))
                .ReturnsAsync(items);

            var result = await _serviceMgr.CategoryService.GetAllAsync(false);
            var item = items[1];
            item.CategoryName.ShouldBe(items[1].CategoryName);
        }


        private List<Category> GetItemsTestData()
        {
            return new List<Category>
            {
                new Category { Id = 1,CategoryName="Satu"},
                new Category { Id = 2,CategoryName="Dua"},
                new Category { Id = 3,CategoryName="Tiga"},
            };

        }


    }
}
