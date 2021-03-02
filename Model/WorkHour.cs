using System;

namespace Model
{
    public class WorkHour
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }


        public WorkHour(DateTime startTime, DateTime endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }

        public WorkHour()
        {

        }
    }
}
