namespace CoffeeBlend.Web.Infrastructure
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ValidateReservationDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var date = (DateTime)value;
            var currentDate = DateTime.Today;

            if (date >= currentDate)
            {
                ;
                return true;
            }

            ;
            return false;
        }
    }
}
