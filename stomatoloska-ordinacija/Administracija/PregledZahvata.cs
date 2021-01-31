using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stomatoloska_ordinacija.Administracija
{
    public partial class PregledZahvata : Form
    {
        public PregledZahvata()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form = new KreiranjeZahvata();
            form.Show();
        }
    }
}
