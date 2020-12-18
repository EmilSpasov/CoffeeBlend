namespace CoffeeBlend.Services.Data.Tests
{
    using System;

    using CoffeeBlend.Web.Infrastructure;
    using Xunit;

    public class ValidateReservationTimeAttributeTest
    {
        [Fact]
        public void IsValidReturnsFalseIfTimeIsBeforeStartReservationTime()
        {
            // A
            var attribute = new ValidateReservationTimeAttribute();

            // A
            var timeBeforeReservationAsString = "07:00:00";
            var startReservationTime = TimeSpan.Parse(timeBeforeReservationAsString);

            var isValid = attribute.IsValid(startReservationTime);

            // A
            Assert.False(isValid);
        }

        [Fact]
        public void IsValidReturnsFalseIfTimeIsAfterReservationTime()
        {
            // A
            var attribute = new ValidateReservationTimeAttribute();

            // A
            var timeAfterReservationAsString = "21:01:00";
            var endReservationTime = TimeSpan.Parse(timeAfterReservationAsString);

            var isValid = attribute.IsValid(endReservationTime);

            // A
            Assert.False(isValid);
        }
    }
}
