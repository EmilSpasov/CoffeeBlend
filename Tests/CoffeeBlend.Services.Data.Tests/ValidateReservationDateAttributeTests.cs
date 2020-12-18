namespace CoffeeBlend.Services.Data.Tests
{
    using System;

    using CoffeeBlend.Web.Infrastructure;
    using Xunit;

    public class ValidateReservationDateAttributeTests
    {
        [Fact]
        public void IsValidReturnsFalseForDateBeforeCurrentDate()
        {
            // Arrange
            var attribute = new ValidateReservationDateAttribute();

            // Act
            var yesterday = DateTime.Today.AddDays(-1);

            var isValid = attribute.IsValid(yesterday);

            // Assert
            Assert.False(isValid);
        }
    }
}
