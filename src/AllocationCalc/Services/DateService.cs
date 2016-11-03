using AllocationCalc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllocationCalc.Services
{
    public class DateService
    {
        //I assume that from date is smaller than the till date
        //Here I assume that the last day is included
        public int GetDuration(DateTime fromDate, DateTime tillDate)
        {
            return (int)(tillDate - fromDate).TotalDays + 1;
        }
        /// <param name="firstDay">Is given with no Time part</param>
        public int GetNumberOfNonWorkingDates(DateTime firstDay, int duration, DayOfWeek[] nonWorkingDays)
        {
            var numOfNonWorkingDays = 0;
            foreach (var weekDay in nonWorkingDays)
            {
                var curDuration = duration;
                var curDate = firstDay;
                while (curDuration > 0)
                {
                    if (curDate.DayOfWeek == weekDay)
                    {
                        numOfNonWorkingDays += (int)Math.Floor(duration / 7.0);
                        break;
                    }
                    curDuration--;
                    curDate = curDate.AddDays(1);
                }
            }
            return numOfNonWorkingDays;
        }
    }
}
