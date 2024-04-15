using FluentAssertions;
using StockApp.Domain.Entities;
using StockApp.Domain.Validation;
using Xunit;

namespace StockApp.Domain.Test
{
    
    public class CategoryUnitTest
    {
        [Fact(DisplayName = "Create Category With Valid State")]
        public void CreateCategory_WithValidParameters_ResultValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Category With Invalid State ID")]
        public void CreateCategory_WithInvalidParameters_DoaminExceptionInvalidID()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Id value.");
        }

        [Fact(DisplayName = "Create Category With Invalid State Name")]
        public void CreateCategory_WithInvalidParameters_DoaminExceptionInvalidName()
        {
            Action action = () => new Category(1, "Ca");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name, too short, minimum 3 characters.");
        }

        [Fact(DisplayName = "Create Category With Long Name")]
        public void CreateCategory_WithLongName_DoaminExceptionInvalidName()
        {
            Action action = () => new Category(1, new string('A', 101));
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name, too big, maximum 100 Caracteres");
        }

        [Fact(DisplayName = "Create Category With Null State Name")]
        public void CreateCategory_WithNullParameters_DoaminExceptionInvalidName()
        {
            Action action = () => new Category(1, null);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name, name is required.");
        }
    }
}