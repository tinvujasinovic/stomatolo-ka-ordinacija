using Model;
using System;
using Services;
using System.Windows.Forms;
using System.Collections.Generic;

namespace stomatoloska_ordinacija.Administracija
{
    public partial class KreiranjeZahvata : Form
    {
        private bool IsUpdate = false;
        private Zahvat Zahvat { get; set; }
        private List<Trajanje> trajanja;

        public KreiranjeZahvata()
        {
            InitializeComponent();
            trajanja = DbService.GetInstance().GetAllTrajanja();
        }

        public KreiranjeZahvata(Zahvat zahvat)
        {
            InitializeComponent();
            trajanja = DbService.GetInstance().GetAllTrajanja();

            title.Text = $"Uređivanje zahtjeva:\n {zahvat.Naziv}";
            IsUpdate = true;
            Zahvat = zahvat;

            inputSifra.Text = zahvat.Šifra;
            inputNaziv.Text = zahvat.Naziv;
            inputCijena.Value = zahvat.Cijena;
            inputTrajanje.SelectedItem = zahvat.Trajanje;
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

                var zahvat = new Zahvat(Zahvat.Id, inputNaziv.Text.Trim(), inputSifra.Text.Trim(), inputCijena.Value, (Trajanje)inputTrajanje.SelectedItem);
                //TODO: Save
                //Save zahvat
                MessageBox.Show("Zahvat je uspješno ažuriran!");
            }
            else
            {
                var zahvat = new Zahvat(0, inputNaziv.Text.Trim(), inputSifra.Text.Trim(), inputCijena.Value, (Trajanje)inputTrajanje.SelectedItem);
                DbService dbService = DbService.GetInstance();
                dbService.SaveZahvat(zahvat);

                MessageBox.Show("Zahvat je uspješno kreiran!");
            }
        }

        private void Odustani_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
