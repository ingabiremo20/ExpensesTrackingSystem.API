﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesTrackingSystem.API.Helpers
{
    public static class DateTimeOfffsetExtensions
    {
        public static int GetCurrentAge(this DateTimeOffset dateTimeOffset)
        {
            var currentDate = DateTime.UtcNow;
            int age = currentDate.Year - dateTimeOffset.Year;
            if (currentDate < dateTimeOffset.AddYears(age))
            {
                age--;
            }
            return age;
        }
    }
}
