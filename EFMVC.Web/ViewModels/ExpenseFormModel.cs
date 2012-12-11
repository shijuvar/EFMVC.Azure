using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using EFMVC.Model;

namespace EFMVC.Web.ViewModels
{
    public class ExpenseFormModel
    {
        public int ExpenseId { get; set; }

        [Required(ErrorMessage = "Category Required")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Transaction Required")]
        public string Transaction { get; set; }

        [Required(ErrorMessage = "Date Required")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Amount Required")]
        public double Amount { get; set; }

        public IEnumerable<SelectListItem> Category { get; set; }        
    }
}