using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFMVC.CommandProcessor.Command;

namespace EFMVC.Domain.Commands
{
    public class CreateOrUpdateExpenseCommand : ICommand 
    {
        public int ExpenseId { get; set; }        
        public int CategoryId { get; set; }      
        public string Transaction { get; set; }       
        public DateTime Date { get; set; }       
        public double Amount { get; set; }
    }
}
