
using Moq;


namespace NorthwindXUnit.Basic
{
    public class CategoryControllerTest
    {
        [Fact]
        public async void Index_ReturnViewResult_WithCategoryList()
        {
            //arrange
           /* var mockRepo = new Mock<IRepositoryBase<Category>>();
            mockRepo.Setup(repo => repo.GetAll())
                .Returns(new Category[]
                {
                    new Category{ Id = 1,CategoryName="TV",Description="Digital"},
                    new Category{ Id = 2,CategoryName="Kulkas",Description="Kulkas"},
                }.ToList<Category>);  

            var controller = new CategoriesController(mockRepo.Object);

            //act
            var result = await controller.Index();


            //assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<Category>>(viewResult.ViewData.Model);
            Assert.Equal(2, model.Count);*/
        }
   }
}