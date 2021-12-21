using System;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    public partial class frmMeritListConfig
    {
        public frmMeritListConfig()
        {
            InitializeComponent();
            _ComboBox1.Name = "ComboBox1";
            _Button1.Name = "Button1";
        }

        private void frmMeritListConfig_Load(object sender, EventArgs e)
        {
            if (!publicSubsNFunctions.connect())
            {
                Close();
            }
            else
            {
                var argcbo = ComboBox1;
                publicSubsNFunctions.load_class(ref argcbo);
                ComboBox1 = argcbo;
            }
        }

        private void get_merit_list_configuration()
        {
            string argq = "SELECT * FROM merit_list_config WHERE class='" + publicSubsNFunctions.escape_string(Conversions.ToString(ComboBox1.SelectedItem)) + "'";
            publicSubsNFunctions.qread(ref argq);
            if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
            {
                publicSubsNFunctions.dbreader.Read();
                chkSE.Checked = Conversions.ToBoolean(publicSubsNFunctions.dbreader["se"]);
                chkTP.Checked = Conversions.ToBoolean(publicSubsNFunctions.dbreader["tp"]);
                chkMP.Checked = Conversions.ToBoolean(publicSubsNFunctions.dbreader["mp"]);
                chkMM.Checked = Conversions.ToBoolean(publicSubsNFunctions.dbreader["mm"]);
                chkMG.Checked = Conversions.ToBoolean(publicSubsNFunctions.dbreader["mg"]);
                chkTM.Checked = Conversions.ToBoolean(publicSubsNFunctions.dbreader["tm"]);
                chkStr.Checked = Conversions.ToBoolean(publicSubsNFunctions.dbreader["str"]);
                chkSP.Checked = Conversions.ToBoolean(publicSubsNFunctions.dbreader["sp"]);
                chkOP.Checked = Conversions.ToBoolean(publicSubsNFunctions.dbreader["op"]);
                chkVAP.Checked = Conversions.ToBoolean(publicSubsNFunctions.dbreader["vap"]);
                chkKCPE.Checked = Conversions.ToBoolean(publicSubsNFunctions.dbreader["kcpe"]);
                chkIndex.Checked = Conversions.ToBoolean(publicSubsNFunctions.dbreader["index_no"]);
            }
            else
            {
                chkSE.Checked = false;
                chkTP.Checked = false;
                chkMP.Checked = false;
                chkMM.Checked = false;
                chkMG.Checked = false;
                chkTM.Checked = false;
                chkStr.Checked = false;
                chkSP.Checked = false;
                chkOP.Checked = false;
                chkVAP.Checked = false;
                chkKCPE.Checked = false;
                chkIndex.Checked = false;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (publicSubsNFunctions.qwrite("DELETE FROM merit_list_config WHERE `class` = '" + publicSubsNFunctions.escape_string(Conversions.ToString(ComboBox1.SelectedItem)) + "';") & publicSubsNFunctions.qwrite("INSERT INTO `merit_list_config` (`class`, `se`, `tp`, `mp`, `mm`, `mg`, `tm`, `str`, `sp`, `op`, `vap`, `kcpe`, `index_no`)" + "VALUES ('" + publicSubsNFunctions.escape_string(Conversions.ToString(ComboBox1.SelectedItem)) + "', '" + chkSE.Checked + "', '" + chkTP.Checked + "', '" + chkMP.Checked + "', '" + chkMM.Checked + "', '" + chkMG.Checked + "', '" + chkTM.Checked + "', '" + chkStr.Checked + "', '" + chkSP.Checked + "', '" + chkOP.Checked + "', '" + chkVAP.Checked + "', '" + chkKCPE.Checked + "','" + chkIndex.Checked + "');"))
            {
                publicSubsNFunctions.success("Configuration Details Successfully Saved!");
            }
            else
            {
                publicSubsNFunctions.failure("Configuration Details Could Not Be Saved!");
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            get_merit_list_configuration();
        }
    }
}