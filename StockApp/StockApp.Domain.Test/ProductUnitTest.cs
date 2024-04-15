using FluentAssertions;
using StockApp.Domain.Entities;
using StockApp.Domain.Validation;
using Xunit;

namespace StockApp.Domain.Test
{
    public class ProductUnitTest
    {
        [Fact(DisplayName = "Create Product With Valid State")]
        public void CreateProduct_WithValidParameters_ResultValidState()
        {
            Action action = () => new Product(1, "Product Name", "teste", 2.31m, 5, "/url", 1);
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product With Invalid State Id")]
        public void CreateProduct_WithInvalidParameters_ResultValidState()
        {
            Action action = () => new Product(-1, "Product Name", "teste", 2.31m, 5, "/url", 1);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Id value.");
        }

        [Fact(DisplayName = "Create Product With Null State Name")]
        public void CreateProduct_WithInvalidName_ResultInvalidState()
        {
            Action action = () => new Product(1, null, "teste", 2.31m, 5, "/url", 1);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name, name is required.");
        }

        [Fact(DisplayName = "Create Product With Short Name")]
        public void CreateProduct_WithShortName_ResultInvalidState()
        {
            Action action = () => new Product(1, "AB", "teste", 2.31m, 5, "/url", 1);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name, too short, minimum 3 characters.");
        }

        [Fact(DisplayName = "Create Product With Long Name")]
        public void CreateProduct_WithLongName_ResultInvalidState()
        {
            Action action = () => new Product(1, new string('A', 101), "teste", 2.31m, 5, "/url", 1);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name, too big, maximum 100 Caracteres");
        }

        [Fact(DisplayName = "Create Product With Null Description")]
        public void CreateProduct_WithNullDescription_ResultInvalidState()
        {
            Action action = () => new Product(1, "Product Name", null, 2.31m, 5, "/url", 1);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid description, description is required.");
        }

        [Fact(DisplayName = "Create Product With Short Description")]
        public void CreateProduct_WithShortDescription_ResultInvalidState()
        {
            Action action = () => new Product(1, "Product Name", "AB", 2.31m, 5, "/url", 1);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid description, too short, minimum 5 characters.");
        }

        [Fact(DisplayName = "Create Product With Long Description")]
        public void CreateProduct_WithLongDescription_ResultInvalidState()
        {
            Action action = () => new Product(1, "Product Name", new string('A', 201), 2.31m, 5, "/url", 1);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid description, too big, maximum 200 Caracteres");
        }

        [Fact(DisplayName = "Create Product With Negative Price")]
        public void CreateProduct_WithNegativePrice_ResultInvalidState()
        {
            Action action = () => new Product(1, "Product Name", "teste", -2.31m, 5, "/url", 1);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid stock negative value.");
        }

        [Fact(DisplayName = "Create Product With Invalid Price Precision")]
        public void CreateProduct_WithInvalidPricePrecision_ResultInvalidState()
        {
            Action action = () => new Product(1, "Product Name", "teste", 2.333m, 5, "/url", 1);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid price, price must have exactly two decimal places.");
        }

        [Fact(DisplayName = "Create Product With Negative Stock")]
        public void CreateProduct_WithNegativeStock_ResultInvalidState()
        {
            Action action = () => new Product(1, "Product Name", "teste", 2.31m, -5, "/url", 1);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid stock negative value.");
        }

        [Fact(DisplayName = "Create Product With Long Image url")]
        public void CreateProduct_WithLongImageName_ResultInvalidState()
        {
            Action action = () => new Product(1, "Product Name", "teste", 2.31m, 5, new string('A', 251), 1);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid image name, to long, maximum 250 characteres.");
        }
    }
}
