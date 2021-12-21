using System;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    public partial class frmConfigureModem
    {
        public frmConfigureModem()
        {
            InitializeComponent();
            _Button1.Name = "Button1";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(publicSubsNFunctions.confirm("An sms will be sent to your phone and you'll be required to confirm once you receive it. Proceed?")))
            {
                configure();
            }
        }

        private object SMSEngine;

        private void configure()
        {
            publicSubsNFunctions.trying = true;
            for (int k = 1; k <= 30; k++)
            {
                string argCOMMPORT = "COM" + k;
                SMSEngine = new sms(ref argCOMMPORT);
                if (Conversions.ToBoolean(SMSEngine.isOpen()))
                {
                    SMSEngine.SendSMS(txtPhone.Text, "Configuration Test Message");
                    if (Conversions.ToBoolean(publicSubsNFunctions.confirm("Did you get a message?")))
                    {
                        if (publicSubsNFunctions.qwrite("UPDATE sms SET port='COM" + k + "'"))
                        {
                            publicSubsNFunctions.success("Your SMS Configuration Was Successful!");
                            SMSEngine.Close();
                            Close();
                        }

                        break;
                    }
                }
            }

            publicSubsNFunctions.trying = false;
        }
    }
}