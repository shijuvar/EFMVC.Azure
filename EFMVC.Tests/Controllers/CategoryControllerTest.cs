using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using NUnit.Framework;
using Moq;
using EFMVC.Data.Repositories;
using EFMVC.CommandProcessor.Dispatcher;
using EFMVC.Web.Controllers;
using EFMVC.Model;
using EFMVC.Web.ViewModels;
using EFMVC.CommandProcessor.Command;
using EFMVC.Domain.Commands;
using AutoMapper;
namespace EFMVC.Tests.Controllers
{
    [TestFixture]
    public class CategoryControllerTest
    {
        private Mock<ICategoryRepository> categoryRepository;
        private Mock<ICommandBus> commandBus;
        [SetUp]
        public void SetUp()
        {
            categoryRepository = new Mock<ICategoryRepository>();
            commandBus = new Mock<ICommandBus>();
        }
        [Test]
        public void Index_Returns_Category_List()
        {
            // Arrange   
            IEnumerable<Category> fakeCategories = new List<Category> {
            new Category { Name = "Test1", Description="Test1Desc"},
            new Category { Name = "Test2", Description="Test2Desc"},
            new Category { Name = "Test3", Description="Test3Desc"}  
          }.AsEnumerable();
            categoryRepository.Setup(x => x.GetAll()).Returns(fakeCategories);
            CategoryController controller = new CategoryController(commandBus.Object, categoryRepository.Object);
            // Act
            ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.IsNotNull(result, "View Result is null");
            Assert.IsInstanceOf(typeof(IEnumerable<Category>),
                    result.ViewData.Model, "Wrong View Model");
            var categories = result.ViewData.Model as IEnumerable<Category>;
            Assert.AreEqual(3, categories.Count(), "Got wrong number of Categories");  
        }
        [Test]
        public void Cannot_Create_Empty_Category()
        {
            // Arrange                    
            CategoryController controller = new CategoryController(commandBus.Object, categoryRepository.Object);
            // The MVC pipeline doesn't run, so binding and validation don't run. 
            controller.ModelState.AddModelError("", "mock error message");
            Mapper.CreateMap<CategoryFormModel, CreateOrUpdateCategoryCommand>();
            // Act          
            CategoryFormModel category = new CategoryFormModel();
            category.CategoryId = 0;
            category.Name = string.Empty;           
            var result = controller.Save(category) as ViewResult;
            // Assert -  check that we are passing an invalid model to the view
            Assert.AreEqual(false, result.ViewData.ModelState.IsValid);
            Assert.AreEqual("Create", result.ViewName);
        }
        [Test]
        public void Create_Category_Redirects_To_Index()
        {
            // Arrange                    
            CategoryController controller = new CategoryController(commandBus.Object, categoryRepository.Object);
            commandBus.Setup(c => c.Submit(It.IsAny<CreateOrUpdateCategoryCommand>())).Returns(new CommandResult(true));
            // Act          
            CategoryFormModel category = new CategoryFormModel();
            category.CategoryId = 0;
            category.Name = "Mock Category";
            Mapper.CreateMap<CategoryFormModel, CreateOrUpdateCategoryCommand>();
            var result = controller.Save(category) as RedirectToRouteResult;
            // Assert 
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }
        [Test]
        public void Delete_Category_ReturnsPartial()
        {
            // Arrange                    
            CategoryController controller = new CategoryController(commandBus.Object, categoryRepository.Object);
            commandBus.Setup(c => c.Submit(It.IsAny<DeleteCategoryCommand>())).Returns(new CommandResult(true));
            // Act  
            var result = controller.Delete(1) as PartialViewResult;
            // Assert 
            Assert.IsInstanceOf(typeof(IEnumerable<Category>),
            result.ViewData.Model, "Wrong View Model");
            Assert.AreEqual("_CategoryList", result.ViewName);
        }
    }
}
