using EFMVC.CommandProcessor.Command;

namespace EFMVC.Domain.Commands
{
   public class DeleteCategoryCommand :  ICommand
    {
       public int CategoryId { get; set; }
    }
}
