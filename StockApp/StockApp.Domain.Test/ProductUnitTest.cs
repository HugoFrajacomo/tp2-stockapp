using FluentAssertions;
using StockApp.Domain.Entities;
using StockApp.Domain.Validation;
using Xunit;

namespace StockApp.Domain.Test
{
    public class ProductUnitTest
    {
        #region Teste Positivo

        [Fact(DisplayName = "Create Product With Valid State")]
        public void CreateProduct_WithValidParameters_ResultValidState()
        {
            Action action = () => new Product(1, "Product Name", "test description", 10.2m, 5, "test image", 1);
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        #endregion

        #region Testes Negativos

        [Fact(DisplayName = "Create Product With InValid State Id")]
        public void CreateProduct_WithInValidParameters_ResultInValidStateId()
        {
            Action action = () => new Product(-1, "Product Name", "test description", 10.2m, 5, "test image", 1);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");
        }

        [Fact(DisplayName = "Create Product With InValid State Name Null")]
        public void CreateProduct_WithInValidParameters_ResultInValidStateNameNull()
        {
            Action action = () => new Product(1, null, "test description", 10.2m, 5, "test image", 1);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, name is required.");
        }

        [Fact(DisplayName = "Create Product With InValid State Name Maximum")]
        public void CreateProduct_WithInValidParameters_ResultInValidStateNameMaximum()
        {
            Action action = () => new Product(1, new string('T', 101), "test description", 10.2m, 5, "test image", 1);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, too long, maximum 100 characters.");
        }

        [Fact(DisplayName = "Create Product With InValid State Name Minimum")]
        public void CreateProduct_WithInValidParameters_ResultInValidStateNameMinimum()
        {
            Action action = () => new Product(1, "Pr", "test description", 10.2m, 5, "test image", 1);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 characters.");
        }

        [Fact(DisplayName = "Create Product With InValid State Description Null")]
        public void CreateProduct_WithInValidParameters_ResultInValidStateDescriptionNull()
        {
            Action action = () => new Product(1, "Product Name", null, 10.2m, 5, "test image", 1);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid description, description is required.");
        }

        [Fact(DisplayName = "Create Product With InValid State Description Minimum")]
        public void CreateProduct_WithInValidParameters_ResultInValidStateDescriptionMinimum()
        {
            Action action = () => new Product(1, "Product Name", "test", 10.2m, 5, "test image", 1);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid description, too short, minimum 5 characters.");
        }

        [Fact(DisplayName = "Create Product With InValid State Description Maximum")]
        public void CreateProduct_WithInValidParameters_ResultInValidStateDescriptionMaximum()
        {
            Action action = () => new Product(1, "Product Name" , new string('T', 201), 10.2m, 5, "test image", 1);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid description, too long, maximum 200 characters.");
        }

        [Fact(DisplayName = "Create Product With InValid State Price Negative")]
        public void CreateProduct_WithInValidParameters_ResultInValidStatePriceNegative()
        {
            Action action = () => new Product(1, "Product Name", "test description", -1, 5, "test image", 1);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid price negative value.");
        }

        [Fact(DisplayName = "Create Product With InValid State Stock Negative")]
        public void CreateProduct_WithInValidParameters_ResultInValidStateStockNegative()
        {
            Action action = () => new Product(1, "Product Name", "test description", 10.2m, -1, "test image", 1);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid stock negative value.");
        }

        [Fact(DisplayName = "Create Product With InValid State Image Maximum")]
        public void CreateProduct_WithInValidParameters_ResultInValidStateImageMaximum()
        {
            Action action = () => new Product(1, "Product Name", "test description", 10.2m, 5, new string('T', 251), 1);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid image, too long, maximum 250 characters.");
        }


        #endregion
    }
}
