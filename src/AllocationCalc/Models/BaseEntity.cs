using System;
namespace AllocationCalc.Models
{
    public class BaseEntity
    {
        public DateTime FromDate { get; }
        public DateTime TillDate { get; }
        public EntityType Type { get; }
        public int NumOfFullTimeEmployees { get; }
        public BaseEntity(DateTime fromDate, DateTime tillDate, int numOfFullTimeEmp, EntityType type)
        {
            if (fromDate > tillDate)
                throw new ArgumentException("tillDate cannot be earlier in time than fromDate");
            FromDate = fromDate.Date;
            TillDate = tillDate.Date;
            NumOfFullTimeEmployees = numOfFullTimeEmp;
            Type = type;
        }
        public override string ToString()
        {
            return $"({Type.ToString()})\nStart: {FromDate.ToString("yyyy-MM-dd")}\nEnd: {TillDate.ToString("yyyy-MM-dd")}\nFull time employees: {NumOfFullTimeEmployees}";
        }
    }
}
