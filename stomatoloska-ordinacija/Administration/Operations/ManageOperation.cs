using Model;
using System;
using Services;
using System.Windows.Forms;
using System.Collections.Generic;
using Services.Operations;
using Services.Durations;

namespace stomatoloska_ordinacija.Administration.Operations
{
    public partial class ManageOperation : Form
    {
        private readonly bool IsUpdate = false;
        private Operation Operation { get; set; }
        private readonly List<Duration> durations = new DurationsService().GetAllDurations();

        private readonly OperationsService operationsService = new OperationsService();

        public ManageOperation()
        {
            InitializeComponent();

            inputPrice.Maximum = decimal.MaxValue;
            inputDuration.DataSource = durations;
            inputDuration.DisplayMember = "Name";
            inputDuration.ValueMember = "Id";

        }

        public ManageOperation(int id)
        {
            InitializeComponent();

            inputPrice.Maximum = decimal.MaxValue;
            inputDuration.DataSource = durations;
            inputDuration.DisplayMember = "Name";
            inputDuration.ValueMember = "Id";

            var operation = operationsService.GetOperation(id);

            Text = "Uredi zahvat";
            title.Text = $"Uređivanje zahvata";
            IsUpdate = true;
            Operation = operation;

            inputCode.Text = operation.Code;
            inputName.Text = operation.Name;
            inputPrice.Value = operation.Price;
            inputDuration.SelectedItem = operation.Duration;
            inputDuration.SelectedValue = operation.Duration.Id;

            inputPrice.Maximum = decimal.MaxValue;
        }


        private void Spremi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(inputCode.Text))
            {
                MessageBox.Show("Unesite šifru!");
                return;
            }
            else if (string.IsNullOrEmpty(inputName.Text))
            {
                MessageBox.Show("Unesite naziv!");
                return;
            }
            else if (string.IsNullOrEmpty(inputPrice.Text))
            {
                MessageBox.Show("Unesite cijenu!");
                return;
            }
            else if (string.IsNullOrEmpty(inputDuration.Text))
            {
                MessageBox.Show("Odaberite trajanje!");
                return;
            }

            if (IsUpdate)
            {
                Operation.Code = inputCode.Text;
                Operation.Name = inputName.Text;
                Operation.Price = inputPrice.Value;
                Operation.Duration = (Duration)inputDuration.SelectedItem;

                if (operationsService.SaveOperation(Operation))
                {
                    MessageBox.Show("Zahvat je uspješno ažuriran.");
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
                var operation = new Operation(0, inputName.Text.Trim(), inputCode.Text.Trim(), inputPrice.Value, (Duration)inputDuration.SelectedItem);

                if (operationsService.SaveOperation(operation))
                {
                    MessageBox.Show("Zahvat je uspješno kreiran.");
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
