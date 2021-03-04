using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace stomatoloska_ordinacija.Reports.Forms
{
    public partial class OperationsByDate : Form
    {
        public OperationsByDate()
        {
            InitializeComponent();
        }

        private void ReportViewerForm1_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }
    }
}
