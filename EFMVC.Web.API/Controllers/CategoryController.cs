using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using EFMVC.Data.Repositories;
using System.Net;
using EFMVC.CommandProcessor.Dispatcher;
using EFMVC.Domain.Commands;
using EFMVC.Web.API.Models;
using EFMVC.Model;
using System.Collections.Generic;
namespace EFMVC.Web.API.Controllers
{
    //This HTTP service provides the category data with type CategoryWithExpense
    public class CategoryController : ApiController
    {

        private readonly ICommandBus commandBus;
        private readonly ICategoryRepository categoryRepository;
        public CategoryController(ICommandBus commandBus, ICategoryRepository categoryRepository)
        {
            this.commandBus = commandBus;
            this.categoryRepository = categoryRepository;
        }       
        public IQueryable<CategoryWithExpense> Get()
        {
            var categories = categoryRepository.GetCategoryWithExpenses().AsQueryable();
            return categories;
        }

        // GET /api/categories/5
        public CategoryWithExpense Get(int id)
        {
            var category = categoryRepository.GetCategoryWithExpenses().Where(c => c.CategoryId == id).SingleOrDefault();
            if (category == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);            
            return category;
        }

        // POST /api/categories
        public HttpResponseMessage Post(CategoryModel category)
        {
                                        
                if (ModelState.IsValid)
                {
                    var command = new CreateOrUpdateCategoryCommand(category.CategoryId, category.CategoryName, category.Description);   
                    var result = commandBus.Submit(command);
                    if (result.Success)
                    {
                        var categoryWithExpense = new CategoryWithExpense { CategoryName = category.CategoryName, Description = category.Description, TotalExpenses = 0 };
                        var response = Request.CreateResponse<CategoryModel>(HttpStatusCode.Created, category);            
                        string uri = Url.Route(null, new { id = category.CategoryId });
                        response.Headers.Location = new Uri(Request.RequestUri, uri);
                        return response;
                    }
                }
                else
                {
                    var errors = new Dictionary<string, IEnumerable<string>>();
                    foreach (var keyValue in ModelState)
                    {
                        errors[keyValue.Key] = keyValue.Value.Errors.Select(e => e.ErrorMessage);
                    }
                    return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
                }         
             throw new HttpResponseException(HttpStatusCode.BadRequest);
        }

        // PUT /api/categories/5
        public HttpResponseMessage Put(int id, CategoryModel category)
        {
            if (ModelState.IsValid)
            {
                var command = new CreateOrUpdateCategoryCommand(category.CategoryId, category.CategoryName, category.Description);
                var result = commandBus.Submit(command);
                return new HttpResponseMessage(HttpStatusCode.NoContent);
            }
            throw new HttpResponseException(HttpStatusCode.BadRequest);
        }

        // DELETE /api/categories/5
        public void Delete(int id)
        {
            var command = new DeleteCategoryCommand { CategoryId = id };
            var result = commandBus.Submit(command);
            if (!result.Success)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
        }
    }
}
