using Model;
using Services;
using Services.Appointments;
using Services.Operations;
using Services.Patients;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace stomatoloska_ordinacija.App.Appointments
{
    public partial class ManageAppointment : Form
    {
        private readonly bool IsUpdate = false;
        private Appointment Appointment { get; set; }
        private readonly List<Patient> patients = new PatientsService().GetAllPatients();
        private readonly List<Operation> operations = new OperationsService().GetAllOperations();

        private readonly AppointmentsService appointmentsService = new AppointmentsService();

        public ManageAppointment()
        {
            InitializeComponent();

            inputOperation.DataSource = operations;
            inputOperation.DisplayMember = "Name";
            inputOperation.ValueMember = "Id";

            inputPatient.DataSource = patients;
            inputPatient.DisplayMember = "FullName";
            inputPatient.ValueMember = "Id";

            Odustani.Location = new Point(12, 275);

            dateTimePicker1.Value = DateTime.Now.AddHours(-dateTimePicker1.Value.Hour);
            dateTimePicker1.Value = dateTimePicker1.Value.AddMinutes(-dateTimePicker1.Value.Minute);
            dateTimePicker1.Value = dateTimePicker1.Value.AddSeconds(-dateTimePicker1.Value.Second);
            dateTimePicker1.Value = dateTimePicker1.Value.AddHours(12);
        }

        public ManageAppointment(int id)
        {
            InitializeComponent();

            button2.Visible = false;    

            inputOperation.DataSource = operations;
            inputOperation.DisplayMember = "Name";
            inputOperation.ValueMember = "Id";

            inputPatient.DataSource = patients;
            inputPatient.DisplayMember = "FullName";
            inputPatient.ValueMember = "Id";

            var appointment = appointmentsService.GetAppointment(id);

            Text = "Uredi narudžbu";
            title.Text = $"Uređivanje narudžbe";
            IsUpdate = true;
            Appointment = appointment;
            dateTimePicker1.Value = appointment.Time;

            inputOperation.SelectedItem = appointment.Operation;
            inputOperation.SelectedValue = appointment.Operation.Id;

            inputPatient.SelectedItem = appointment.Patient;
            inputPatient.SelectedValue = appointment.Patient.Id;
        }

        private void Odustani_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(inputPatient.Text))
            {
                MessageBox.Show("Odaberite pacijenta!");
                return;
            }
            else if (string.IsNullOrEmpty(inputOperation.Text))
            {
                MessageBox.Show("Odaberite zahvat!");
                return;
            }
            else if (dateTimePicker1.Value.Minute % 30 != 0)
            {
                MessageBox.Show("Početak zahvata mora biti u puni sat ili na polovici sata!");
                return;
            }

            var patient = (Patient)inputPatient.SelectedItem;
            var operation = (Operation)inputOperation.SelectedItem;

            var appointment = new Appointment(dateTimePicker1.Value, patient, operation);

            if (!appointmentsService.CheckAvailability(0, appointment.Time, operation.Duration.DurationInMinutes))
            {
                MessageBox.Show("Odabrani termin je zauzet!");
                return;
            }

            if (!appointmentsService.CheckWorkHours(appointment.Time, operation.Duration.DurationInMinutes))
            {
                MessageBox.Show("Odabrano vrijeme je izvan radnog vremena!");
                return;
            }

            if (appointmentsService.SaveAppointment(appointment))
            {
                inputOperation.SelectedItem = null;
                priceBox.Text = string.Empty;

                MessageBox.Show("Narudžba je uspješno kreirana.");
            }
            else
            {
                MessageBox.Show("Došlo je do greške!");
            }
        }

        private void inputOperation_SelectedValueChanged(object sender, EventArgs e)
        {
            if(inputOperation.SelectedItem != null)
                priceBox.Text = ((Operation)inputOperation.SelectedItem).Price.ToString();
        }

        private void dateTimePicker1_Leave(object sender, EventArgs e)
        {
            var time = dateTimePicker1.Value;
            if (time.Minute % 30 != 0)
            {
                MessageBox.Show("Početak zahvata mora biti u puni sat ili na polovici sata!");
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(inputPatient.Text))
            {
                MessageBox.Show("Odaberite pacijenta!");
                return;
            }
            else if (string.IsNullOrEmpty(inputOperation.Text))
            {
                MessageBox.Show("Odaberite zahvat!");
                return;
            }
            else if (dateTimePicker1.Value.Minute % 30 != 0)
            {
                MessageBox.Show("Početak zahvata mora biti u puni sat ili na polovici sata!");
                return;
            }

            var patient = (Patient)inputPatient.SelectedItem;
            var operation = (Operation)inputOperation.SelectedItem;

            if (IsUpdate)
            {
                Appointment.Time = dateTimePicker1.Value;
                Appointment.Patient = patient;
                Appointment.Operation = operation;

                if (!appointmentsService.CheckAvailability(Appointment.Id, Appointment.Time, Appointment.Operation.Duration.DurationInMinutes))
                {
                    MessageBox.Show("Odabrani termin je zauzet!");
                    return;
                }

                if (!appointmentsService.CheckWorkHours(Appointment.Time, operation.Duration.DurationInMinutes))
                {
                    MessageBox.Show("Odabrano vrijeme je izvan radnog vremena!");
                    return;
                }

                if (appointmentsService.SaveAppointment(Appointment))
                {
                    MessageBox.Show("Narudžba je uspješno ažurirana.");
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
                var appointment = new Appointment(dateTimePicker1.Value, patient, operation);

                if (!appointmentsService.CheckAvailability(0, appointment.Time, operation.Duration.DurationInMinutes))
                {
                    MessageBox.Show("Odabrani termin je zauzet!");
                    return;
                }

                if (!appointmentsService.CheckWorkHours(appointment.Time, operation.Duration.DurationInMinutes))
                {
                    MessageBox.Show("Odabrano vrijeme je izvan radnog vremena!");
                    return;
                }

                if (appointmentsService.SaveAppointment(appointment))
                {
                    MessageBox.Show("Narudžba je uspješno kreirana.");
                    Close();
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Došlo je do greške!");
                }
            }
        }

        private void Odustani_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
