using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProductManagement.Models
{
    public class Category
    {
        [Key]
        [Column(Order = 1)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Category name is required")]
        public string CategoryName { get; set; }
    }
}