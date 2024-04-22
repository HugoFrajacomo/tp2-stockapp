using FluentAssertions;
using StockApp.Domain.Entities;
using StockApp.Domain.Validation;
using Xunit;

namespace StockApp.Domain.Test
{
    public class CategoryUnitTest
    {
        #region Teste Positivo

        [Fact(DisplayName = "Create Category With Valid State")]
        public void CreateCategory_WithValidParameters_ResultValidState() 
        {
            Action action = () => new Category(1, "Category Name");
            action.Should().NotThrow<DomainExceptionValidation>(); 
        }

        #endregion

        #region Testes Negativos

        [Fact(DisplayName = "Create Category With InValid State Id")]
        public void CreateCategory_WithInValidParameters_ResultInValidStateId()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");
        }

        [Fact(DisplayName = "Create Category With InValid State Name Minimum")]
        public void CreateCategory_WithInValidParameters_ResultInValidStateNameMinimum()
        {
            Action action = () => new Category(1, "Ca");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 characters.");
        }

        [Fact(DisplayName = "Create Category With InValid State Name Maximum")]
        public void CreateCategory_WithInValidParameters_ResultInValidStateNameMaximum()
        {
            Action action = () => new Category(1, new string('T', 101));
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, too long, maximum 100 characters.");
        }

        [Fact(DisplayName = "Create Category With InValid State Name Null")]
        public void CreateCategory_WithInValidParameters_ResultInValidStateNameNull()
        {
            Action action = () => new Category(1, null);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, name is required.");
        }


        #endregion
    }
}