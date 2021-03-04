using System;
using System.Windows.Forms;
using Telerik.ReportViewer.WinForms;

namespace stomatoloska_ordinacija.Reports.UnusedByOperation
{
    public partial class UnusedByOperation : Form
    {
        public UnusedByOperation()
        {
            InitializeComponent();
        }

        private void UnusedByOperation_Load(object sender, EventArgs e)
        {
            reportViewer1.ViewMode = ViewMode.PrintPreview;
            reportViewer1.ShowPrintPreviewButton = false;

            reportViewer1.RefreshReport();
        }
    }
}
