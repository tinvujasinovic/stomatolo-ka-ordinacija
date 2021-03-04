using Model;
using System;
using System.Collections.Generic;

namespace Services.Appointments
{
    public interface IAppointmentsService
    {
        bool SaveAppointment(Appointment appointment);
        Appointment GetAppointment(int id);
        List<Appointment> GetAllAppointments();
        List<Appointment> GetAllAppointments(DateTime start, DateTime end);
        bool DeleteAppointment(int id);
        bool CheckAvailability(DateTime start, int duration);
        bool ChangeAppointmentCompleteFlag(int id, int bitValue);
        bool CheckWorkHours(DateTime start, int duration);
    }
}
