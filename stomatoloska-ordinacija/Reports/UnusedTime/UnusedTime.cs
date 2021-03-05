using System;
using System.Windows.Forms;
using Telerik.ReportViewer.WinForms;

namespace stomatoloska_ordinacija.Reports.UnusedTime
{
    public partial class UnusedTime : Form
    {
        public UnusedTime()
        {
            InitializeComponent();
        }

        private void ReportViewerForm1_Load(object sender, EventArgs e)
        {
            reportViewer1.ViewMode = ViewMode.PrintPreview;
            reportViewer1.ShowPrintPreviewButton = false;

            reportViewer1.RefreshReport();
        }
    }
}
