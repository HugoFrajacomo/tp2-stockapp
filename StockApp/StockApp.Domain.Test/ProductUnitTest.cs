using FluentAssertions;
using StockApp.Domain.Entities;
using StockApp.Domain.Validation;
using Xunit;

namespace StockApp.Domain.Test
{
    public class ProductUnitTest
    {
        [Fact(DisplayName = "[Positive] Create Product With Valid State")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product 1", "Product 1 description", 10.5m, 10, "product1.jpg", 1);
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "[Positive] Create Product With Null Stock Parameters")]
        public void CreateProduct_WithNullStockParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product 1", "Product 1 description", 10.5m, null, "product1.jpg", 1);
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "[Negative] Create Product With Invalid State Id")]
        public void CreateProduct_WithInvalidStateId_ResultObjectInvalidState()
        {
            Action action = () => new Product(-1, "Product 1", "Product 1 description", 10.5m, 10, "product1.jpg", 1);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Id value");
        }

        [Fact(DisplayName = "[Negative] Create Product With Null State Name")]
        public void CreateProduct_WithNullStateName_ResultObjectInvalidState()
        {
            Action action = () => new Product(1, null, "Product 1 description", 10.5m, 10, "product1.jpg", 1);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Name is required");
        }

        [Fact(DisplayName = "[Negative] Create Product With Short Name")]
        public void CreateProduct_WithShortName_ResultObjectInvalidState()
        {
            Action action = () => new Product(1, "Pr", "Product 1 description", 10.5m, 10, "product1.jpg", 1);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Name too short, minimum 3 characters");
        }

        [Fact(DisplayName = "[Negative] Create Product With Long Name")]
        public void CreateProduct_WithLongName_ResultObjectInvalidState()
        {
            Action action = () => new Product(1, new string('A', 101), "Product 1 description", 10.5m, 10, "product1.jpg", 1);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Name too long, maximum 100 caracteres");
        }

        [Fact(DisplayName = "[Negative] Create Product With Null Description")]
        public void CreateProduct_WithNullDescription_ResultObjectInvalidState()
        {
            Action action = () => new Product(1, "Product 1", null, 10.5m, 10, "product1.jpg", 1);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Description is required");
        }

        [Fact(DisplayName = "[Negative] Create Product With Short Description")]
        public void CreateProduct_WithShortDescription_ResultObjectInvalidState()
        {
            Action action = () => new Product(1, "Product 1", "Desc", 10.5m, 10, "product1.jpg", 1);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Description too short, minimum 5 characters");
        }

        [Fact(DisplayName = "[Negative] Create Product With Long Description")]
        public void CreateProduct_WithLongDescription_ResultObjectInvalidState()
        {
            Action action = () => new Product(1, "Product 1", new string('A', 201), 10.5m, 10, "product1.jpg", 1);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Description too long, maximum 200 characters");
        }

        [Fact(DisplayName = "[Negative] Create Product With Null Price")]
        public void CreateProduct_WithNullPrice_ResultObjectInvalidState()
        {
            Action action = () => new Product(1, "Product 1", "Product 1 description", null, 10, "product1.jpg", 1);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid price, price is required");
        }

        [Fact(DisplayName = "[Negative] Create Product With Negative Price")]
        public void CreateProduct_WithNegativePrice_ResultObjectInvalidState()
        {
            Action action = () => new Product(1, "Product 1", "Product 1 description", -10.5m, 10, "product1.jpg", 1);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid price value, cant be negative");
        }

        [Fact(DisplayName = "[Negative] Create Product With Long Price")]
        public void CreateProduct_WithLongPrice_ResultObjectInvalidState()
        {
            Action action = () => new Product(1, "Product 1", "Product 1 description", 10000000m, 10, "product1.jpg", 1);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid price value, maximum 9999999.99");
        }

        [Fact(DisplayName = "[Negative] Create Product With Invalid Price Precision")]
        public void CreateProduct_WithInvalidPriceFormat_ResultObjectInvalidState()
        {
            Action action = () => new Product(1, "Product 1", "Product 1 description", 10.555m, 10, "product1.jpg", 1);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid price format, maximum 2 decimal places");
        }

        [Fact(DisplayName = "[Negative] Create Product With Negative Stock")]
        public void CreateProduct_WithNegativeStock_ResultObjectInvalidState()
        {
            Action action = () => new Product(1, "Product 1", "Product 1 description", 10.5m, -10, "product1.jpg", 1);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid stock value, cant be negative");
        }

        [Fact(DisplayName = "[Negative] Create Product With Null Image")]
        public void CreateProduct_WithNullImage_ResultObjectInvalidState()
        {
            Action action = () => new Product(1, "Product 1", "Product 1 description", 10.5m, 10, null, 1);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Image is required");
        }

        [Fact(DisplayName = "[Negative] Create Product With Long Image")]
        public void CreateProduct_WithLongImage_ResultObjectInvalidState()
        {
            Action action = () => new Product(1, "Product 1", "Product 1 description", 10.5m, 10, new string('A', 251), 1);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Image too long, maximum 250 characters");
        }
    }
}
