using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProductManagement.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        [Display(Name = "Product's Small Image")]
        [Required(ErrorMessage = "Please upload image")]
        public string SmallImage { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        public string LargeImage { get; set; }

        [NotMapped]
        public HttpPostedFileBase LargeImageFile { get; set; }

        //[Required]

        [DisplayName("Category Name")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Categories { get; set; }
    }

    public class ProductManagementDbContext : ApplicationDbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}