using Services;
using System;
using System.Windows.Forms;

namespace stomatoloska_ordinacija.Administracija.RadnoVrijeme
{
    public partial class ManageRadnoVrijeme : Form
    {
        public ManageRadnoVrijeme()
        {
            InitializeComponent();

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.ShowUpDown = true;
            dateTimePicker1.CustomFormat = "HH:mm";

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.ShowUpDown = true;
            dateTimePicker2.CustomFormat = "HH:mm";

            Model.RadnoVrijeme radnoVrijeme = DbService.GetInstance().GetRadnoVrijeme();

            if(radnoVrijeme == null)
            {
                var now = DateTime.Now;
                var pocetak = new DateTime(now.Year, now.Month, now.Day);
                pocetak = pocetak.AddHours(8);
                var kraj = new DateTime(now.Year, now.Month, now.Day);
                kraj = kraj.AddHours(16);

                dateTimePicker1.Value = pocetak;
                dateTimePicker2.Value= kraj;
            }
            else
            {
                dateTimePicker1.Value = radnoVrijeme.Pocetak;
                dateTimePicker2.Value = radnoVrijeme.Kraj;
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
            if (dbService.SaveRadnoVrijeme(new Model.RadnoVrijeme(dateTimePicker1.Value, dateTimePicker2.Value)))
            {
                MessageBox.Show("Radno vrijeme je uspješno ažurirano.");
                Close();
            }
            else
            {
                MessageBox.Show("Došlo je do greške!");
            }
        }
    }
}
