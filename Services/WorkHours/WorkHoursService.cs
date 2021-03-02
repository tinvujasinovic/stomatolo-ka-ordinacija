using Model;

namespace Services.WorkHours
{
    public class WorkHoursService : IWorkHoursService
    {
        private DbService db = DbService.GetInstance();

        public WorkHour GetWorkHours()
        {
            return db.GetWorkHours();
        }

        public bool SaveWorkHour(WorkHour model)
        {
            return db.SaveWorkHour(model);
        }
    }
}
