using Model;
using Services;
using System;
using System.Windows.Forms;

namespace stomatoloska_ordinacija.Administration.WorkHours
{
    public partial class ManageWorkHours : Form
    {
        public ManageWorkHours()
        {
            InitializeComponent();

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.ShowUpDown = true;
            dateTimePicker1.CustomFormat = "HH:mm";

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.ShowUpDown = true;
            dateTimePicker2.CustomFormat = "HH:mm";

            WorkHour workHours = DbService.GetInstance().GetWorkHours();

            if(workHours == null)
            {
                var now = DateTime.Now;
                var start = new DateTime(now.Year, now.Month, now.Day);
                start = start.AddHours(8);
                var end = new DateTime(now.Year, now.Month, now.Day);
                end = end.AddHours(16);

                dateTimePicker1.Value = start;
                dateTimePicker2.Value= end;
            }
            else
            {
                dateTimePicker1.Value = workHours.StartTime;
                dateTimePicker2.Value = workHours.EndTime;
            }
        }

        private void Odustani_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (dateTimePicker1.Value.Minute % 30 != 0 || dateTimePicker2.Value.Minute % 30 != 0)
            {
                MessageBox.Show("Minute radnog vremena postavite na 0 ili 30!");
                return;
            }

            DbService dbService = DbService.GetInstance();
            if (dbService.SaveWorkHour(new WorkHour(dateTimePicker1.Value, dateTimePicker2.Value)))
            {
                MessageBox.Show("Radno vrijeme je uspješno ažurirano.");
                Close();
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Došlo je do greške!");
            }
        }
    }
}
