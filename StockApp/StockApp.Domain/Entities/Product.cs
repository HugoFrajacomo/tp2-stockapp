﻿using StockApp.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StockApp.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set;}
        public string Image { get; set; }
        public int CategoryId { get; set; }

        public Product(int id, string name, string description, decimal price, int stock, string image, int categoryid)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value.");
            Id = id;
            ValidateDomain(name, description, price, stock, image, categoryid);
        }

        public Category Category { get; set; }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image, int categoryid)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name, name is required.");

            DomainExceptionValidation.When(name.Length > 100,
                "Invalid name, too long, maximum 100 characters.");

            DomainExceptionValidation.When(name.Length < 3,
                "Invalid name, too short, minimum 3 characters.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                "Invalid description, description is required.");

            DomainExceptionValidation.When(description.Length < 5,
                "Invalid description, too short, minimum 5 characters.");

            DomainExceptionValidation.When(description.Length > 200,
                "Invalid description, too long, maximum 200 characters.");

            DomainExceptionValidation.When(price < 0, 
                "Invalid price negative value.");

            DomainExceptionValidation.When(stock < 0, 
                "Invalid stock negative value.");

            DomainExceptionValidation.When(image.Length > 250, 
                "Invalid image, too long, maximum 250 characters.");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;

        }
    }
}