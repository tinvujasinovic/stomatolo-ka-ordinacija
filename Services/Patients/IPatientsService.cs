using System.Collections.Generic;
using Model;

namespace Services.Patients
{
    public interface IPatientsService
    {
        bool SavePatient(Patient patient);
        Patient GetPatient(int id);
        List<Patient> GetAllPatients();
        bool DeletePatient(int id);
    }
}
