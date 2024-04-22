using FluentAssertions;
using StockApp.Domain.Entities;
using StockApp.Domain.Validation;
using Xunit;

namespace StockApp.Domain.Test
{
    public class CategoryUnitTest
    {
        [Fact(DisplayName = "Create Category With Valid State Id")]
        public void CreateCategory_WithValidParameters_ResultValidStateId() 
        {
            Action action = () => new Category(1, "Category Name");
            action.Should().NotThrow<DomainExceptionValidation>(); 
        }
    }
}