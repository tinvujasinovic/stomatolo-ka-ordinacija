using Model;

namespace Services.WorkHours

{
    public interface IWorkHoursService
    {
        WorkHour GetWorkHours();
        bool SaveWorkHour(WorkHour model);
    }
}
