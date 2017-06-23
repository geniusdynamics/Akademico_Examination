Public Class frmMeritListConfig

    Private Sub frmMeritListConfig_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not connect() Then
            Me.Close()
        Else
            load_class(ComboBox1)
        End If
    End Sub
    Private Sub get_merit_list_configuration()
        qread("SELECT * FROM merit_list_config WHERE class='" & escape_string(ComboBox1.SelectedItem) & "'")
        If dbreader.RecordsAffected > 0 Then
            dbreader.Read()
            chkSE.Checked = dbreader("se")
            chkTP.Checked = dbreader("tp")
            chkMP.Checked = dbreader("mp")
            chkMM.Checked = dbreader("mm")
            chkMG.Checked = dbreader("mg")
            chkTM.Checked = dbreader("tm")
            chkStr.Checked = dbreader("str")
            chkSP.Checked = dbreader("sp")
            chkOP.Checked = dbreader("op")
            chkVAP.Checked = dbreader("vap")
            chkKCPE.Checked = dbreader("kcpe")
            chkIndex.Checked = dbreader("index_no")
        Else
            chkSE.Checked = False
            chkTP.Checked = False
            chkMP.Checked = False
            chkMM.Checked = False
            chkMG.Checked = False
            chkTM.Checked = False
            chkStr.Checked = False
            chkSP.Checked = False
            chkOP.Checked = False
            chkVAP.Checked = False
            chkKCPE.Checked = False
            chkIndex.Checked = False
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If qwrite("DELETE FROM merit_list_config WHERE `class` = '" & escape_string(ComboBox1.SelectedItem) & "';") And qwrite("INSERT INTO `merit_list_config` (`class`, `se`, `tp`, `mp`, `mm`, `mg`, `tm`, `str`, `sp`, `op`, `vap`, `kcpe`, `index_no`)" &
                                                                   "VALUES ('" & escape_string(ComboBox1.SelectedItem) & "', '" & chkSE.Checked & "', '" & chkTP.Checked & "', '" & chkMP.Checked & "', '" & chkMM.Checked &
                                                                   "', '" & chkMG.Checked & "', '" & chkTM.Checked & "', '" & chkStr.Checked & "', '" & chkSP.Checked &
                                                                   "', '" & chkOP.Checked & "', '" & chkVAP.Checked & "', '" & chkKCPE.Checked & "','" & chkIndex.Checked & "');") Then
            success("Configuration Details Successfully Saved!")
        Else
            failure("Configuration Details Could Not Be Saved!")
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        get_merit_list_configuration()
    End Sub
End Class