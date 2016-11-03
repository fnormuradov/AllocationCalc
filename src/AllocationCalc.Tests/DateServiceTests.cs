using AllocationCalc.Services;
using System;
using Xunit;

namespace AllocationCalc.Tests
{
    public class DateServiceTests
    {
        private DateService _dateService;
        public DateServiceTests()
        {
            _dateService = new DateService();
        }
        [Fact]
        public void CanCalculateNumberOfDaysWithinOneMonth()
        {
            var fromDate = new DateTime(2016, 11, 3);
            var tillDate = new DateTime(2016, 11, 10);
            var expected = 8;
            var actual = _dateService.GetDuration(fromDate, tillDate);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void CanGetNumberOfNonWorkingDaysWithinOneWeek()
        {
            var nonWorkingDays = new DayOfWeek[] { DayOfWeek.Saturday, DayOfWeek.Sunday };
            var fromDate = new DateTime(2016, 11, 3);
            var expected = 2;
            var actual = _dateService.GetNumberOfNonWorkingDates(fromDate, 8, nonWorkingDays);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void CanGetNumberOfNonWorkingDaysWithinTwoWeeks()
        {
            var nonWorkingDays = new DayOfWeek[] { DayOfWeek.Saturday, DayOfWeek.Sunday };
            var fromDate = new DateTime(2016, 11, 3);
            var expected = 4;
            var actual = _dateService.GetNumberOfNonWorkingDates(fromDate, 15, nonWorkingDays);
            Assert.Equal(expected, actual);
        }
    }
}
