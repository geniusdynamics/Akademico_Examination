using System;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    public partial class frmDates
    {
        public frmDates()
        {
            InitializeComponent();
            _btnCancel.Name = "btnCancel";
            _btnGo.Name = "btnGo";
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            var date_ = DateTimePicker1.Value.Date;
            publicSubsNFunctions.to_close = DateTimePicker1.Value.Date.Date;
            publicSubsNFunctions.to_open = DateTimePicker2.Value.Date;
            publicSubsNFunctions.attend = chkAttendance.Checked;
            publicSubsNFunctions.bar_graph = chkBarGraph.Checked;
            publicSubsNFunctions.subject_ranking_table = chkTable.Checked;
            publicSubsNFunctions.watermark = CheckBox1.Checked;
            publicSubsNFunctions.fee = chkFee.Checked;
            // todo attendance hard coded to false
            publicSubsNFunctions.attend = false;
            Close();
            publicSubsNFunctions.cont = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            publicSubsNFunctions.cont = false;
            Close();
        }

        private void frmDates_Load(object sender, EventArgs e)
        {
            if (!publicSubsNFunctions.connect())
            {
                Close();
            }
            else
            {
                DateTimePicker1.Value = Conversions.ToDate(get_closing());
            }
        }

        private object get_closing()
        {
            var closing = DateAndTime.Today.Date;
            publicSubsNFunctions.new_con();
            string argq = "SELECT endDate FROM term_dates WHERE Term='" + publicSubsNFunctions.tm + "' AND Year='" + publicSubsNFunctions.yr + "'";
            if (publicSubsNFunctions.qread(ref argq))
            {
                publicSubsNFunctions.dbreader.Read();
                try
                {
                    closing = Conversions.ToDate(publicSubsNFunctions.dbreader["ClosingDate"]);
                }
                catch (Exception ex)
                {
                }
            }
            else
            {
                publicSubsNFunctions.failure("Could Not Clearly Determine The Closing Date For This Term!");
            }

            publicSubsNFunctions.dbreader.Close();
            return closing;
        }
    }
}