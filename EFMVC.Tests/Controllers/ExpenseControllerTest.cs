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
using System.Linq.Expressions;
using System.Web;
using System.Web.Routing;
using AutoMapper;

namespace EFMVC.Tests.Controllers
{
    [TestFixture]
    public class ExpenseControllerTest
    {
        private Mock<ICategoryRepository> categoryRepository;
        private Mock<ICommandBus> commandBus;
        private Mock<IExpenseRepository> expenseRepository;
        [SetUp]
        public void SetUp()
        {
            categoryRepository = new Mock<ICategoryRepository>();
            expenseRepository = new Mock<IExpenseRepository>();
            commandBus = new Mock<ICommandBus>();
        }
        [Test]
        public void Index_AjaxRequest_Returns_Partial_With_Expense_List()
        {
            // Arrange  
            Mock<HttpRequestBase> request = new Mock<HttpRequestBase>();
            Mock<HttpResponseBase> response = new Mock<HttpResponseBase>();
            Mock<HttpContextBase> context = new Mock<HttpContextBase>();

            context.Setup(c => c.Request).Returns(request.Object);
            context.Setup(c => c.Response).Returns(response.Object);
            request.Setup(req => req["X-Requested-With"]).Returns("XMLHttpRequest");

            IEnumerable<Expense> fakeExpenses = GetMockExpenses();
            expenseRepository.Setup(x => x.GetMany(It.IsAny<Expression<Func<Expense, bool>>>())).Returns(fakeExpenses); 
            ExpenseController controller = new ExpenseController(commandBus.Object, categoryRepository.Object,expenseRepository.Object);
            controller.ControllerContext = new ControllerContext(context.Object, new RouteData(), controller);
            // Act
            var result = controller.Index(null, null) as PartialViewResult;
            // Assert
            Assert.AreEqual("_ExpenseList", result.ViewName);
            Assert.IsNotNull(result, "View Result is null");
            Assert.IsInstanceOf(typeof(IEnumerable<Expense>),
                    result.ViewData.Model, "Wrong View Model");
            var expenses = result.ViewData.Model as IEnumerable<Expense>;
            Assert.AreEqual(3, expenses.Count(), "Got wrong number of Categories");        
        }
        [Test]
        public void Index_NormalRequest_Returns_Index_With_Expense_List()
        {
            // Arrange          
            Mock<HttpRequestBase> request = new Mock<HttpRequestBase>();
            Mock<HttpResponseBase> response = new Mock<HttpResponseBase>();
            Mock<HttpContextBase> context = new Mock<HttpContextBase>();

            context.Setup(c => c.Request).Returns(request.Object);
            context.Setup(c => c.Response).Returns(response.Object);

            IEnumerable<Expense> fakeExpenses = GetMockExpenses();

            expenseRepository.Setup(x => x.GetMany(It.IsAny<Expression<Func<Expense, bool>>>())).Returns(fakeExpenses);
            ExpenseController controller = new ExpenseController(commandBus.Object, categoryRepository.Object, expenseRepository.Object);
            controller.ControllerContext = new ControllerContext(context.Object, new RouteData(), controller);
            // Act
            var result = controller.Index(null, null) as ViewResult;
            // Assert
            Assert.AreEqual("Index", result.ViewName);
            Assert.IsNotNull(result, "View Result is null");
            Assert.IsInstanceOf(typeof(IEnumerable<Expense>),
                    result.ViewData.Model, "Wrong View Model");
            var expenses = result.ViewData.Model as IEnumerable<Expense>;
            Assert.AreEqual(3, expenses.Count(), "Got wrong number of Categories");
        }
        private IEnumerable<Expense> GetMockExpenses()
        {
            IEnumerable<Expense> fakeExpenses = new List<Expense> {
                new Expense { Transaction="expense1", Date=DateTime.Now, Amount=1500 },
                new Expense { Transaction="expense2", Date=DateTime.Now, Amount=2500 },
                 new Expense { Transaction="expense3", Date=DateTime.Now, Amount=3500 }
                }.AsEnumerable();
            return fakeExpenses;
        }
        [Test]
        public void Cannot_Create_Empty_Expense()
        {
            // Arrange                    
            ExpenseController controller = new ExpenseController(commandBus.Object, categoryRepository.Object, expenseRepository.Object);
            // The MVC pipeline doesn't run, so binding and validation don't run. 
            controller.ModelState.AddModelError("", "mock error message");
            Mapper.CreateMap<ExpenseFormModel, CreateOrUpdateExpenseCommand>(); 
            // Act          
            ExpenseFormModel expense = new ExpenseFormModel();
            expense.ExpenseId = 0;            
            var result = controller.Save(expense) as ViewResult;
            // Assert - check that we are passing an invalid model to the view
            Assert.AreEqual(false, result.ViewData.ModelState.IsValid);
            Assert.AreEqual("Create", result.ViewName);
        }
        [Test]
        public void Create_Expense_Redirects_To_Index()
        {
            // Arrange                    
            ExpenseController controller = new ExpenseController(commandBus.Object, categoryRepository.Object, expenseRepository.Object);
            commandBus.Setup(c => c.Submit(It.IsAny<CreateOrUpdateExpenseCommand>())).Returns(new CommandResult(true));
            Mapper.CreateMap<ExpenseFormModel, CreateOrUpdateExpenseCommand>();  
            // Act          
            ExpenseFormModel expense = new ExpenseFormModel
            {
                Transaction = "Mock Transaction",
                Date = DateTime.Now,
                Amount = 1000,
                CategoryId = 1
            };           
            var result = controller.Save(expense) as RedirectToRouteResult;
            // Assert 
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }
        [Test]
        public void Delete_Expense_ReturnsPartial()
        {
            // Arrange                    
            ExpenseController controller = new ExpenseController(commandBus.Object, categoryRepository.Object, expenseRepository.Object);
            commandBus.Setup(c => c.Submit(It.IsAny<DeleteExpenseCommand>())).Returns(new CommandResult(true));
            IEnumerable<Expense> fakeExpenses = GetMockExpenses();
            expenseRepository.Setup(x => x.GetMany(It.IsAny<Expression<Func<Expense, bool>>>())).Returns(fakeExpenses);
            // Act  
            var result = controller.Delete(1) as PartialViewResult;
            // Assert 
            Assert.IsInstanceOf(typeof(IEnumerable<Expense>),
            result.ViewData.Model, "Wrong View Model");
            Assert.AreEqual("_ExpenseList", result.ViewName);
        }
    }
}
