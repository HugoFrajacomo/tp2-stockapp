using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockApp.Domain.Entities;
using FluentAssertions;
using System.Security.Cryptography;
using StockApp.Domain.Validation;

namespace StockApp.Domain.Test
{
    public class ProductUnitTest
    {
        #region Testes Positivos
        [Fact(DisplayName = "Create Product With Valid State")]
        public void CreateProduct_WithValidParameters_ResultValidState()
        {
            Action action = () => new Product(1, "Nome Produto", "Descrição", 10, 10, "produto.jpg", 1);
            action.Should().NotThrow<StockApp.Domain.Validation.DomainExceptionValidation>();
        }

        #endregion

        #region Testes Negativos

        [Fact(DisplayName = "Create Product With Invalid Id")]
        public void CreateProduct_WithInvalidId_ResultInvalidState()
        {
            Action action = () => new Product(-1, "Nome Produto", "Descrição", 10, 10, "produto.jpg", 1);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid Id Value.");
        }

        [Fact(DisplayName = "Create Product With Invalid Name")]
        public void CreateProduct_WithInvalidName_ResultInvalidState()
        {
            Action action = () => new Product(1, "", "Descrição", 10, 10, "produto.jpg", 1);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid name, name is required.");
        }

        [Fact(DisplayName = "Create Product With Invalid Short Name")]
        public void CreateProduct_WithInvalidNameLength_ResultInvalidState()
        {
            Action action = () => new Product(1, "No", "Descrição", 10, 10, "produto.jpg", 1);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid name, too short, minimum 3 characters.");
        }

        [Fact(DisplayName = "Create Product With Invalid Long Name")]
        public void CreateProduct_WithInvalidNameLengthBig_ResultInvalidState()
        {
            Action action = () => new Product(1, new string('a', 101), "Descrição", 10, 10, "produto.jpg", 1);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid name, too long, maximum 100 characters.");
        }

        [Fact(DisplayName = "Create Product With Invalid Description")]
        public void CreateProduct_WithInvalidDescription_ResultInvalidState()
        {
            Action action = () => new Product(1, "Nome Produto", "", 10, 10, "produto.jpg", 1);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid description, description is required.");
        }

        [Fact(DisplayName = "Create Product With Invalid Short Description")]
        public void CreateProduct_WithInvalidDescriptionLength_ResultInvalidState()
        {
            Action action = () => new Product(1, "Nome Produto", "Desc", 10, 10, "produto.jpg", 1);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid description, too short, minimum 5 characters.");
        }

        [Fact(DisplayName = "Create Product With Invalid Long Description")]
        public void CreateProduct_WithInvalidDescriptionLengthBig_ResultInvalidState()
        {            
            Action action = () => new Product(1, "Nome Produto", new string('a', 201), 10, 10, "produto.jpg", 1);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid description, too long, maximum 200 characters.");
        }

        [Fact(DisplayName = "Create Product With Invalid Price")]
        public void CreateProduct_WithInvalidPrice_ResultInvalidState()
        { 
            Action action = () => new Product (1,"Nome Produto", "Descrição", -10.55m, 10, "produto.jpg", 1);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid price negative value.");
        }

        [Fact(DisplayName = "Create Product With Invalid State Long Price")]
        public void CreateProduct_WithInvalidParameters_DomainExceptionInvalidLongPrice()
        {
            Action action = () => new Product(1, "ProductName", "Description", 10000000.00m, 10, "imageUrl", 1);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid price, too long, maximum value 9999999.99.");
        }

        [Fact(DisplayName = "Create Product With Invalid Stock")]
        public void CreateProduct_WithInvalidStock_ResultInvalidState()
        {
            Action action = () => new Product(1, "Nome Produto", "Descrição", 10, -10, "produto.jpg", 1);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid stock negative value.");
        }

        [Fact(DisplayName = "Create Product With Invalid Long Image")]
        public void CreateProduct_WithInvalidImageLength_ResultInvalidState()
        { 
            Action action = () => new Product(1, "Nome Produto", "Descrição", 10, 10, new string('a', 251), 1);
            action.Should().Throw<StockApp.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid image name, too long, maximum 250 characters.");
        }
        #endregion
    }
}

