using Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System;
using Services.Operations;
using Services.Durations;
using Services.WorkHours;
using Services.Appointments;
using Services.Patients;
using System.Data;

namespace Services
{
    public class DbService : IOperationsService, IDurationsService, IWorkHoursService, IAppointmentsService, IPatientsService
    {
        private static readonly DbService instance = new DbService();
        private SqlConnection connection { get; set; }

        private DbService()
        {
            connection = new SqlConnection("Data Source=TIN\\SQLEXPRESS;Integrated Security=True; Database=StomatoloskaOrdinacija;");
        }

        public static DbService GetInstance()
        {
            return instance;
        }

        #region Operation

        public bool SaveOperation(Operation model)
        {
            try
            {
                if(model.Id > 0)
                {

                    connection.Open();
                    var cmd = ExecuteQuery($"UPDATE dbo.Operation SET Name = '{model.Name}', Code = '{model.Code}', Price = '{model.Price.ToString().Replace(',', '.')}', DurationId = {model.Duration.Id} WHERE Id = {model.Id}");

                    cmd.ExecuteNonQuery();
                    connection.Close();

                    return true;
                }
                else
                {
                    connection.Open();
                    var cmd = ExecuteQuery($"INSERT INTO dbo.Operation ([Code], [Name], [Price], [DurationId]) VALUES ('{model.Code}', '{model.Name}', '{model.Price.ToString().Replace(',', '.')}', {model.Duration.Id})");

                    cmd.ExecuteNonQuery();
                    connection.Close();

                    return true;
                }

            }
            catch
            {
                connection.Close();
                return false;
            }
        }

        public Operation GetOperation(int id)
        {
            try {
                var operation = new Operation();
                connection.Open();

                var cmd = ExecuteQuery($"SELECT * FROM [dbo].vOperation WHERE Id = {id}");

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    operation = new Operation((int)reader.GetValue(0), (string)reader.GetValue(1), (string)reader.GetValue(2), (decimal)reader.GetValue(3),
                        new Duration((int)reader.GetValue(4), (string)reader.GetValue(5), (int)reader.GetValue(6)));
                }
                reader.Close();                           

                connection.Close();
                return operation;
            }
            catch
            {
                connection.Close();
                return null;
            }   
        }

        public List<Operation> GetAllOperations()
        {
            try
            {
                var list = new List<Operation>();
                connection.Open();

                var cmd = ExecuteQuery($"SELECT * FROM [dbo].vOperation");

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Operation((int)reader.GetValue(0), (string)reader.GetValue(1), (string)reader.GetValue(2), (decimal)reader.GetValue(3),
                        new Duration((int)reader.GetValue(4), (string)reader.GetValue(5), (int)reader.GetValue(6))));
                }
                reader.Close();

                connection.Close();
                return list;
            }
            catch
            {
                connection.Close();
                return null;
            }
         
        }

        public bool DeleteOperation(int id)
        {
            try
            {
                connection.Open();
                var cmd = ExecuteQuery($"UPDATE [dbo].Operation SET Active = 0 WHERE Id = {id}");
                cmd.ExecuteNonQuery();
                connection.Close();

                return true;
            }
            catch
            {
                connection.Close();
                return false;
            }
        }

        #endregion

        #region Duration

        public List<Duration> GetAllDurations()
        {
            try
            {
                var list = new List<Duration>();
                connection.Open();

                var cmd = ExecuteQuery($"SELECT * FROM [dbo].Duration");

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Duration((int)reader.GetValue(0), (string)reader.GetValue(2), (int)reader.GetValue(3)));
                }

                connection.Close();
                return list;
            }
            catch
            {
                connection.Close();
                return null;
            }
          
        }

        #endregion

        #region Work hours

        public WorkHour GetWorkHours()
        {
            try
            {
                var radno = new WorkHour();
                connection.Open();
                    
                var cmd = ExecuteQuery($"SELECT * FROM dbo.WorkHours WHERE Id = 1");

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    radno = new WorkHour((DateTime)reader.GetValue(1), (DateTime)reader.GetValue(2));
                    
                    reader.Close();
                    connection.Close();

                    return radno;
                }

                reader.Close();
                connection.Close();

                return null;
            }
            catch
            {
                connection.Close();
                return null;
            }
        }

        public bool SaveWorkHour(WorkHour model)
        {
            try
            {
                connection.Open();
                var cmd = ExecuteQuery($"UPDATE dbo.WorkHours SET StartTime = '{FormatDate(model.StartTime)}', EndTime = '{FormatDate(model.EndTime)}' WHERE Id = 1");

                cmd.ExecuteNonQuery();
                connection.Close();

                return true;
            }
            catch
            {
                connection.Close();
                return false;
            }
        }

        #endregion

        #region Patients

        public bool SavePatient(Patient model)
        {
            try
            {
                if (model.Id > 0)
                {

                    connection.Open();
                    var cmd = ExecuteQuery($"UPDATE dbo.Patient SET FirstName = '{model.FirstName}', LastName = '{model.LastName}', DateOfBirth = '{FormatDate(model.DateOfBirth)}', Phone = '{model.Phone}', Address = '{model.Address}' WHERE Id = {model.Id}");

                    cmd.ExecuteNonQuery();
                    connection.Close();

                    return true;
                }
                else
                {
                    connection.Open();
                    var cmd = ExecuteQuery($"INSERT INTO dbo.Patient ([FirstName], [LastName], [DateOfBirth], [Phone], [Address]) VALUES ('{model.FirstName}', '{model.LastName}', '{FormatDate(model.DateOfBirth)}', '{model.Phone}', '{model.Address}')");

                    cmd.ExecuteNonQuery();
                    connection.Close();

                    return true;
                }

            }
            catch
            {
                connection.Close();
                return false;
            }
        }

        public Patient GetPatient(int id)
        {
            try
            {
                var patient = new Patient();
                connection.Open();

                var cmd = ExecuteQuery($"SELECT [Id], [FirstName], [LastName], [DateOfBirth], [Phone], [Address] FROM [dbo].Patient WHERE Active = 1 AND Id = {id}");

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    patient = new Patient((int)reader.GetValue(0), (string)reader.GetValue(1), (string)reader.GetValue(2), (DateTime)reader.GetValue(3), (string)reader.GetValue(4), (string)reader.GetValue(5));
                }
                reader.Close();

                connection.Close();
                return patient;
            }
            catch
            {
                connection.Close();
                return null;
            }
        }

        public List<Patient> GetAllPatients()
        {
            try
            {
                var list = new List<Patient>();
                connection.Open();

                var cmd = ExecuteQuery($"SELECT [Id], [FirstName], [LastName], [DateOfBirth], [Phone], [Address] FROM [dbo].Patient WHERE Active = 1");

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Patient((int)reader.GetValue(0), (string)reader.GetValue(1), (string)reader.GetValue(2), (DateTime)reader.GetValue(3), (string)reader.GetValue(4), (string)reader.GetValue(5)));
                }
                reader.Close();

                connection.Close();
                return list;
            }
            catch
            {
                connection.Close();
                return null;
            }

        }

        public bool DeletePatient(int id)
        {
            try
            {
                connection.Open();
                var cmd = ExecuteQuery($"UPDATE [dbo].Patient SET Active = 0 WHERE Id = {id}");
                cmd.ExecuteNonQuery();
                connection.Close();

                return true;
            }
            catch
            {
                connection.Close();
                return false;
            }
        }

        #endregion

        #region Appointments

        public bool SaveAppointment(Appointment model)
        {
            try
            {
                if (model.Id > 0)
                {

                    connection.Open();
                    var cmd = ExecuteQuery($"UPDATE dbo.Appointment SET Time = '{FormatDate(model.Time)}', PatientId = {model.Patient.Id}, OperationId = {model.Operation.Id} WHERE Id = {model.Id}");

                    cmd.ExecuteNonQuery();
                    connection.Close();

                    return true;
                }
                else
                {
                    connection.Open();
                    var endTime = model.Time.AddMinutes(model.Operation.Duration.DurationInMinutes);
                    var cmd = ExecuteQuery($"INSERT INTO dbo.Appointment ([Time], [Completed], [PatientId], [OperationId], [EndTime]) VALUES ('{FormatDate(model.Time)}', {0}, {model.Patient.Id}, {model.Operation.Id}, '{FormatDate(endTime)}')");

                    cmd.ExecuteNonQuery();
                    connection.Close();

                    return true;
                }

            }
            catch
            {
                connection.Close();
                return false;
            }
        }

        public Appointment GetAppointment(int id)
        {
            try
            {
                var appointment = new Appointment();
                connection.Open();

                var cmd = ExecuteQuery($"SELECT * FROM [dbo].vAppointment WHERE Id = {id}");

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    appointment = new Appointment((int)reader.GetValue(0), (bool)reader.GetValue(1), (DateTime)reader.GetValue(2),
                        new Patient((int)reader.GetValue(3), (string)reader.GetValue(4), (string)reader.GetValue(5)), 
                        new Operation((int)reader.GetValue(6), (string)reader.GetValue(7), (string)reader.GetValue(8), new Duration((int)reader.GetValue(9), (string)reader.GetValue(10))));
                }
                reader.Close();

                connection.Close();
                return appointment;
            }
            catch
            {
                connection.Close();
                return null;
            }
        }

        public List<Appointment> GetAllAppointments()
        {
            try
            {
                var list = new List<Appointment>();
                connection.Open();

                var cmd = ExecuteQuery($"SELECT * FROM [dbo].vAppointment ORDER BY Time");

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Appointment((int)reader.GetValue(0), (bool)reader.GetValue(1), (DateTime)reader.GetValue(2),
                        new Patient((int)reader.GetValue(3), (string)reader.GetValue(4), (string)reader.GetValue(5)),
                        new Operation((int)reader.GetValue(6), (string)reader.GetValue(7), (string)reader.GetValue(8), new Duration((int)reader.GetValue(9), (string)reader.GetValue(10)))));
                }
                reader.Close();

                connection.Close();
                return list;
            }
            catch
            {
                connection.Close();
                return null;
            }
        }


        public List<Appointment> GetAllAppointments(DateTime start, DateTime end)
        {
            var list = new List<Appointment>();
            try
            {
                connection.Open();

                var cmd = ExecuteQuery($"SELECT * FROM [dbo].vAppointment WHERE Time >= '{FormatDate(start)}' AND EndTime <= '{FormatDate(end)}'");

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Appointment((int)reader.GetValue(0), (bool)reader.GetValue(1), (DateTime)reader.GetValue(2),
                        new Patient((int)reader.GetValue(3), (string)reader.GetValue(4), (string)reader.GetValue(5)),
                        new Operation((int)reader.GetValue(6), (string)reader.GetValue(7), (string)reader.GetValue(8), new Duration((int)reader.GetValue(9), (string)reader.GetValue(10), (int)reader.GetValue(11)))));
                }
                reader.Close();

                connection.Close();
                return list;
            }
            catch
            {
                connection.Close();
                return list;
            }
        }

        public bool DeleteAppointment(int id)
        {
            try
            {
                connection.Open();
                var cmd = ExecuteQuery($"UPDATE [dbo].Appointment SET Active = 0 WHERE Id = {id}");
                cmd.ExecuteNonQuery();
                connection.Close();

                return true;
            }
            catch
            {
                connection.Close();
                return false;
            }
        }

        public bool CheckAvailability(int id, DateTime start, int duration)
        {
            try
            {
                var available = false;

                connection.Open();

                var endTime = start.AddMinutes(duration);

                var cmd = ExecuteQuery("CheckAvailabilitySP");

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", id));
                cmd.Parameters.Add(new SqlParameter("@Start", start));
                cmd.Parameters.Add(new SqlParameter("@End", endTime));

                available = !((int)cmd.ExecuteScalar() > 0);
                connection.Close();

                return available;
            }
            catch
            {
                connection.Close();
                return false;
            }
        }

        public bool CheckWorkHours(DateTime start, int duration)
        {
            try
            {
                var withinWorkHours = false;

                connection.Open();

                var endTime = start.AddMinutes(duration);

                var cmd = ExecuteQuery("CheckWorkHoursSP");

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Start", start));
                cmd.Parameters.Add(new SqlParameter("@End", endTime));

                withinWorkHours = (bool)cmd.ExecuteScalar();
                connection.Close();

                return withinWorkHours;
            }
            catch
            {
                connection.Close();
                return false;
            }
        }

        public bool ChangeAppointmentCompleteFlag(int id, int bitValue)
        {
            try
            {
                connection.Open();
                var cmd = ExecuteQuery($"UPDATE [dbo].Appointment SET Completed = {bitValue} WHERE Id = {id}");
                cmd.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch
            {
                connection.Close();
                return false;
            }
        }

        #endregion

        #region Private

        private SqlCommand ExecuteQuery(string cmd)
        {
            return new SqlCommand(cmd, connection);
        }

        private string FormatDate(DateTime date)
        {
            string dateString = $"{date.Year}-{date.Month}-{date.Day} {date.Hour}:{date.Minute}:{date.Second}.{0}";

            return dateString;
        }

        #endregion
    }
}
