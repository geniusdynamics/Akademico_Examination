Public Class frmDates

    Private Sub btnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGo.Click
        Dim date_ As Date = DateTimePicker1.Value.Date
        to_close = DateTimePicker1.Value.Date.Date
        to_open = DateTimePicker2.Value.Date
        attend = chkAttendance.Checked
        bar_graph = chkBarGraph.Checked
        subject_ranking_table = chkTable.Checked
        watermark = CheckBox1.Checked
        fee = chkFee.Checked
        'todo attendance hard coded to false
        attend = False
        Me.Close()
        cont = True
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        cont = False
        Me.Close()
    End Sub

    Private Sub frmDates_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not connect() Then
            Me.Close()
        Else
            DateTimePicker1.Value = get_closing()
        End If
    End Sub

    Private Function get_closing()
        Dim closing As Date = Today.Date
        new_con()
        If qread("SELECT endDate FROM term_dates WHERE Term='" & tm & "' AND Year='" & yr & "'") Then
            dbreader.Read()
            Try
                closing = dbreader("ClosingDate")
            Catch ex As Exception

            End Try
        Else
            failure("Could Not Clearly Determine The Closing Date For This Term!")
        End If
        dbreader.Close()
        Return closing
    End Function
End Class