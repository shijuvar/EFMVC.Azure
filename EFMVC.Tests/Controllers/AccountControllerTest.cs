using AutoMapper;
using EFMVC.CommandProcessor.Command;
using EFMVC.CommandProcessor.Dispatcher;
using EFMVC.Data.Repositories;
using EFMVC.Domain.Commands;
using EFMVC.Model;
using EFMVC.Web;
using EFMVC.Web.Controllers;
using EFMVC.Web.Core.Authentication;
using EFMVC.Web.ViewModels;
using Moq;
using NUnit.Framework;
using System;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EFMVC.Tests.Controllers
{
     [TestFixture]
    public class AccountControllerTest
    {
       private Mock<IFormsAuthentication> formsAuthentication;
       private Mock<ICommandBus> commandBus;
       private Mock<IUserRepository> userRepository;
       [SetUp]
       public void SetUp()
       {
           formsAuthentication = new Mock<IFormsAuthentication>();
           userRepository = new Mock<IUserRepository>();
           commandBus = new Mock<ICommandBus>();           
       }
       [Test]
       public void Cannot_Login_With_Empty_UserCrdential()
       {
           //Arrange 
           LogOnFormModel logon = new LogOnFormModel();
           logon.UserName = string.Empty;
           logon.Password = string.Empty;
           AccountController controller = new AccountController(commandBus.Object, userRepository.Object, formsAuthentication.Object);
           // The MVC pipeline doesn't run, so binding and validation don't run.
           controller.ModelState.AddModelError("", "UserName and Password Should Provide");
           //Act          
           var result = controller.Login(logon, "http://localhost:50521") as ViewResult;
           //Assert   
           Assert.AreEqual(false, result.ViewData.ModelState.IsValid);
           Assert.AreEqual("Login", result.ViewName);
       }      
       [Test]
       public void Cannot_AjaxLogin_With_Empty_UserCrdential()
       {
           //Arrange 
           LogOnFormModel logon = new LogOnFormModel();
           logon.UserName = string.Empty;
           logon.Password = string.Empty;
           AccountController controller = new AccountController(commandBus.Object, userRepository.Object, formsAuthentication.Object);
           // The MVC pipeline doesn't run, so binding and validation don't run.
           controller.ModelState.AddModelError("", "UserName and Password Should Provide");
           //Act          
           var actual = controller.JsonLogin(logon, "http://localhost:50521");
           //Assert          
           Assert.IsInstanceOfType(typeof(JsonResult), actual, "Wrong Type");
           var result = (JsonResult)actual; 
           bool success =
               (bool)
               (result.Data.GetType().GetProperty("success")).GetValue(result.Data, null);
           Assert.AreEqual(false, success);
       }
       [Test]
       public void Cannot_Login_With_Wrong_UserCrdential()
       {
           //Arrange                   
           userRepository.Setup(x => x.Get(It.IsAny<Expression<Func<User, bool>>>())).Returns((User)null);
           LogOnFormModel logon = new LogOnFormModel();
           logon.UserName = "wrongmail@something.com";
           logon.Password = "password123";
           AccountController controller = new AccountController(commandBus.Object, userRepository.Object, formsAuthentication.Object);
           //Act          
           var result = controller.Login(logon, "http://localhost:50521") as ViewResult;
           //Assert   
           Assert.AreEqual(false, result.ViewData.ModelState.IsValid);
           Assert.AreEqual("Login", result.ViewName);
       }
       [Test]
       public void Login_Success_Redirects_To_Home()
       {
           //Arrange 
           var routes = new RouteCollection();
           MvcApplication.RegisterRoutes(routes);
           var returnUrl = new Uri("http://efmvc.codeplex.com");

           Mock<HttpRequestBase> request = new Mock<HttpRequestBase>();
           Mock<HttpResponseBase> response = new Mock<HttpResponseBase>();
           Mock<HttpContextBase> context = new Mock<HttpContextBase>();

           context.SetupGet(x => x.Request).Returns(request.Object);
           context.SetupGet(x => x.Response).Returns(response.Object);
           request.Setup(x => x.Url).Returns(new Uri("http://localhost:50521"));
           User user = new User()
           {
               Email = "shiju.varghese@gmail.com",
               UserId = 1,
               FirstName = "Shiju",
               LastName = "Var",
               DateCreated = DateTime.Now,
               Password = "password123",
               RoleId = 2
           };        
           userRepository.Setup(x => x.Get(It.IsAny<Expression<Func<User, bool>>>())).Returns(user);
           LogOnFormModel logon = new LogOnFormModel();
           logon.UserName = user.Email;
           logon.Password = "password123";
           AccountController controller = new AccountController(commandBus.Object, userRepository.Object, formsAuthentication.Object);           
           //Act          
           controller.ControllerContext = new ControllerContext(context.Object, new RouteData(), controller);
           controller.Url = new UrlHelper(new RequestContext(context.Object, new RouteData()), routes);
           var actual = controller.Login(logon, returnUrl.AbsoluteUri);
           //Assert          
           Assert.IsInstanceOfType(typeof(RedirectToRouteResult), actual ,"Wrong Type");
           var result = (RedirectToRouteResult)actual;
           Assert.AreEqual("Home", result.RouteValues["controller"]);
           Assert.AreEqual("Index", result.RouteValues["action"]);
       }
       [Test]
       public void User_Register_Redirects_To_Home()
       {
           //Arrange 
           User user = new User()
           {
               Email = "shiju.varghese@gmail.com",
               UserId = 1,
               FirstName="Shiju",
               LastName="Var",
               DateCreated=DateTime.Now,               
               Password = "password123",              
               RoleId = 2
           };           
           commandBus.Setup(c => c.Submit(It.IsAny<UserRegisterCommand>())).Returns(new CommandResult(true));
           userRepository.Setup(x => x.Get(It.IsAny<Expression<Func<User, bool>>>())).Returns(user);
           Mapper.CreateMap<UserFormModel, UserRegisterCommand>();
           UserFormModel userForm = new UserFormModel
           {
               Email = "shiju.varghese@gmail.com",
               FirstName = "Shiju",
               LastName = "Var",
               Password = "password123",
               ConfirmPassword = "password123"
           };
           AccountController controller = new AccountController(commandBus.Object, userRepository.Object, formsAuthentication.Object);                     
           // Act 
           var result= controller.Register(userForm) as RedirectToRouteResult;
           // Assert 
           Assert.AreEqual("Home", result.RouteValues["controller"]);
           Assert.AreEqual("Index", result.RouteValues["action"]);
       }
    }
}
