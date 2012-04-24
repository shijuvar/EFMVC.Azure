using System.Collections.Generic;
using EFMVC.CommandProcessor.Command;
using EFMVC.Domain.Commands;
using EFMVC.Core.Common;
using EFMVC.Data.Repositories;
using EFMVC.Data.Infrastructure;
using EFMVC.Model;
using EFMVC.Domain.Properties;
namespace EFMVC.Domain.Handlers
{
    public class CanAddCategory : IValidationHandler<CreateOrUpdateCategoryCommand>
    {
        private readonly ICategoryRepository categoryRepository;      
        public CanAddCategory(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            this.categoryRepository = categoryRepository;           
        }
        public IEnumerable<ValidationResult> Validate(CreateOrUpdateCategoryCommand command)
        {
            Category isCategoryExists=null;
            if(command.CategoryId==0)
             isCategoryExists = categoryRepository.Get(c => c.Name == command.Name);
            else
                isCategoryExists = categoryRepository.Get(c => c.Name == command.Name && c.CategoryId!=command.CategoryId);
            if (isCategoryExists!=null )
            {
                yield return new ValidationResult("Name", Resources.CategoryExists);
            }
        }
    }
}
