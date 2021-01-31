using stomatoloska_ordinacija.Administracija;
using System;
using System.Windows.Forms;

namespace stomatoloska_ordinacija
{
    public partial class Početna : Form
    {
        public Početna()
        {
            InitializeComponent();
        }

        private void novaNarudžbaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void zahvatiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new PregledZahvata();
            form.Show();
        }
    }
}
