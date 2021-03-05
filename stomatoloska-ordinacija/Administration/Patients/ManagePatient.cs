using Model;
using Services.Patients;
using System;
using System.Windows.Forms;

namespace stomatoloska_ordinacija.Administration.Patients
{
    public partial class ManagePatient : Form
    {
        private readonly bool IsUpdate = false;
        private Patient Patient { get; set; }

        private readonly PatientsService patientsService = new PatientsService();

        public ManagePatient()
        {
            InitializeComponent();

            inputDOB.MaxDate = DateTime.Now;
        }

        public ManagePatient(int id)
        {
            InitializeComponent();

            inputDOB.MaxDate = DateTime.Now;

            var patient = patientsService.GetPatient(id);

            Text = "Uredi pacijenta";
            title.Text = $"Uređivanje pacijenta";
            IsUpdate = true;
            Patient = patient;

            inputFirstName.Text = patient.FirstName;
            inputLastName.Text = patient.LastName;
            inputDOB.Value = patient.DateOfBirth;
            inputPhone.Text = patient.Phone;
            inputAddress.Text = patient.Address;
        }


        private void Spremi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(inputFirstName.Text))
            {
                MessageBox.Show("Unesite ime!");
                return;
            }
            else if (string.IsNullOrEmpty(inputLastName.Text))
            {
                MessageBox.Show("Unesite prezime!");
                return;
            }
            else if (string.IsNullOrEmpty(inputPhone.Text))
            {
                MessageBox.Show("Unesite telefon!");
                return;
            }

            if (IsUpdate)
            {
                Patient.FirstName = inputFirstName.Text;
                Patient.LastName = inputLastName.Text;
                Patient.DateOfBirth = inputDOB.Value;
                Patient.Phone = inputPhone.Text;
                Patient.Address = inputAddress.Text;

                if (patientsService.SavePatient(Patient))
                {
                    MessageBox.Show("Pacijent je uspješno ažuriran.");
                    Close();
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Došlo je do greške!");
                }
            }
            else
            {
                var patient = new Patient(0, inputFirstName.Text.Trim(), inputLastName.Text.Trim(), inputDOB.Value, inputPhone.Text, inputAddress.Text);

                if (patientsService.SavePatient(patient))
                {
                    MessageBox.Show("Pacijent je uspješno kreiran.");
                    Close();
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Došlo je do greške!");
                }
            }
        }

        private void Odustani_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
