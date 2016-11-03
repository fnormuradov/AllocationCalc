using AllocationCalc.Models;
using System;

namespace AllocationCalc.Services
{
    public class AnalysisService
    {
        private DateService _dateService;
        public AnalysisService(DateService dateService)
        {
            _dateService = dateService;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="nonWorkingDays"></param>
        /// <param name="workCapacity">hours per full time employee</param>
        /// <returns></returns>
        public int GetWorkingHours(BaseEntity entity, DayOfWeek[] nonWorkingDays, int workCapacity)
        {
            var totalNumberOfDays = _dateService.GetDuration(entity.FromDate, entity.TillDate);
            var firstDay = entity.FromDate;
            var numOfNonWorkingDays = _dateService.GetNumberOfNonWorkingDates(firstDay, totalNumberOfDays, nonWorkingDays);
            var numOfWorkingDays = totalNumberOfDays - numOfNonWorkingDays;
            var numOfEmployees = entity.NumOfFullTimeEmployees;
            var numOfHours = numOfWorkingDays * numOfEmployees * workCapacity;
            return numOfHours;
        }
    }
}
