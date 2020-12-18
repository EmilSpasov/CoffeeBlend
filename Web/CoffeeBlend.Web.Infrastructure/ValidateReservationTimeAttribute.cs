﻿namespace CoffeeBlend.Web.Infrastructure
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ValidateReservationTimeAttribute : ValidationAttribute
    {
        private const string minTime = "08:00:00";
        private const string maxTime = "21:00:00";

        public override bool IsValid(object value)
        {
            var startReservationTime = TimeSpan.Parse(minTime);
            var endTime = TimeSpan.Parse(maxTime);
            var currentTime = DateTime.UtcNow.TimeOfDay;

            if (value is DateTime intValue)
            {
                if ((intValue.TimeOfDay >= startReservationTime && intValue.TimeOfDay > currentTime) && intValue.TimeOfDay < endTime)
                {
                    return true;
                }
            }

            return false;
        }
    }
}