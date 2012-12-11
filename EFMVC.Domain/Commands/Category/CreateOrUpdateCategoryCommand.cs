using EFMVC.CommandProcessor.Command;

namespace EFMVC.Domain.Commands
{
    public class CreateOrUpdateCategoryCommand : ICommand
    {
       public CreateOrUpdateCategoryCommand(int CategoryId,string name, string description)
        {
            this.CategoryId = CategoryId;
            this.Name = name;
            this.Description = description;
        }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
