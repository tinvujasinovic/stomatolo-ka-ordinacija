using System;
using System.Windows.Forms;
using Telerik.ReportViewer.WinForms;

namespace stomatoloska_ordinacija.Reports.UsedByOperation
{
    public partial class UsedByOperation : Form
    {
        public UsedByOperation()
        {
            InitializeComponent();
        }

        private void UsedByOperation_Load(object sender, EventArgs e)
        {
            reportViewer1.ViewMode = ViewMode.PrintPreview;
            reportViewer1.ShowPrintPreviewButton = false;

            reportViewer1.RefreshReport();
        }
    }
}
