
Imports DevExpress.XtraReports.UI
Imports DevExpress.Spreadsheet
Imports System.IO
Imports System.Data.Odbc

Module reporting

    Public Sub generateFromDataTable(ByVal reportTitle As String, ByVal reportType As String, Optional query As String = "", Optional myDT As DataTable = Nothing, Optional ByRef myView As DataGridView = Nothing)
        ' Create XtraReport instance
        Dim rep As New XtraReport()

        myReportTitle = reportTitle
        rep.Font = New Font(My.Settings.userFont, My.Settings.fontSize, FontStyle.Bold)

        ' Set the XtraReport.DataSource
        Dim reportDS As New DataSet()

        If reportType = "From Query" Then
            ' reportDT = generateDataTable(query, tableName)
            reportDS.Tables.Add(generateDataTable(query))
        ElseIf reportType = "From DT" Then
            If verifyColumns(myDT, rep) = False Then
                Return
            End If

            Try
                reportDS.Tables.Add(myDT)
            Catch ex As Exception
                Dim newDT = myDT.Copy()
                reportDS.Tables.Clear()
                reportDS.Tables.Add(newDT)
            End Try

        ElseIf reportType = "From Grid" Then
            Dim myTable As New DataTable()
            myTable.Rows.Clear()
            myTable.Columns.Clear()

            For k As Integer = 0 To myView.Columns.Count - 1
                If myView.Columns(k).Visible = True Then
                    myTable.Columns.Add(myView.Columns(k).HeaderText)
                End If
            Next

            If verifyColumns(myTable, rep) = False Then
                Return
            End If

            Dim myRow As New List(Of String)()

            For k As Integer = 0 To myView.Rows.Count - 1
                For j As Integer = 0 To myView.Columns.Count - 1
                    If myView.Columns(j).Visible = True Then
                        If myView.Rows(k).Cells(j).Value Is Nothing Then
                            myRow.Add(" ")
                        Else
                            myRow.Add(myView.Rows(k).Cells(j).Value.ToString())
                        End If
                    End If
                Next
                myTable.Rows.Add(myRow.ToArray())
                myRow.Clear()
            Next


            reportDS.Tables.Add(myTable)
        End If


        If reportDS.Tables(0).Columns.Count > 5 Then
            rep.Landscape = True
        End If

        rep.DataSource = reportDS
        rep.DataMember = (CType(rep.DataSource, DataSet)).Tables(0).TableName

        ' Add required bands to the Xtrareport.Bands collection
        InitBands(rep)

        ' Add requited styles to the XtraReport.StyleSheet collection
        InitStyles(rep)

        ' Arrange required controls on bands and bind the controls to data
        InitDetailsBasedonXRTable(rep)
        'If radioButton1.Checked Then
        '    ' Use XRTable to display data
        '    InitDetailsBasedonXRTable(rep)
        'Else
        '    ' Use XRLabels to display data
        '    InitDetailsBasedOnXRLabel(rep)

        'End If

        ' Create a chart, bind it to data and add to the report
        'InitChart(rep)

        ' Display the result

        rep.ShowPreviewDialog()

        reportDS.Clear()
    End Sub

    Dim columnWidth As New List(Of Integer)
    Dim myReportTitle As String = String.Empty
    Dim rowFont As New Font(Settings.Default.userFont, Settings.Default.fontSize)
    Dim colFont As New Font(Settings.Default.userFont, Settings.Default.fontSize, FontStyle.Bold)
    Dim textWidth As String = ""

    Private Function verifyColumns(ByRef dt As DataTable, ByRef myReport As XtraReport)
        successful = False
        If dt.Columns.Count > 0 Then
            successful = True
        End If

        Dim colValue As String = ""
        Dim dr As DataRow

        columnWidth.Clear()
        For j = 0 To dt.Columns.Count - 1
            columnWidth.Add(0)
            For l = 0 To dt.Rows.Count - 1
                dr = dt.Rows(l)
                colValue = dr(j).ToString()
                getWidthSize(colValue, j, rowFont)
            Next
        Next

        Dim col As DataColumn
        Dim colHeader As String = ""
        For j = 0 To dt.Columns.Count - 1
            col = dt.Columns(j)
            colHeader = col.Caption
            getWidthSize(colHeader, j, colFont)
        Next

        Dim colTotal As Integer
        For j = 0 To columnWidth.Count - 2
            columnWidth(j) = columnWidth(j) + 20
            colTotal += columnWidth(j)
        Next
        columnWidth(columnWidth.Count - 1) = (myReport.PageWidth - (myReport.Margins.Left + myReport.Margins.Right)) - colTotal

        Return successful
    End Function

    Private Sub getWidthSize(ByVal colValue As String, ByVal colIndex As Integer, ByVal appFont As Font)

        textWidth = ""
        Dim charArray As Char()
        Dim textSize As String = TextRenderer.MeasureText(colValue, appFont).ToString()
        charArray = textSize.ToCharArray()

        For i = 0 To charArray.Length - 1
            If charArray(i) = "," Then
                Exit For
            Else
                If IsNumeric(charArray(i)) Then
                    textWidth += charArray(i)
                End If
            End If
        Next

        If IsNumeric(textWidth) Then
            If CInt(textWidth) > columnWidth(colIndex) Then
                columnWidth(colIndex) = CInt(textWidth)
            End If
        End If

    End Sub

    Private Function generateDataTable(query As String) As DataTable
        Dim reportDT As New DataTable()


        Try
            Dim cmd As OdbcCommand = New OdbcCommand(query, dbconn)

            Dim dbAdapter As New OdbcDataAdapter()
            dbAdapter.SelectCommand = cmd
            dbAdapter.Fill(reportDT)

            addColumnNumbering(reportDT)
        Catch e As Exception
            MessageBox.Show(e.Message, "Error Sourcing Report Data", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End Try
        Return reportDT
    End Function

    Public Function addColumnNumbering(ByRef dt As DataTable)
        dt.Columns.Add("Count", GetType(String)).SetOrdinal(0)

        Dim counter As Integer = 1
        For Each row As DataRow In dt.Rows
            row(0) = counter.ToString()
            counter += 1
        Next

    End Function


    Public Sub InitBands(ByVal rep As XtraReport)
        ' Create bands
        Dim detail As New DetailBand()
        Dim pageHeader As New PageHeaderBand()
        Dim reportFooter As New ReportFooterBand()
        detail.Height = 20
        reportFooter.Height = 380
        pageHeader.Height = 20

        ' Place the bands onto a report
        rep.Bands.AddRange(New Band() {detail, ReportHeader(rep, myReportTitle), pageHeader, reportFooter, footerPageBand()})
    End Sub
    Public Sub InitStyles(ByVal rep As XtraReport)
        ' Create different odd and even styles
        Dim oddStyle As New XRControlStyle()
        Dim evenStyle As New XRControlStyle()

        ' Specify the odd style appearance
        '  oddStyle.BackColor = Color.LightBlue
        oddStyle.StyleUsing.UseBackColor = True
        oddStyle.StyleUsing.UseBorders = False
        oddStyle.Name = "OddStyle"

        ' Specify the even style appearance
        '   evenStyle.BackColor = Color.LightPink
        evenStyle.StyleUsing.UseBackColor = True
        evenStyle.StyleUsing.UseBorders = False
        evenStyle.Name = "EvenStyle"

        ' Add styles to report's style sheet
        rep.StyleSheet.AddRange(New DevExpress.XtraReports.UI.XRControlStyle() {oddStyle, evenStyle})
    End Sub

    Private Function footerPageBand() As PageFooterBand
        Dim pageFooterBand As New PageFooterBand()
        ' 
        ' pageInfo
        ' 
        Dim pageInfo As New XRPageInfo()
        pageInfo.LocationFloat = New DevExpress.Utils.PointFloat(269.7917F, 0F)
        pageInfo.Name = "pageInfo"
        pageInfo.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0F)
        pageInfo.SizeF = New SizeF(100.0F, 23.0F)
        pageInfo.StylePriority.UseTextAlignment = False
        pageInfo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter

        pageFooterBand.Controls.AddRange(New XRControl() {pageInfo})
        pageFooterBand.HeightF = 33.33333F
        pageFooterBand.Name = "PageFooter"
        Return pageFooterBand
    End Function

    Private Function ReportHeader(rep As XtraReport, reportTitle As String) As ReportHeaderBand
        Dim reportHeaderBand As New ReportHeaderBand()

        ' initialize the controls for the page header band
        Dim lblReportTitle As New XRLabel()
        Dim lblLocation As New XRLabel()
        Dim lblTelephonne As New XRLabel()
        Dim lblMotto As New XRLabel()
        Dim lblSchoolName As New XRLabel()
        Dim rptPictureBox As New XRPictureBox()


        ' add the controls to the page header band
        reportHeaderBand.Controls.AddRange(New XRControl() {lblReportTitle, lblLocation, lblTelephonne, lblMotto, lblSchoolName, rptPictureBox})
        reportHeaderBand.HeightF = 172.9167F

        ' determine if the logo is available so as to modify the report
        Dim schoolInformation As New Dictionary(Of String, String)()
        schoolInformation.Clear()
        schoolInformation = schoolDetails()

        Dim xPosition As Single = 0F
        If schoolInformation.ContainsKey("image_path") AndAlso File.Exists(schoolInformation("image_path")) Then
            xPosition = 202.0833F
            rptPictureBox.Image = Image.FromFile(schoolInformation("image_path"))
        ElseIf rep.Landscape = True Then
            xPosition = 202.0833F
        Else
            xPosition = 150.0F
        End If


        'position the controls on the band

        ' 
        ' lblReportTitle
        ' 
        lblReportTitle.Font = New Font(My.Settings.userFont, My.Settings.fontSize, FontStyle.Bold)
        lblReportTitle.LocationFloat = New DevExpress.Utils.PointFloat(xPosition, 129.0833F)
        lblReportTitle.Name = "lblReportTitle"
        lblReportTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0F)
        lblReportTitle.SizeF = New SizeF(398.9585F, 23.0F)
        lblReportTitle.StylePriority.UseFont = False
        lblReportTitle.StylePriority.UseTextAlignment = False
        lblReportTitle.Text = reportTitle
        lblReportTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter

        ' 
        ' lblLocation
        ' 
        lblLocation.Font = New Font(My.Settings.userFont, My.Settings.fontSize, FontStyle.Bold)
        lblLocation.LocationFloat = New DevExpress.Utils.PointFloat(xPosition, 73.08337F)
        lblLocation.Name = "lblLocation"
        lblLocation.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0F)
        lblLocation.SizeF = New System.Drawing.SizeF(398.9584F, 23.0F)
        lblLocation.StylePriority.UseFont = False
        lblLocation.StylePriority.UseTextAlignment = False

        If schoolInformation.ContainsKey("town") AndAlso schoolInformation("town") <> "--" Then
            lblLocation.Text = schoolInformation("town")
        Else
            lblLocation.Text = "SCHOOL LOCATION"
        End If
        lblLocation.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        ' 
        ' lblTelephonne
        ' 
        lblTelephonne.Font = New Font(My.Settings.userFont, My.Settings.fontSize, FontStyle.Bold)
        lblTelephonne.LocationFloat = New DevExpress.Utils.PointFloat(xPosition, 96.08329F)
        lblTelephonne.Name = "lblTelephonne"
        lblTelephonne.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0F)
        lblTelephonne.SizeF = New System.Drawing.SizeF(398.9584F, 23.0F)
        lblTelephonne.StylePriority.UseFont = False
        lblTelephonne.StylePriority.UseTextAlignment = False

        If schoolInformation.ContainsKey("telephone") AndAlso schoolInformation("telephone") <> "--" Then
            lblTelephonne.Text = schoolInformation("telephone")
        Else
            lblTelephonne.Text = "TELEPHONE"
        End If

        lblTelephonne.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        ' 
        ' lblMotto
        ' 
        lblMotto.Font = New Font(My.Settings.userFont, My.Settings.fontSize, FontStyle.Bold)
        lblMotto.LocationFloat = New DevExpress.Utils.PointFloat(xPosition, 50.08335F)
        lblMotto.Name = "lblMotto"
        lblMotto.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0F)
        lblMotto.SizeF = New System.Drawing.SizeF(398.9584F, 23.0F)
        lblMotto.StylePriority.UseFont = False
        lblMotto.StylePriority.UseTextAlignment = False

        If schoolInformation.ContainsKey("motto") AndAlso schoolInformation("motto") <> "--" Then
            lblMotto.Text = schoolInformation("motto")
        Else
            lblMotto.Text = "SCHOOL MOTTO"
        End If

        lblMotto.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        ' 
        ' lblSchoolName
        ' 
        lblSchoolName.Font = New Font(My.Settings.userFont, My.Settings.fontSize, FontStyle.Bold)
        lblSchoolName.LocationFloat = New DevExpress.Utils.PointFloat(xPosition, 27.08336F)
        lblSchoolName.Name = "lblSchoolName"
        lblSchoolName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0F)
        lblSchoolName.SizeF = New SizeF(398.9584F, 23.0F)
        lblSchoolName.StylePriority.UseFont = False
        lblSchoolName.StylePriority.UseTextAlignment = False

        If schoolInformation.ContainsKey("school_name") AndAlso schoolInformation("school_name") <> "--" Then
            lblSchoolName.Text = schoolInformation("school_name")
        Else
            lblSchoolName.Text = "SCHOOL NAME"
        End If

        lblSchoolName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        ' 
        ' rptPictureBox
        ' 
        rptPictureBox.LocationFloat = New DevExpress.Utils.PointFloat(0F, 0F)
        rptPictureBox.Name = "rptPictureBox"
        rptPictureBox.SizeF = New SizeF(150.0F, 152.0833F)
        rptPictureBox.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage


        Return reportHeaderBand

    End Function

    Public Sub InitDetailsBasedOnXRLabel(ByVal rep As XtraReport)
        Dim ds As DataSet = (CType(rep.DataSource, DataSet))
        Dim colCount As Integer = ds.Tables(0).Columns.Count
        Dim colWidth As Integer = (rep.PageWidth - (rep.Margins.Left + rep.Margins.Right)) / colCount

        ' Create header captions
        For i As Integer = 0 To colCount - 1
            Dim label As New XRLabel()
            label.Location = New Point(colWidth * i, 0)
            label.Size = New Size(colWidth, 20)
            label.Text = ds.Tables(0).Columns(i).Caption
            If i > 0 Then
                label.Borders = DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Bottom
            Else
                label.Borders = DevExpress.XtraPrinting.BorderSide.All
            End If

            ' Place the headers onto a PageHeader band
            rep.Bands(BandKind.PageHeader).Controls.Add(label)
        Next i
        ' Create data-bound labels with different odd and even backgrounds
        For i As Integer = 0 To colCount - 1
            Dim label As New XRLabel()
            label.Location = New Point(colWidth * i, 0)
            label.Size = New Size(colWidth, 20)
            label.DataBindings.Add("Text", Nothing, ds.Tables(0).Columns(i).Caption)
            label.OddStyleName = "OddStyle"
            label.EvenStyleName = "EvenStyle"
            If i > 0 Then
                label.Borders = DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom
            Else
                label.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Right Or DevExpress.XtraPrinting.BorderSide.Bottom
            End If

            ' Place the labels onto a Detail band
            rep.Bands(BandKind.Detail).Controls.Add(label)
        Next i
    End Sub
    Public Sub InitDetailsBasedonXRTable(ByVal rep As XtraReport)
        Dim ds As DataSet = (CType(rep.DataSource, DataSet))
        Dim colCount As Integer = ds.Tables(0).Columns.Count
        Dim colWidth As Integer = (rep.PageWidth - (rep.Margins.Left + rep.Margins.Right)) / colCount

        ' Create a table to represent headers
        Dim tableHeader As New XRTable()
        tableHeader.Height = 20
        tableHeader.Width = (rep.PageWidth - (rep.Margins.Left + rep.Margins.Right))
        Dim headerRow As New XRTableRow()
        headerRow.Width = tableHeader.Width
        tableHeader.Rows.Add(headerRow)

        tableHeader.BeginInit()

        ' Create a table to display data
        Dim tableDetail As New XRTable()
        tableDetail.Height = 20
        tableDetail.Width = (rep.PageWidth - (rep.Margins.Left + rep.Margins.Right))
        Dim detailRow As New XRTableRow()
        detailRow.Width = tableDetail.Width
        tableDetail.Rows.Add(detailRow)
        tableDetail.EvenStyleName = "EvenStyle"
        tableDetail.OddStyleName = "OddStyle"

        tableDetail.BeginInit()
        tableDetail.AdjustSize()

        ' Create table cells, fill the header cells with text, bind the cells to data
        For i As Integer = 0 To colCount - 1
            Dim headerCell As New XRTableCell()
            '  headerCell.Width = colWidth
            headerCell.Width = columnWidth(i)
            headerCell.Text = ds.Tables(0).Columns(i).Caption

            Dim detailCell As New XRTableCell()
            ' detailCell.Width = colWidth
            detailCell.Width = columnWidth(i)
            detailCell.DataBindings.Add("Text", Nothing, ds.Tables(0).Columns(i).Caption)
            If i = 0 Then
                headerCell.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Bottom
                detailCell.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Bottom
            Else
                headerCell.Borders = DevExpress.XtraPrinting.BorderSide.All
                detailCell.Borders = DevExpress.XtraPrinting.BorderSide.All
            End If

            ' Place the cells into the corresponding tables
            headerRow.Cells.Add(headerCell)
            detailRow.Cells.Add(detailCell)
        Next i
        tableHeader.EndInit()
        tableDetail.EndInit()
        ' Place the table onto a report's Detail band
        rep.Bands(BandKind.PageHeader).Controls.Add(tableHeader)
        rep.Bands(BandKind.Detail).Controls.Add(tableDetail)
    End Sub
    Public Sub InitChart(ByVal rep As XtraReport)
        Dim ds As DataSet = (CType(rep.DataSource, DataSet))

        ' Create a chart
        Dim xrChart1 As XRChart = New DevExpress.XtraReports.UI.XRChart()

        xrChart1.Location = New System.Drawing.Point(0, 0)
        xrChart1.Name = "xrChart1"

        ' Create chart series and bind them to data
        For i As Integer = 1 To ds.Tables(0).Columns.Count - 1
            If ds.Tables(0).Columns(i).DataType Is GetType(Integer) OrElse ds.Tables(0).Columns(i).DataType Is GetType(Double) Then
                Dim series As New DevExpress.XtraCharts.Series(ds.Tables(0).Columns(i).Caption, DevExpress.XtraCharts.ViewType.Bar)
                series.DataSource = ds.Tables(0)
                series.ArgumentDataMember = ds.Tables(0).Columns(0).Caption
                series.PointOptionsTypeName = "PointOptions"
                series.ValueDataMembers(0) = ds.Tables(0).Columns(i).Caption
                xrChart1.Series.Add(series)

            End If
        Next i
        ' Customize the chart appearance
        CType(xrChart1.Diagram, DevExpress.XtraCharts.XYDiagram).AxisX.Label.Angle = 20
        CType(xrChart1.Diagram, DevExpress.XtraCharts.XYDiagram).AxisX.Label.Font = New System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(204)))
        CType(xrChart1.Diagram, DevExpress.XtraCharts.XYDiagram).AxisX.Label.Antialiasing = True

        xrChart1.SeriesTemplate.PointOptionsTypeName = "PointOptions"
        xrChart1.Size = New System.Drawing.Size(650, 360)

        ' Place the chart onto a report footer
        rep.Bands(BandKind.ReportFooter).Controls.Add(xrChart1)
    End Sub

    Public Function schoolDetails() As Dictionary(Of String, String)
        Dim SchoolDetails__1 As New Dictionary(Of String, String)()
        If qread("SELECT * FROM `school_details`") Then
            If dbreader.RecordsAffected > 0 Then
                While dbreader.Read
                    If Not SchoolDetails__1.ContainsKey(dbreader.GetName(1)) Then
                        SchoolDetails__1.Add(dbreader.GetName(1), dbreader.GetString(1))
                    End If
                    If Not SchoolDetails__1.ContainsKey(dbreader.GetName(10)) Then
                        SchoolDetails__1.Add(dbreader.GetName(10), dbreader.GetString(10))
                    End If
                    If Not SchoolDetails__1.ContainsKey(dbreader.GetName(4)) Then
                        SchoolDetails__1.Add(dbreader.GetName(4), dbreader.GetString(4))
                    End If
                    If Not SchoolDetails__1.ContainsKey(dbreader.GetName(2)) Then
                        SchoolDetails__1.Add(dbreader.GetName(2), dbreader.GetString(2))
                    End If
                    If Not SchoolDetails__1.ContainsKey(dbreader.GetName(11)) Then
                        SchoolDetails__1.Add(dbreader.GetName(11), dbreader.GetString(11))

                    End If
                End While
            End If
        End If


        Return SchoolDetails__1
    End Function

    Public Sub exportToExcel(ByRef myView As DataGridView)
        Dim filePath As String = ""
        Dim myDialog As New SaveFileDialog()
        myDialog.Title = "Export Data"
        myDialog.FileName = "Save Where"
        If myDialog.ShowDialog() = DialogResult.OK Then
            If Not myDialog.FileName.Contains(":") Then
                failure("The File Path Is Invalid")
                Return
            End If
            filePath = myDialog.FileName
        Else
            Return
        End If

        Using New DevExpress.Utils.WaitDialogForm("Export Data")

            Dim myTable As New DataTable()
            For k As Integer = 0 To myView.Columns.Count - 1
                '  myTable.Columns.Add(myView.Columns[k].Name.ToString());
                myTable.Columns.Add(myView.Columns(k).Name.ToString()).Caption = myView.Columns(k).HeaderText
            Next

            Dim myRow As New List(Of String)()

            For k As Integer = 0 To myView.RowCount - 1
                For j As Integer = 0 To myView.Columns.Count - 1
                    If myView.Rows(k).Cells(j).Value Is Nothing Then
                        myRow.Add(" ")
                    Else
                        myRow.Add(myView.Rows(k).Cells(j).Value.ToString())
                    End If
                Next
                myTable.Rows.Add(myRow.ToArray())
                myRow.Clear()
            Next

            'You can import data to worksheet cells from different data sources (for example, arrays, lists and data tables)
            'via the worksheet's Import extension method. Worksheet extensions are defined by the WorksheetExtensions class. 
            'To enable them, add a reference to the DevExpress.Docs.v15.2.dll library and explicitly import the DevExpress.Spreadsheet 
            'namespace into your source code with a using directive (Imports in Visual Basic).

            Dim mySpreadSheet As New DevExpress.XtraSpreadsheet.SpreadsheetControl()
            Dim worksheet As Worksheet = mySpreadSheet.Document.Worksheets(0)
            worksheet.Columns.AutoFit(0, myTable.Columns.Count - 1)
            worksheet.Import(myTable, True, 0, 0)

            ' mySpreadSheet.ExportToPdf(filePath);

            mySpreadSheet.SaveDocument(filePath & ".xlsx")
        End Using
        success("The Data Was Successfully Exported To" + Environment.NewLine & filePath)


    End Sub



End Module
