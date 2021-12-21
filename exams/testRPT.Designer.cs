using System.Diagnostics;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    [DesignerGenerated()]
    public partial class testRPT : DevExpress.XtraReports.UI.XtraReport
    {

        // XtraReport overrides dispose to clean up the component list.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            if (disposing && components is object)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        // Required by the Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Designer
        // It can be modified using the Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Detail = new DevExpress.XtraReports.UI.DetailBand();
            TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            ((System.ComponentModel.ISupportInitialize)this).BeginInit();
            Detail.Name = "Detail";
            TopMargin.Height = 100;
            TopMargin.Name = "TopMargin";
            BottomMargin.Height = 100;
            BottomMargin.Name = "BottomMargin";
            Bands.AddRange(new DevExpress.XtraReports.UI.Band[] { Detail, TopMargin, BottomMargin });
            ((System.ComponentModel.ISupportInitialize)this).EndInit();
        }

        internal DevExpress.XtraReports.UI.DetailBand Detail;
        internal DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        internal DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    }
}