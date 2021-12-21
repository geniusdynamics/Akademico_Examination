using System;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    public partial class frmPrintFrom
    {
        public frmPrintFrom()
        {
            InitializeComponent();
            _Button1.Name = "Button1";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFrom.Text.Trim()) & !string.IsNullOrEmpty(txtTo.Text.Trim()))
            {
                publicSubsNFunctions.cont = true;
                publicSubsNFunctions.row_from = Conversions.ToInteger(txtFrom.Text);
                publicSubsNFunctions.row_to = Conversions.ToInteger(txtTo.Text);
                Close();
            }
        }

        private bool isvalid()
        {
            return default;
        }

        private void frmPrintFrom_Load(object sender, EventArgs e)
        {
        }
    }
}