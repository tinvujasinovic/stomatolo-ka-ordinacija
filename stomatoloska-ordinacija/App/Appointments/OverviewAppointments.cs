using Model;
using Services.Appointments;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace stomatoloska_ordinacija.App.Appointments
{
    public partial class OverviewAppointments : Form
    {
        private List<Appointment> appointments = new List<Appointment>();
        private AppointmentsService service = new AppointmentsService();

        public OverviewAppointments()
        {
            InitializeComponent();

            listView1.View = View.Details;
            SetData();
        }

        private void SetData()
        {
            appointments = service.GetAllAppointments();
            listView1.Items.Clear();
            foreach (var item in appointments)
            {
                string[] row = { item.Id.ToString(), item.Patient.FullName, item.Operation.Name, item.Time.ToString("g"), item.Operation.Duration.Name, "Obriši" };
                var listItem = new ListViewItem(row)
                {
                    UseItemStyleForSubItems = false
                };

                listItem.SubItems[5].ForeColor = Color.Red;

                listView1.Items.Add(listItem);
            }
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            Point mousePosition = listView1.PointToClient(MousePosition);
            ListViewHitTestInfo hit = listView1.HitTest(mousePosition);
            var item = hit.Item;
            int columnindex = item.SubItems.IndexOf(hit.SubItem);

            if (columnindex == 5)
            {
                var result = MessageBox.Show("Jeste li sigurni da želite obrisati ovu narudžbu?", "Brisanje narudžbe", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    if (service.DeleteAppointment(int.Parse(item.SubItems[0].Text)))
                    {
                        MessageBox.Show("Narudžba je uspješno obrisana.");
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

            Form uredi = new ManageAppointment(int.Parse(item.SubItems[0].Text));
            var result = uredi.ShowDialog();

            if (result == DialogResult.OK)
            {
                SetData();
            }

        }

        private void novi_Click(object sender, EventArgs e)
        {
            Form form = new ManageAppointment();
            form.ShowDialog();
            SetData();
        }
    }
}
