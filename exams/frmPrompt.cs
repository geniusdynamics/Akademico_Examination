using System;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    public partial class frmPrompt
    {
        public frmPrompt()
        {
            InitializeComponent();
            _btnCancel.Name = "btnCancel";
            _btnEnter.Name = "btnEnter";
        }

        private void frmPrompt_Load(object sender, EventArgs e)
        {
            if (!publicSubsNFunctions.connect())
            {
                Close();
            }
            else
            {
                string argq = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT stream FROM class_stream WHERE class='", publicSubsNFunctions.ret_name(publicSubsNFunctions.class_form)), "'"));
                publicSubsNFunctions.qread(ref argq);
                while (publicSubsNFunctions.dbreader.Read())
                    cboStream.Items.Add(publicSubsNFunctions.dbreader["stream"]);
            }
        }

        private void fill_stream(string str)
        {
            str.ToCharArray();
            int i, j;
            j = 0;
            string[] words;
            bool in_word = false;
            var loopTo = str.Length - 1;
            for (i = 0; i <= loopTo; i++)
            {
                if (Conversions.ToString(str[i]) == "=" & in_word)
                {
                    j += 1;
                    in_word = false;
                }
                else if (Conversions.ToString(str[i]) != "=" & !in_word)
                {
                    in_word = true;
                }
            }

            words = new string[j];
            j = 0;
            in_word = false;
            string temp = string.Empty;
            var loopTo1 = str.Length - 1;
            for (i = 0; i <= loopTo1; i++)
            {
                if (Conversions.ToString(str[i]) != "=")
                {
                    if (!in_word)
                    {
                        in_word = true;
                    }

                    temp += Conversions.ToString(str[i]);
                }
                else if (Conversions.ToString(str[i]) == "=")
                {
                    if (in_word)
                    {
                        in_word = false;
                        words[j] = temp;
                        temp = string.Empty;
                        j += 1;
                    }
                }
                else if (i == str.Length - 1)
                {
                    temp += Conversions.ToString(str[i]);
                    words[j] = temp;
                }
            }

            var loopTo2 = words.Length - 1;
            for (i = 0; i <= loopTo2; i++)
                cboStream.Items.Add(words[i]);
            cboStream.SelectedItem = publicSubsNFunctions.None;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
            publicSubsNFunctions.to_continue = false;
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(Operators.AndObject(Operators.ConditionalCompareObjectNotEqual(cboStream.SelectedItem, publicSubsNFunctions.None, false), Operators.ConditionalCompareObjectNotEqual(cboStream.SelectedItem, string.Empty, false))))
            {
                publicSubsNFunctions.class_stream = Conversions.ToString(cboStream.SelectedItem);
                publicSubsNFunctions.to_continue = true;
                Close();
            }
        }
    }
}