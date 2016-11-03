using AllocationCalc.Models;
using AllocationCalc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllocationCalc
{
    public class Program
    {
        private static DayOfWeek[] NonWorkingDays = new DayOfWeek[] { DayOfWeek.Saturday, DayOfWeek.Sunday };
        private static int WorkCapacity = 8;
        public static void Main(string[] args)
        {
            DrawLines();
            Console.WriteLine("This is a test task");
            DrawLines();
            var dateService = new DateService();
            var analysisService = new AnalysisService(dateService);
            var fromDate = new DateTime(2016, 8, 22);
            var tillDate = new DateTime(2016, 9, 21);
            var project = new BaseEntity(fromDate, tillDate, 3, EntityType.Project);
            Console.WriteLine(project.ToString());
            DrawLines();
            var allocation = new BaseEntity(fromDate, tillDate, 4, EntityType.Allocation);
            Console.WriteLine(allocation.ToString());
            DrawLines();
            var projectWorkingHours = analysisService.GetWorkingHours(project, NonWorkingDays, WorkCapacity);
            Console.WriteLine($"Project working hours: {projectWorkingHours}");
            var allocationWorkingHours = analysisService.GetWorkingHours(allocation, NonWorkingDays, WorkCapacity);
            Console.WriteLine($"Allocation working hours: {allocationWorkingHours}");
            Console.WriteLine($"Project in terms of Allocation budget: {(double)projectWorkingHours / allocationWorkingHours}");
            DrawLines();
            Console.WriteLine("I calculated dates inclusively:\nI assumed that both first day and last day are included.");
            Console.ReadKey();
        }
        private static void DrawLines()
        {
            Console.WriteLine("====================");
            Console.WriteLine("====================");
        }
    }
}
