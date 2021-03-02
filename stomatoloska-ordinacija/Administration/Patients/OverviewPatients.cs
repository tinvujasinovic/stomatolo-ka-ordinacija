using Model;
using Services.Patients;
using System.Collections.Generic;
using System.Drawing;
using  System.Windows.Forms;

namespace stomatoloska_ordinacija.Administration.Patients
{
    public partial class OverviewPatients : Form
    {
        private List<Patient> patients = new List<Patient>();
        private PatientsService service = new PatientsService();

        public OverviewPatients()
        {
            InitializeComponent();

            listView1.View = View.Details;
            SetData();
        }


        private void SetData()
        {
            patients = service.GetAllPatients();
            listView1.Items.Clear();
            foreach (var item in patients)
            {
                string[] row = { item.Id.ToString(), item.FirstName, item.LastName, item.DateOfBirth.ToString("d"), item.Phone, item.Address, "Obriši" };
                var listItem = new ListViewItem(row)
                {
                    UseItemStyleForSubItems = false
                };

                listItem.SubItems[6].ForeColor = Color.Red;

                listView1.Items.Add(listItem);
            }
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            Point mousePosition = listView1.PointToClient(MousePosition);
            ListViewHitTestInfo hit = listView1.HitTest(mousePosition);
            var item = hit.Item;
            int columnindex = item.SubItems.IndexOf(hit.SubItem);

            if (columnindex == 6)
            {
                var result = MessageBox.Show("Jeste li sigurni da želite obrisati ovog pacijenta?", "Brisanje pacijenta", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    if (service.DeletePatient(int.Parse(item.SubItems[0].Text)))
                    {
                        MessageBox.Show("Pacijent je uspješno obrisan.");
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

            Form uredi = new ManagePatient(int.Parse(item.SubItems[0].Text));
            var result = uredi.ShowDialog();

            if (result == DialogResult.OK)
            {
                SetData();
            }

        }

        private void novi_Click(object sender, System.EventArgs e)
        {
            Form form = new ManagePatient();
            form.ShowDialog();
            SetData();
        }
    }
}
