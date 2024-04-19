using FluentAssertions;
using StockApp.Domain.Entities;
using StockApp.Domain.Validation;
using Xunit;

namespace StockApp.Domain.Test
{
    public class CategoryUnitTest
    {
        [Fact(DisplayName = "[Positive] Create Category With Valid State")]
        public void CreateCategory_WithValidParameters_ResultValidState()
        {
            Action action = () => new Category(1, "phones");
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "[Negative] Create Category With Invalid Id")]
        public void CreateCategory_WithInvalidId_ResultInvalidState()
        {
            Action action = () => new Category(-1, "phones");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Id value.");
        }

        [Fact(DisplayName = "[Negative] Create Category With Invalid Name (Less Than 3)")]
        public void CreateCategory_WithInvalidNameLessThan3_ResultInvalidState()
        {
            Action action = () => new Category(1, "ph");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name, too short, minimum 3 characters.");
        }

        [Fact(DisplayName = "[Negative] Create Category With Invalid Name (More Than 100)")]
        public void CreateCategory_WithInvalidNameMoreThan100_ResultInvalidState()
        {
            Action action = () => new Category(1, new string('A', 101));
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name, too long, maximum 100 characters.");
        }

        [Fact(DisplayName = "[Negative] Create Category With Invalid Name (Null)")]
        public void CreateCategory_WithInvalidNameNull_ResultInvalidState()
        {
            Action action = () => new Category(1, null);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name, name is required.");
        }
    }
}
