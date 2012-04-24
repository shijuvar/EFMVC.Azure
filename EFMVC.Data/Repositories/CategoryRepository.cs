using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EFMVC.Data.Infrastructure;
using EFMVC.Model;
namespace EFMVC.Data.Repositories
{
    public class CategoryRepository: RepositoryBase<Category>, ICategoryRepository
        {
        public CategoryRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
            {
            }
        public IEnumerable<CategoryWithExpense> GetCategoryWithExpenses()
        {
          var category=  this.GetAll().Join(this.DataContext.Expenses, c => c.CategoryId, e => e.CategoryId, (c, e) => new { c, e })
                    .GroupBy(z => new { z.c.CategoryId, z.c.Name,z.c.Description  }, z => z.e)
                    .Select(g => new CategoryWithExpense { CategoryId = g.Key.CategoryId, CategoryName = g.Key.Name,Description=g.Key.Description, TotalExpenses = g.Sum(s => s.Amount) });
          return category;       
        }
        }
    public interface ICategoryRepository : IRepository<Category>
    {
         IEnumerable<CategoryWithExpense> GetCategoryWithExpenses();
    }
    public class CategoryWithExpense
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public double TotalExpenses { get; set; }
    }
}