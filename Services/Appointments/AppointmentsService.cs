using Model;

namespace Services.Appointments
{
    public class AppointmentsService : IAppointmentsService
    {
        private DbService db = DbService.GetInstance();

    }
}