using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Application.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The name is required")]
        [MinLength(3, ErrorMessage = "The name must have at least 3 characters")]
        [MaxLength(100, ErrorMessage = "The name must have a maximum of 100 characters")]
        public string Name { get; set; }
    }
}
