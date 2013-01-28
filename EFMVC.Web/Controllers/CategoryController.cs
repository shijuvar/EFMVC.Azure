using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EFMVC.Web.ViewModels;
using EFMVC.Domain.Commands;
using EFMVC.Core.Common;
using EFMVC.Web.Core.Extensions;
using EFMVC.CommandProcessor.Dispatcher;
using EFMVC.Data.Repositories;
using EFMVC.Web.Core.ActionFilters;
using AutoMapper;
using EFMVC.Model;
using EFMVC.Web.Caching;
namespace EFMVC.Web.Controllers
{
    [CompressResponse]
    public class CategoryController : Controller
    {
        private readonly ICommandBus commandBus;
        private readonly ICategoryRepository categoryRepository;
        /************* The below commented code for Windows Azure Caching ****************
        //----------------------------------------------------------------------------------
        //private readonly ICacheProvider cache;
        //public CategoryController(ICommandBus commandBus, ICategoryRepository categoryRepository, ICacheProvider cacheProvider)
        //{
        //    this.commandBus = commandBus;
        //    this.categoryRepository = categoryRepository;
        //    this.cache = cacheProvider;
        //}
         */
        public CategoryController(ICommandBus commandBus, ICategoryRepository categoryRepository)
        {
            this.commandBus = commandBus;
            this.categoryRepository = categoryRepository;           
        }
        public ActionResult Index()
        {
            //Get cached data from Cache if the data exist, 
            //IEnumerable<Category> categories = null;
            //var cachedCategories = cache.Get("categories");

            //if (cachedCategories != null)
            //{
            //    categories = cachedCategories as IEnumerable<Category>;
            //}
            //else
            //{
            //    //Data from Database
            //    categories = categoryRepository.GetAll().ToList();
            //    if (categories != null)
            //        cache.Put("categories", categories);
            //}
           var categories = categoryRepository.GetAll().ToList();
            return View(categories);
        }
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var category = categoryRepository.GetById(id);
            var viewModel = Mapper.Map<Category, CategoryFormModel>(category);
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CategoryFormModel form)
        {
            if (ModelState.IsValid)
            {
                var command = Mapper.Map<CategoryFormModel, CreateOrUpdateCategoryCommand>(form);
                IEnumerable<ValidationResult> errors = commandBus.Validate(command);
                ModelState.AddModelErrors(errors);
                if (ModelState.IsValid)
                {
                    var result = commandBus.Submit(command);
                    if (result.Success) {
                        var categories = categoryRepository.GetAll().ToList();
                        //cache.Put("categories", categories);
                        return RedirectToAction("Index");
                    }
                }
            }
            //if fail
            if (form.CategoryId == 0)
                return View("Create", form);
            else
                return View("Edit", form);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var command = new DeleteCategoryCommand { CategoryId = id };
            var result = commandBus.Submit(command);
            var categories = categoryRepository.GetAll();
            //cache.Put("categories", categories);
            return PartialView("_CategoryList", categories);
        }
    }
}
