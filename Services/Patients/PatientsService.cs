using Model;
using System.Collections.Generic;

namespace Services.Patients
{
    public class PatientsService : IPatientsService
    {
        private DbService db = DbService.GetInstance();

        public PatientsService(){}

        public bool DeletePatient(int id)
        {
            return db.DeletePatient(id);
        }

        public List<Patient> GetAllPatients()
        {
            return db.GetAllPatients();
        }

        public Patient GetPatient(int id)
        {
            return db.GetPatient(id);
        }

        public bool SavePatient(Patient patient)
        {
            return db.SavePatient(patient);
        }
    }
}
