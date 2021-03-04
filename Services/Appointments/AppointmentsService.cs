using Model;
using System;
using System.Collections.Generic;

namespace Services.Appointments
{
    public class AppointmentsService : IAppointmentsService
    {
        private DbService db = DbService.GetInstance();

        public AppointmentsService() { }

        public bool DeleteAppointment(int id)
        {
            return db.DeleteAppointment(id);
        }

        public List<Appointment> GetAllAppointments()
        {
            return db.GetAllAppointments();
        }

        public List<Appointment> GetAllAppointments(DateTime start, DateTime end)
        {
            return db.GetAllAppointments(start, end);
        }

        public Appointment GetAppointment(int id)
        {
            return db.GetAppointment(id);
        }

        public bool SaveAppointment(Appointment appointment)
        {
            return db.SaveAppointment(appointment);
        }

        public bool CheckAvailability(DateTime start, int duration)
        {
            return db.CheckAvailability(start, duration);
        }

        public bool ChangeAppointmentCompleteFlag(int id, int bitValue)
        {
            return db.ChangeAppointmentCompleteFlag(id, bitValue);
        }

        public bool CheckWorkHours(DateTime start, int duration)
        {
            return db.CheckWorkHours(start, duration);
        }
    }
}