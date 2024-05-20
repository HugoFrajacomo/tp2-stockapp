using StockApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Application.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The name is required")]
        [MinLength(3, ErrorMessage = "The name must have at least 3 characters")]
        [MaxLength(100, ErrorMessage = "The name must have a maximum of 100 characters")]
        [DisplayName("Product Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The description is required")]
        [MinLength(5, ErrorMessage = "The description must have at least 5 characters")]
        [MaxLength(200, ErrorMessage = "The description must have a maximum of 200 characters")]
        [DisplayName("Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The price is required")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DisplayName("Price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "The stock is required")]
        [Range(1, 999999, ErrorMessage = "The stock must be greater than 0")]
        [DisplayName("Stock")]
        public int Stock { get; set; }

        [MaxLength(250, ErrorMessage = "The url must have a maximum of 200 characters")]
        [DisplayName("Product image")]
        public string Image { get; set; }
        public Category Category { get; set; }

        [DisplayName("Category")]
        public int CategoryID { get; set; }
    }
}
