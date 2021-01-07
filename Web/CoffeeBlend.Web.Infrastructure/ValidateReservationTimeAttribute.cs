namespace CoffeeBlend.Web.Infrastructure
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ValidateReservationTimeAttribute : ValidationAttribute
    {
        private const string MinTime = "08:00:00";
        private const string MaxTime = "21:00:00";

        public override bool IsValid(object value)
        {
            var startReservationTime = TimeSpan.Parse(MinTime);
            var endTime = TimeSpan.Parse(MaxTime);
            var currentTime = DateTime.UtcNow.TimeOfDay;

            if (value is DateTime dateValue)
            {
                // TODO: check if date is currentDay
                // if (dateValue.Date > DateTime.Today)
                // {
                    if (dateValue.TimeOfDay >= startReservationTime && dateValue.TimeOfDay < endTime)
                    {
                        return true;
                    }

                // }
                // else if (dateValue.Date == DateTime.Today)
                // {
                //    if (dateValue.TimeOfDay > currentTime && dateValue.TimeOfDay >= startReservationTime && dateValue.TimeOfDay < endTime)
                //    {
                //        return true;
                //    }
                // }
            }

            return false;
        }
    }
}
