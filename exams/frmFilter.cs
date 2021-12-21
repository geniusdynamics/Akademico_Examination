using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    public partial class frmFilter
    {
        public frmFilter()
        {
            InitializeComponent();
            _Button1.Name = "Button1";
            _txtNumber.Name = "txtNumber";
        }

        private void frmFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void frmFilter_Load(object sender, EventArgs e)
        {
            radNone.Checked = true;
            radBottom.Checked = false;
            radTop.Checked = false;
        }

        private void txtNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Strings.Asc(e.KeyChar) == 13)
            {
                if (!Information.IsNumeric(txtNumber.Text) & radNone.Checked | Information.IsNumeric(txtNumber.Text) & (radBottom.Checked | radTop.Checked))
                {
                    publicSubsNFunctions.radF = radTop.Checked;
                    publicSubsNFunctions.radL = radBottom.Checked;
                    try
                    {
                        publicSubsNFunctions.rankno = Conversions.ToInteger(txtNumber.Text);
                    }
                    catch (Exception ex)
                    {
                    }

                    Close();
                }
                else
                {
                    publicSubsNFunctions.failure("Invalid Value For Number Of Students To Filter Considering Your Choice!");
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (!(Information.IsNumeric(txtNumber.Text) & radNone.Checked) | Information.IsNumeric(txtNumber.Text) & (radBottom.Checked | radTop.Checked))
            {
                publicSubsNFunctions.radF = radTop.Checked;
                publicSubsNFunctions.radL = radBottom.Checked;
                try
                {
                    publicSubsNFunctions.rankno = Conversions.ToInteger(txtNumber.Text);
                }
                catch (Exception ex)
                {
                }

                publicSubsNFunctions.cont = true;
                Close();
            }
            else
            {
                publicSubsNFunctions.failure("Invalid Value For Number Of Students To Filter Considering Your Choice!");
            }
        }
    }
}