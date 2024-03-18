using StockApp.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Category(string name)
        {
            ValidationDomain(name);        
        }

        public Category(int id, string name) 
        {
            DomainExceptionValidation.When(id < 0, "Invalid id value");
            Id = id;
            ValidationDomain(name);
        }

        public ICollection<Product> Products { get; set;}

        private void ValidationDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name, name is required");

            DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short. Min 3 characters");
            Name = name;    
        }
    }
}
