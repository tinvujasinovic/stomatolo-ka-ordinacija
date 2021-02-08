using Model;
using System;
using Services;
using System.Windows.Forms;
using System.Collections.Generic;

namespace stomatoloska_ordinacija.Administracija.Zahvati
{
    public partial class ManageZahvata : Form
    {
        private bool IsUpdate = false;
        private Zahvat Zahvat { get; set; }
        private List<Trajanje> trajanja = DbService.GetInstance().GetAllTrajanja();

        public ManageZahvata()
        {
            InitializeComponent();

            inputCijena.Maximum = decimal.MaxValue;
            inputTrajanje.DataSource = trajanja;
            inputTrajanje.DisplayMember = "Naziv";
            inputTrajanje.ValueMember = "Id";

        }

        public ManageZahvata(int id)
        {
            InitializeComponent();

            inputCijena.Maximum = decimal.MaxValue;
            inputTrajanje.DataSource = trajanja;
            inputTrajanje.DisplayMember = "Naziv";
            inputTrajanje.ValueMember = "Id";

            var zahvat = DbService.GetInstance().GetZahvat(id);

            Name = "Uredi zahvat";
            title.Text = $"Uređivanje zahtjeva";
            IsUpdate = true;
            Zahvat = zahvat;

            inputSifra.Text = zahvat.Šifra;
            inputNaziv.Text = zahvat.Naziv;
            inputCijena.Value = zahvat.Cijena;
            inputTrajanje.SelectedItem = zahvat.Trajanje;
            inputTrajanje.SelectedValue = zahvat.Trajanje.Id;

            inputCijena.Maximum = decimal.MaxValue;
        }


        private void Spremi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(inputSifra.Text))
            {
                MessageBox.Show("Unesite šifru!");
                return;
            }
            else if (string.IsNullOrEmpty(inputNaziv.Text))
            {
                MessageBox.Show("Unesite naziv!");
                return;
            }
            else if (string.IsNullOrEmpty(inputCijena.Text))
            {
                MessageBox.Show("Unesite cijenu!");
                return;
            }
            else if (string.IsNullOrEmpty(inputTrajanje.Text))
            {
                MessageBox.Show("Odaberite trajanje!");
                return;
            }

            if (IsUpdate)
            {
                Zahvat.Šifra = inputSifra.Text;
                Zahvat.Naziv = inputNaziv.Text;
                Zahvat.Cijena = inputCijena.Value;
                Zahvat.Trajanje = (Trajanje)inputTrajanje.SelectedItem;

                DbService dbService = DbService.GetInstance();
                if (dbService.SaveZahvat(Zahvat))
                {
                    MessageBox.Show("Zahvat je uspješno ažuriran.");
                    Close();
                }
                else
                {
                    MessageBox.Show("Došlo je do greške!");
                }
            }
            else
            {
                var zahvat = new Zahvat(0, inputNaziv.Text.Trim(), inputSifra.Text.Trim(), inputCijena.Value, (Trajanje)inputTrajanje.SelectedItem);
                DbService dbService = DbService.GetInstance();
                dbService.SaveZahvat(zahvat);

                MessageBox.Show("Zahvat je uspješno kreiran!");
                Close();
            }
        }

        private void Odustani_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
