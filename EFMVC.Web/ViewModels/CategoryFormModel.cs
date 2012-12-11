using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using EFMVC.Model;

namespace EFMVC.Web.ViewModels
{
    public class CategoryFormModel
    {
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }       
    }
}