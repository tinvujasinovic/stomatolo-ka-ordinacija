using Model;
using Services.Zahvati;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace stomatoloska_ordinacija.Administracija
{
    public partial class PregledZahvata : Form
    {
        private List<Zahvat> zahvati = new List<Zahvat>();
        private ZahvatService service = new ZahvatService();

        public PregledZahvata()
        {
            InitializeComponent();

            listView1.View = View.Details;
            SetData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form = new ManageZahvata();
            form.ShowDialog();
            SetData();
        }

        private void SetData()
        {
            zahvati = service.GetAllZahvat();
            listView1.Items.Clear();
            foreach (var item in zahvati)
            {
                string[] row = { item.Id.ToString(), item.Šifra, item.Naziv, item.Cijena.ToString(), item.Trajanje.Naziv, "Obriši" };
                var listItem = new ListViewItem(row);

                listView1.Items.Add(listItem);
            }
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            Point mousePosition = listView1.PointToClient(MousePosition);
            ListViewHitTestInfo hit = listView1.HitTest(mousePosition);
            var item = hit.Item;
            int columnindex = item.SubItems.IndexOf(hit.SubItem);

            if(columnindex == 5)
            {
                var result = MessageBox.Show("Jeste li sigurni da želite obrisati ovaj zahvat?", "Brisanje zahvata",  MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    if (service.DeleteZahvat(int.Parse(item.SubItems[0].Text)))
                    {
                        MessageBox.Show("Zahvat je uspješno obrisan.");
                        listView1.Items.Remove(item);
                    }
                    else
                        MessageBox.Show("Došlo je do greške!");
                }
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Point mousePosition = listView1.PointToClient(MousePosition);
            ListViewHitTestInfo hit = listView1.HitTest(mousePosition);
            var item = hit.Item;

            Form uredi = new ManageZahvata(int.Parse(item.SubItems[0].Text));
            var result = uredi.ShowDialog();

            if(result == DialogResult.OK)
            {
                SetData();
            }

        }
    }
}
