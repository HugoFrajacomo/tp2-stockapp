﻿using StockApp.Domain.Validation;

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
            DomainExceptionValidation.When(id < 0, "Invalid Id value.");
            Id = id;
            CategoryId = categoryId;
            ValidateDomain(name, description, price, stock, image);
        }

        public Category Category { get; set; }

        private void ValidateDomain(string name, string description, decimal? price, int? stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name, name is required.");

            DomainExceptionValidation.When(name.Length < 3,
                "Invalid name, too short, minimum 3 characters.");

            DomainExceptionValidation.When(name.Length > 100, "Invalid name, too big, maximum 100 Caracteres");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                "Invalid description, description is required.");

            DomainExceptionValidation.When(description.Length < 5,
                "Invalid description, too short, minimum 5 characters.");

            DomainExceptionValidation.When(description.Length > 200, "Invalid description, too big, maximum 200 Caracteres");

            DomainExceptionValidation.When(price == null, "Invalid price, price is required.");

            DomainExceptionValidation.When(decimal.Round(price.Value, 2) != price,
                "Invalid price, price must have exactly two decimal places.");

            DomainExceptionValidation.When(price < 0, "Invalid stock negative value.");

            DomainExceptionValidation.When(price > 9999999.99m, "Invalid price, maximum value is 9,999,999.99");

            DomainExceptionValidation.When(stock < 0, "Invalid stock negative value.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(image), "Invalid image name, image is required.");

            DomainExceptionValidation.When(image.Length > 250, "Invalid image name, to long, maximum 250 characteres.");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock == null ? 0 : stock.Value;
            Image = image;
        }
    }
}
