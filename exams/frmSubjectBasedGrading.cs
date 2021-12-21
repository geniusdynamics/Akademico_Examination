using System;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    public partial class frmSubjectBasedGrading
    {
        public frmSubjectBasedGrading()
        {
            InitializeComponent();
            _btnSave.Name = "btnSave";
            _cboClass.Name = "cboClass";
            _cboYear.Name = "cboYear";
            _cboTerm.Name = "cboTerm";
            _cboSubject.Name = "cboSubject";
        }

        private void frmSubjectBasedGrading_Load(object sender, EventArgs e)
        {
            if (!publicSubsNFunctions.connect())
            {
                Close();
                return;
            }

            var argcbo = cboYear;
            publicSubsNFunctions.fill_years(ref argcbo);
            cboYear = argcbo;
            var argcbo1 = cboClass;
            publicSubsNFunctions.load_class(ref argcbo1);
            cboClass = argcbo1;
            var argcbo2 = cboSubject;
            publicSubsNFunctions.load_subjects(ref argcbo2);
            cboSubject = argcbo2;
        }

        private object isvalid()
        {
            if (cboClass.SelectedItem is null)
            {
                msg = "No Class Selected!";
                return false;
            }

            if (Information.IsNumeric(Strings.Trim(txtAstart.Text)))
            {
                if (Conversions.ToInteger(txtAstart.Text) > 100 | Conversions.ToInteger(Strings.Trim(txtAstart.Text)) < 0)
                {
                    msg = "Invalid Value For Grade A Minimum!";
                    return false;
                }
            }
            else
            {
                msg = "Invalid Value For Grade A!";
                return false;
            }

            if (Information.IsNumeric(Strings.Trim(txtAminstart.Text)))
            {
                if (Conversions.ToInteger(Strings.Trim(txtAminstart.Text)) >= Conversions.ToInteger(Strings.Trim(txtAstart.Text)) | Conversions.ToInteger(Strings.Trim(txtAminstart.Text)) < 0)
                {
                    msg = "Grade A- Cannot Be Greater Than Grade A Or Less Than 0";
                    return false;
                }
            }
            else
            {
                msg = "Invalid Value For Grade A-!";
                return false;
            }

            if (Information.IsNumeric(Strings.Trim(txtBplusstart.Text)))
            {
                if (Conversions.ToInteger(Strings.Trim(txtBplusstart.Text)) >= Conversions.ToInteger(Strings.Trim(txtAminstart.Text)) | Conversions.ToInteger(Strings.Trim(txtBplusstart.Text)) < 0)
                {
                    msg = "Grade B+ Cannot Be Greater Than Grade A- Or Less Than 0";
                    return false;
                }
            }
            else
            {
                msg = "Invalid Value For Grade B+!";
                return false;
            }

            if (Information.IsNumeric(Strings.Trim(txtBstart.Text)))
            {
                if (Conversions.ToInteger(Strings.Trim(txtBstart.Text)) >= Conversions.ToInteger(Strings.Trim(txtBplusstart.Text)) | Conversions.ToInteger(Strings.Trim(txtBstart.Text)) < 0)
                {
                    msg = "Grade B Cannot Be Greater Than Grade B+ Or Less Than 0";
                    return false;
                }
            }
            else
            {
                msg = "Invalid Value For Grade B!";
                return false;
            }

            if (Information.IsNumeric(Strings.Trim(txtBminstart.Text)))
            {
                if (Conversions.ToInteger(Strings.Trim(txtBminstart.Text)) >= Conversions.ToInteger(Strings.Trim(txtBstart.Text)) | Conversions.ToInteger(Strings.Trim(txtBminstart.Text)) < 0)
                {
                    msg = "Grade B- Cannot Be Greater Than Grade B Or Less Than 0";
                    return false;
                }
            }
            else
            {
                msg = "Invalid Value For Grade B-!";
                return false;
            }

            if (Information.IsNumeric(Strings.Trim(txtCplusstart.Text)))
            {
                if (Conversions.ToInteger(Strings.Trim(txtCplusstart.Text)) >= Conversions.ToInteger(Strings.Trim(txtBstart.Text)) | Conversions.ToInteger(Strings.Trim(txtCplusstart.Text)) < 0)
                {
                    msg = "Grade C+ Cannot Be Greater Than Grade B- Or Less Than 0";
                    return false;
                }
            }
            else
            {
                msg = "Invalid Value For Grade C+!";
                return false;
            }

            if (Information.IsNumeric(Strings.Trim(txtCstart.Text)))
            {
                if (Conversions.ToInteger(Strings.Trim(txtCstart.Text)) >= Conversions.ToInteger(Strings.Trim(txtCplusstart.Text)) | Conversions.ToInteger(Strings.Trim(txtCstart.Text)) < 0)
                {
                    msg = "Grade C Cannot Be Greater Than Grade C+ Or Less Than 0";
                    return false;
                }
            }
            else
            {
                msg = "Invalid Value For Grade C!";
                return false;
            }

            if (Information.IsNumeric(Strings.Trim(txtCminstart.Text)))
            {
                if (Conversions.ToInteger(Strings.Trim(txtCminstart.Text)) >= Conversions.ToInteger(Strings.Trim(txtCstart.Text)) | Conversions.ToInteger(Strings.Trim(txtCminstart.Text)) < 0)
                {
                    msg = "Grade C- Cannot Be Greater Than Grade C Or Less Than 0";
                    return false;
                }
            }
            else
            {
                msg = "Invalid Value For Grade C-!";
                return false;
            }

            if (Information.IsNumeric(Strings.Trim(txtDplusstart.Text)))
            {
                if (Conversions.ToInteger(Strings.Trim(txtDplusstart.Text)) >= Conversions.ToInteger(Strings.Trim(txtCminstart.Text)) | Conversions.ToInteger(Strings.Trim(txtDplusstart.Text)) < 0)
                {
                    msg = "Grade D+ Cannot Be Greater Than Grade C- Or Less Than 0";
                    return false;
                }
            }
            else
            {
                msg = "Invalid Value For Grade D+!";
                return false;
            }

            if (Information.IsNumeric(Strings.Trim(txtDstart.Text)))
            {
                if (Conversions.ToInteger(Strings.Trim(txtDstart.Text)) >= Conversions.ToInteger(Strings.Trim(txtDplusstart.Text)) | Conversions.ToInteger(Strings.Trim(txtDstart.Text)) < 0)
                {
                    msg = "Grade D Cannot Be Greater Than Grade D+ Or Less Than 0";
                    return false;
                }
            }
            else
            {
                msg = "Invalid Value For Grade D!";
                return false;
            }

            if (Information.IsNumeric(Strings.Trim(txtDminstart.Text)))
            {
                if (Conversions.ToInteger(Strings.Trim(txtDminstart.Text)) >= Conversions.ToInteger(Strings.Trim(txtDstart.Text)) | Conversions.ToInteger(Strings.Trim(txtDminstart.Text)) < 0)
                {
                    msg = "Grade D- Cannot Be Greater Than Grade D Or Less Than 0";
                    return false;
                }
            }
            else
            {
                msg = "Invalid Value For Grade D-!";
                return false;
            }

            if (Information.IsNumeric(Strings.Trim(txtEstart.Text)))
            {
                if (Conversions.ToInteger(Strings.Trim(txtEstart.Text)) >= Conversions.ToInteger(Strings.Trim(txtDminstart.Text)) | Conversions.ToInteger(Strings.Trim(txtEstart.Text)) < 0)
                {
                    msg = "Grade E Cannot Be Greater Than Grade D- Or Less Than 0";
                    return false;
                }
            }
            else
            {
                msg = "Invalid Value For Grade E!";
                return false;
            }

            if ((Strings.Trim(txtAComment.Text) ?? "") == (string.Empty ?? ""))
            {
                msg = "No Comment For Grade A!";
                return false;
            }
            else if ((Strings.Trim(txtAMinusComment.Text) ?? "") == (string.Empty ?? ""))
            {
                msg = "No Comment For Grade A-!";
                return false;
            }
            else if ((Strings.Trim(txtBPlusComment.Text) ?? "") == (string.Empty ?? ""))
            {
                msg = "No Comment For Grade B+!";
                return false;
            }
            else if ((Strings.Trim(txtBComment.Text) ?? "") == (string.Empty ?? ""))
            {
                msg = "No Comment For Grade B!";
                return false;
            }
            else if ((Strings.Trim(txtBMinusComment.Text) ?? "") == (string.Empty ?? ""))
            {
                msg = "No Comment For Grade B-!";
                return false;
            }
            else if ((Strings.Trim(txtCPlusComment.Text) ?? "") == (string.Empty ?? ""))
            {
                msg = "No Comment For Grade C+!";
                return false;
            }
            else if ((Strings.Trim(txtCComment.Text) ?? "") == (string.Empty ?? ""))
            {
                msg = "No Comment For Grade C!";
                return false;
            }
            else if ((Strings.Trim(txtCMinusComment.Text) ?? "") == (string.Empty ?? ""))
            {
                msg = "No Comment For Grade C-!";
                return false;
            }
            else if ((Strings.Trim(txtDPlusComment.Text) ?? "") == (string.Empty ?? ""))
            {
                msg = "No Comment For Grade D+!";
                return false;
            }
            else if ((Strings.Trim(txtDComment.Text) ?? "") == (string.Empty ?? ""))
            {
                msg = "No Comment For Grade D!";
                return false;
            }
            else if ((Strings.Trim(txtDMinusComment.Text) ?? "") == (string.Empty ?? ""))
            {
                msg = "No Comment For Grade D-!";
                return false;
            }
            else if ((Strings.Trim(txtEComment.Text) ?? "") == (string.Empty ?? ""))
            {
                msg = "No Comment For Grade E!";
                return false;
            }

            return true;
        }

        private string msg = string.Empty;
        private string test = string.Empty;

        private void load_grade()
        {
            string argq1 = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT * FROM s_grading WHERE (Class='", cboClass.SelectedItem), "' AND Subject='"), cboSubject.SelectedItem), "' AND term='"), cboTerm.SelectedItem), "' AND year='"), cboYear.SelectedItem), "')"));
            if (publicSubsNFunctions.qread(ref argq1))
            {
                if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
                {
                    publicSubsNFunctions.dbreader.Read();
                    txtAstart.Text = Conversions.ToString(publicSubsNFunctions.dbreader["A"]);
                    txtAminstart.Text = Conversions.ToString(publicSubsNFunctions.dbreader["A-"]);
                    txtBplusstart.Text = Conversions.ToString(publicSubsNFunctions.dbreader["B+"]);
                    txtBstart.Text = Conversions.ToString(publicSubsNFunctions.dbreader["B"]);
                    txtBminstart.Text = Conversions.ToString(publicSubsNFunctions.dbreader["B-"]);
                    txtCplusstart.Text = Conversions.ToString(publicSubsNFunctions.dbreader["C+"]);
                    txtCstart.Text = Conversions.ToString(publicSubsNFunctions.dbreader["C"]);
                    txtCminstart.Text = Conversions.ToString(publicSubsNFunctions.dbreader["C-"]);
                    txtDplusstart.Text = Conversions.ToString(publicSubsNFunctions.dbreader["D+"]);
                    txtDstart.Text = Conversions.ToString(publicSubsNFunctions.dbreader["D"]);
                    txtDminstart.Text = Conversions.ToString(publicSubsNFunctions.dbreader["D-"]);
                    txtEstart.Text = Conversions.ToString(publicSubsNFunctions.dbreader["E"]);
                    string argq = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("SELECT * FROM s_grading_comments WHERE (Class='", cboClass.SelectedItem), "' AND Subject='"), cboSubject.SelectedItem), "' AND term='"), cboTerm.SelectedItem), "' AND year='"), cboYear.SelectedItem), "')"));
                    publicSubsNFunctions.qread(ref argq);
                    publicSubsNFunctions.dbreader.Read();
                    txtAComment.Text = Conversions.ToString(publicSubsNFunctions.dbreader["A"]);
                    txtAMinusComment.Text = Conversions.ToString(publicSubsNFunctions.dbreader["A-"]);
                    txtBPlusComment.Text = Conversions.ToString(publicSubsNFunctions.dbreader["B+"]);
                    txtBComment.Text = Conversions.ToString(publicSubsNFunctions.dbreader["B"]);
                    txtBMinusComment.Text = Conversions.ToString(publicSubsNFunctions.dbreader["B-"]);
                    txtCPlusComment.Text = Conversions.ToString(publicSubsNFunctions.dbreader["C+"]);
                    txtCComment.Text = Conversions.ToString(publicSubsNFunctions.dbreader["C"]);
                    txtCMinusComment.Text = Conversions.ToString(publicSubsNFunctions.dbreader["C-"]);
                    txtDPlusComment.Text = Conversions.ToString(publicSubsNFunctions.dbreader["D+"]);
                    txtDComment.Text = Conversions.ToString(publicSubsNFunctions.dbreader["D"]);
                    txtDMinusComment.Text = Conversions.ToString(publicSubsNFunctions.dbreader["D-"]);
                    txtEComment.Text = Conversions.ToString(publicSubsNFunctions.dbreader["E"]);
                    btnSave.Text = "Update";
                }
                else
                {
                    btnSave.Text = "Save";
                }
            }
            else
            {
                publicSubsNFunctions.failure("Could Not Read Grading Scheme!");
            }
        }

        private void clear()
        {
            txtAstart.Clear();
            txtAminstart.Clear();
            txtBplusstart.Clear();
            txtBstart.Clear();
            txtBminstart.Clear();
            txtCplusstart.Clear();
            txtCstart.Clear();
            txtCminstart.Clear();
            txtDplusstart.Clear();
            txtDstart.Clear();
            txtDminstart.Clear();
            txtEstart.Clear();
            txtAComment.Clear();
            txtBComment.Clear();
            txtAMinusComment.Clear();
            txtBPlusComment.Clear();
            txtBMinusComment.Clear();
            txtCPlusComment.Clear();
            txtCComment.Clear();
            txtCMinusComment.Clear();
            txtDPlusComment.Clear();
            txtDComment.Clear();
            txtDMinusComment.Clear();
            txtEComment.Clear();
        }

        private void cboClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboClass.SelectedItem is object & cboSubject.SelectedItem is object & cboYear.SelectedItem is object & cboTerm.SelectedItem is object)
            {
                load_grade();
            }
            else
            {
                clear();
            }
        }

        private void cboSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboClass.SelectedItem is object & cboSubject.SelectedItem is object & cboYear.SelectedItem is object & cboTerm.SelectedItem is object)
            {
                load_grade();
            }
            else
            {
                clear();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(!isvalid()))
            {
                publicSubsNFunctions.failure(msg);
                return;
            }

            publicSubsNFunctions.start();
            if (btnSave.Text == "Save")
            {
                if (publicSubsNFunctions.qwrite(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("INSERT INTO s_grading VALUES(NULL, '", cboClass.SelectedItem), "', '"), cboSubject.SelectedItem), "', '"), Strings.Trim(txtAstart.Text)), "', '"), Strings.Trim(txtAminstart.Text)), "','"), Strings.Trim(txtBplusstart.Text)), "','"), Strings.Trim(txtBstart.Text)), "','"), Strings.Trim(txtBminstart.Text)), "','"), Strings.Trim(txtCplusstart.Text)), "','"), Strings.Trim(txtCstart.Text)), "','"), Strings.Trim(txtCminstart.Text)), "','"), Strings.Trim(txtDplusstart.Text)), "','"), Strings.Trim(txtDstart.Text)), "','"), Strings.Trim(txtDminstart.Text)), "','"), Strings.Trim(txtEstart.Text)), "', '"), cboYear.SelectedItem), "', '"), cboTerm.SelectedItem), "')"))) & publicSubsNFunctions.qwrite(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("INSERT INTO s_grading_comments VALUES(NULL, '", cboClass.SelectedItem), "','"), publicSubsNFunctions.escape_string(Conversions.ToString(cboSubject.SelectedItem))), "','"), publicSubsNFunctions.escape_string(txtAComment.Text)), "', '"), publicSubsNFunctions.escape_string(txtAMinusComment.Text)), "','"), publicSubsNFunctions.escape_string(txtBPlusComment.Text)), "','"), publicSubsNFunctions.escape_string(txtBComment.Text)), "','"), publicSubsNFunctions.escape_string(txtBMinusComment.Text)), "','"), publicSubsNFunctions.escape_string(txtCPlusComment.Text)), "','"), publicSubsNFunctions.escape_string(txtCComment.Text)), "','"), publicSubsNFunctions.escape_string(txtCMinusComment.Text)), "','"), publicSubsNFunctions.escape_string(txtDPlusComment.Text)), "','"), publicSubsNFunctions.escape_string(txtDComment.Text)), "','"), publicSubsNFunctions.escape_string(txtDMinusComment.Text)), "','"), publicSubsNFunctions.escape_string(txtEComment.Text)), "', '"), cboYear.SelectedItem), "', '"), cboTerm.SelectedItem), "')"))))
                {
                    publicSubsNFunctions.commit();
                    publicSubsNFunctions.success("Grading Scheme Successfully Saved!");
                }
                else
                {
                    publicSubsNFunctions.rollback();
                    publicSubsNFunctions.failure("Grading Scheme Saving Failed! Duplicate Entry For Same Class!");
                }
            }
            else if (publicSubsNFunctions.qwrite(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("UPDATE s_grading SET `A`='" + Strings.Trim(txtAstart.Text).ToUpper() + "', `A-`='" + Strings.Trim(txtAminstart.Text).ToUpper() + "',`B+`='" + Strings.Trim(txtBplusstart.Text) + "',`B`='" + Strings.Trim(txtBstart.Text).ToUpper() + "',`B-`='" + Strings.Trim(txtBminstart.Text).ToUpper() + "',`C+`='" + Strings.Trim(txtCplusstart.Text).ToUpper() + "',`C`='" + Strings.Trim(txtCstart.Text).ToUpper() + "',`C-`='" + Strings.Trim(txtCminstart.Text).ToUpper() + "',`D+`='" + Strings.Trim(txtDplusstart.Text).ToUpper() + "',`D`='" + Strings.Trim(txtDstart.Text).ToUpper() + "',`D-`='" + Strings.Trim(txtDminstart.Text).ToUpper() + "',`E`='" + Strings.Trim(txtEstart.Text).ToUpper() + "' WHERE (Class='", cboClass.SelectedItem), "' AND Subject='"), cboSubject.SelectedItem), "' AND term='"), cboTerm.SelectedItem), "' AND year='"), cboYear.SelectedItem), "')"))) & publicSubsNFunctions.qwrite(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject("UPDATE s_grading_comments SET `A`='" + publicSubsNFunctions.escape_string(txtAMinusComment.Text) + "', `A-`='" + publicSubsNFunctions.escape_string(txtAMinusComment.Text) + "',`B+`='" + publicSubsNFunctions.escape_string(txtBPlusComment.Text) + "',`B`='" + publicSubsNFunctions.escape_string(txtBComment.Text) + "',`B-`='" + publicSubsNFunctions.escape_string(txtBMinusComment.Text) + "',`C+`='" + publicSubsNFunctions.escape_string(txtCPlusComment.Text) + "',`C`='" + publicSubsNFunctions.escape_string(txtCComment.Text) + "',`C-`='" + publicSubsNFunctions.escape_string(txtCMinusComment.Text) + "',`D+`='" + publicSubsNFunctions.escape_string(txtDPlusComment.Text) + "',`D`='" + publicSubsNFunctions.escape_string(txtDComment.Text) + "',`D-`='" + publicSubsNFunctions.escape_string(txtDMinusComment.Text) + "',`E`='" + publicSubsNFunctions.escape_string(txtEComment.Text) + "' WHERE (Class='", cboClass.SelectedItem), "' AND Subject='"), cboSubject.SelectedItem), "' AND term='"), cboTerm.SelectedItem), "' AND year='"), cboYear.SelectedItem), "')"))))
            {
                publicSubsNFunctions.commit();
                publicSubsNFunctions.success("Grading Scheme Successfully Updated!");
            }
            else
            {
                publicSubsNFunctions.rollback();
                publicSubsNFunctions.failure("Grading Scheme Update Failed!");
            }
        }

        private void cboTerm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboClass.SelectedItem is object & cboSubject.SelectedItem is object & cboYear.SelectedItem is object & cboTerm.SelectedItem is object)
            {
                load_grade();
            }
            else
            {
                clear();
            }
        }

        private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboClass.SelectedItem is object & cboSubject.SelectedItem is object & cboYear.SelectedItem is object & cboTerm.SelectedItem is object)
            {
                load_grade();
            }
            else
            {
                clear();
            }
        }
    }
}