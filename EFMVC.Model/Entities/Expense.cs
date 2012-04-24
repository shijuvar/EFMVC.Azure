using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace EFMVC.Model
{
    public class Expense
    {

        public int ExpenseId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Transaction { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public double Amount { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
