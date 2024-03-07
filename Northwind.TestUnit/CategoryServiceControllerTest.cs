using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Moq;
using Northwind.Contract.Dto;
using Northwind.Service;
using Northwind.Service.Abstraction;
using Northwind.Service.Abstraction.Base;
using Northwind.WebAPI.Controllers;
using Shouldly;

/*var cate = actual.FirstOrDefault();
 Assert.Equal("One", cate.CategoryName);
 Assert.Equal(2, actual.Count);*/

namespace Northwind.TestUnit
{
    public class CategoryServiceControllerTest
    {
        private readonly Mock<IServiceManager> _mockService;
        private readonly CategoryServiceController _controller;

        public CategoryServiceControllerTest()
        {
            _mockService = new Mock<IServiceManager>();
            _controller = new CategoryServiceController(_mockService.Object);
        }

        [Fact]
        public async void GetCategories_Returns200OK()
        {
            //Arrange: Create a testCommand and populate with initial values 
            var items = GetItemsTestData();
            _mockService.Setup(srv => srv.CategoryService.GetAllAsync(false)).ReturnsAsync(items);

            //Act Perform the action we want to test, that is, change the value of HowTo
            
            var actionResult = await _controller.GetCategories();

            var result = actionResult.Result as OkObjectResult;
            var actual = result.Value as IEnumerable<CategoryDto>;

            //Assert Check that the value of HowTo matches what we expect
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(GetItemsTestData().Count, actual.Count());

        }

        [Fact]
        public async void GetCategoryById_Returns200OK_WhenExistingIdProvided()
        {
            //Arrange

            var items = GetItemsTestData();
            var id = (int)1;
            _mockService.Setup(srv => srv.CategoryService.GetyByIdAsync(id,false)).ReturnsAsync(items[0]);

            //Act 
            var actionResult = await _controller.GetCategoryById(1);
            var result = actionResult.Result as OkObjectResult;

            //Assert
            Assert.IsType<ActionResult<CategoryDto>>(actionResult);
            var actual = result.Value as CategoryDto;
            Assert.Equal("Satu", actual.CategoryName);
        }

        [Fact]
        public async void GetCategoryById_Returns404NotFound_WhenNonExistingIdProvided()
        {
            //Arrange

            var items = GetItemsTestData();
            var id = (int)1;
            _mockService.Setup(srv => srv.CategoryService.GetyByIdAsync(id, false)).ReturnsAsync(()=> null);

            //Act 
            var actionResult = await _controller.GetCategoryById(1);

            //Assert
            Assert.IsType<NotFoundResult>(actionResult.Result);
        }

        [Fact]
        public async Task CreateCategory_ReturnCreateActionResult_WhenSucceed()
        {
            //Arrange 
            var categoryDto = new CategoryDto
            {
                Id = 4,
                CategoryName = "Test4"
            };


            _mockService.Setup(service => service.CategoryService.CreateAsync(categoryDto))
                .ReturnsAsync(categoryDto);


            //Act
            var actionResult = await _controller.CreateCategory(categoryDto);
            var result = actionResult;

            //Assert
            Assert.IsType<CreatedAtActionResult>(result);


        }

        [Fact]
        public async Task UpdateCategory_Return204NoContent_WhenSubmitted()
        {
            //Arrange 
            var categoryDto = new CategoryDto
            {
                Id = 4,
                CategoryName = "Test4",
                Description="Only Test"
            };

            var id = (int)4;


            _mockService.Setup(service => service.CategoryService.UpdateAsync(id, categoryDto))
                        .Returns(Task.CompletedTask);
                


            //Act
            var actionResult = await _controller.UpdateCategory(id,categoryDto);
            
            //Assert
            Assert.IsType<NoContentResult>(actionResult);


        }

        [Fact]
        public async Task DeleteCategory_Return204NoContent_WhenSubmitted()
        {
            //Arrange 
            var id = (int)4;


            _mockService.Setup(service => service.CategoryService.DeleteAsync(id))
                        .Returns(Task.CompletedTask);



            //Act
            var actionResult = await _controller.Delete(id);

            //Assert
            Assert.IsType<NoContentResult>(actionResult);


        }



        private List<CategoryDto> GetItemsTestData()
        {
            return new List<CategoryDto>
            {
                new CategoryDto { Id = 1,CategoryName="Satu"},
                new CategoryDto { Id = 2,CategoryName="Dua"},
                new CategoryDto { Id = 3,CategoryName="Tiga"},
            };

        }


    }
}
