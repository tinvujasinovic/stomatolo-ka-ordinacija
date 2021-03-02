using Model;
using Services.Operations;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace stomatoloska_ordinacija.Administration.Operations
{
    public partial class OverviewOperations : Form
    {
        private List<Operation> operations = new List<Operation>();
        private OperationsService service = new OperationsService();

        public OverviewOperations()
        {
            InitializeComponent();

            listView1.View = View.Details;
            SetData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form = new ManageOperation();
            form.ShowDialog();
            SetData();
        }

        private void SetData()
        {
            operations = service.GetAllOperations();
            listView1.Items.Clear();
            foreach (var item in operations)
            {
                string[] row = { item.Id.ToString(), item.Code, item.Name, item.Price.ToString(), item.Duration.Name, "Obriši" };
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

            if(columnindex == 5)
            {
                var result = MessageBox.Show("Jeste li sigurni da želite obrisati ovaj zahvat?", "Brisanje zahvata",  MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    if (service.DeleteOperation(int.Parse(item.SubItems[0].Text)))
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

            Form uredi = new ManageOperation(int.Parse(item.SubItems[0].Text));
            var result = uredi.ShowDialog();

            if(result == DialogResult.OK)
            {
                SetData();
            }

        }
    }
}
