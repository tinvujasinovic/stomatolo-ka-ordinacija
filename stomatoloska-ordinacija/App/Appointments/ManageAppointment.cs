using Model;
using Services;
using System.Collections.Generic;
using System.Windows.Forms;

namespace stomatoloska_ordinacija.App.Appointments
{
    public partial class ManageAppointment : Form
    {
        private readonly bool IsUpdate = false;
        private Appointment Appointment { get; set; }
        private readonly List<Patient> patients = DbService.GetInstance().GetAllPatients();
        private readonly List<Operation> operations = DbService.GetInstance().GetAllOperations();

        public ManageAppointment()
        {
            InitializeComponent();
        }
    }
}
