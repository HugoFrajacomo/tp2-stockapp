using StockApp.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Domain.Entities
{
    public class Product
    {
        #region Atributos
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public int? Stock { get; set;}
        public string Image { get; set; }
        public int CategoryId { get; set; }
        #endregion

        public Product(string name, string description, decimal? price, int? stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }

        public Product(int id, string name, string description, decimal? price, int? stock, string image, int categoryId)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value");
            Id = id;
            CategoryId = categoryId;
            ValidateDomain(name, description, price, stock, image);
        }

        public Category Category { get; set; }

        private void ValidateDomain(string name, string description, decimal? price, int? stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Name is required");

            DomainExceptionValidation.When(name.Length < 3, "Name too short, minimum 3 characters");

            DomainExceptionValidation.When(name.Length > 100, "Name too long, maximum 100 caracteres");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Description is required");

            DomainExceptionValidation.When(description.Length < 5, "Description too short, minimum 5 characters");

            DomainExceptionValidation.When(description.Length > 200, "Description too long, maximum 200 characters");

            DomainExceptionValidation.When(price == null, "Invalid price, price is required");

            DomainExceptionValidation.When(decimal.Round(price.Value, 2) != price, "Invalid price format, maximum 2 decimal places");

            DomainExceptionValidation.When(price < 0, "Invalid price value, cant be negative");

            DomainExceptionValidation.When(price > 9999999.99m, "Invalid price value, maximum 9999999.99");

            DomainExceptionValidation.When(stock < 0, "Invalid stock value, cant be negative");

            DomainExceptionValidation.When(string.IsNullOrEmpty(image), "Image is required");

            DomainExceptionValidation.When(image.Length > 250, "Image too long, maximum 250 characters");


            Name = name;
            Description = description;
            Price = price;
            Stock = stock == null ? 0 : stock;
            Image = image;
        }
    }
}