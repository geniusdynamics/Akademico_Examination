using System;
using System.Collections.Generic;
using System.Data;
using global::System.Data.Odbc;
using System.Drawing;
using global::System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using global::DevExpress.Spreadsheet;
using global::DevExpress.XtraReports.UI;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace exams
{
    static class reporting
    {
        public static void generateFromDataTable(string reportTitle, string reportType, string query = "", DataTable myDT = null, [Optional, DefaultParameterValue(null)] ref DataGridView myView)
        {
            // Create XtraReport instance
            var rep = new XtraReport();
            myReportTitle = reportTitle;
            rep.Font = new Font(My.MySettingsProperty.Settings.userFont, My.MySettingsProperty.Settings.fontSize, FontStyle.Bold);

            // Set the XtraReport.DataSource
            var reportDS = new DataSet();
            if (reportType == "From Query")
            {
                // reportDT = generateDataTable(query, tableName)
                reportDS.Tables.Add(generateDataTable(query));
            }
            else if (reportType == "From DT")
            {
                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(verifyColumns(ref myDT, ref rep), false, false)))
                {
                    return;
                }

                try
                {
                    reportDS.Tables.Add(myDT);
                }
                catch (Exception ex)
                {
                    var newDT = myDT.Copy();
                    reportDS.Tables.Clear();
                    reportDS.Tables.Add(newDT);
                }
            }
            else if (reportType == "From Grid")
            {
                var myTable = new DataTable();
                myTable.Rows.Clear();
                myTable.Columns.Clear();
                for (int k = 0, loopTo = myView.Columns.Count - 1; k <= loopTo; k++)
                {
                    if (myView.Columns[k].Visible == true)
                    {
                        myTable.Columns.Add(myView.Columns[k].HeaderText);
                    }
                }

                if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(verifyColumns(ref myTable, ref rep), false, false)))
                {
                    return;
                }

                var myRow = new List<string>();
                for (int k = 0, loopTo1 = myView.Rows.Count - 1; k <= loopTo1; k++)
                {
                    for (int j = 0, loopTo2 = myView.Columns.Count - 1; j <= loopTo2; j++)
                    {
                        if (myView.Columns[j].Visible == true)
                        {
                            if (myView.Rows[k].Cells[j].Value is null)
                            {
                                myRow.Add(" ");
                            }
                            else
                            {
                                myRow.Add(myView.Rows[k].Cells[j].Value.ToString());
                            }
                        }
                    }

                    myTable.Rows.Add(myRow.ToArray());
                    myRow.Clear();
                }

                reportDS.Tables.Add(myTable);
            }

            if (reportDS.Tables[0].Columns.Count > 5)
            {
                rep.Landscape = true;
            }

            rep.DataSource = reportDS;
            rep.DataMember = ((DataSet)rep.DataSource).Tables[0].TableName;

            // Add required bands to the Xtrareport.Bands collection
            InitBands(rep);

            // Add requited styles to the XtraReport.StyleSheet collection
            InitStyles(rep);

            // Arrange required controls on bands and bind the controls to data
            InitDetailsBasedonXRTable(rep);
            // If radioButton1.Checked Then
            // ' Use XRTable to display data
            // InitDetailsBasedonXRTable(rep)
            // Else
            // ' Use XRLabels to display data
            // InitDetailsBasedOnXRLabel(rep)

            // End If

            // Create a chart, bind it to data and add to the report
            // InitChart(rep)

            // Display the result

            rep.ShowPreviewDialog();
            reportDS.Clear();
        }

        private static List<int> columnWidth = new List<int>();
        private static string myReportTitle = string.Empty;
        private static Font rowFont = new Font(Settings.Default.userFont, Settings.Default.fontSize);
        private static Font colFont = new Font(Settings.Default.userFont, Settings.Default.fontSize, FontStyle.Bold);
        private static string textWidth = string.Empty;

        private static object verifyColumns(ref DataTable dt, ref XtraReport myReport)
        {
            publicSubsNFunctions.successful = false;
            if (dt.Columns.Count > 0)
            {
                publicSubsNFunctions.successful = true;
            }

            string colValue = string.Empty;
            DataRow dr;
            columnWidth.Clear();
            for (int j = 0, loopTo = dt.Columns.Count - 1; j <= loopTo; j++)
            {
                columnWidth.Add(0);
                for (int l = 0, loopTo1 = dt.Rows.Count - 1; l <= loopTo1; l++)
                {
                    dr = dt.Rows[l];
                    colValue = dr[j].ToString();
                    getWidthSize(colValue, j, rowFont);
                }
            }

            DataColumn col;
            string colHeader = string.Empty;
            for (int j = 0, loopTo2 = dt.Columns.Count - 1; j <= loopTo2; j++)
            {
                col = dt.Columns[j];
                colHeader = col.Caption;
                getWidthSize(colHeader, j, colFont);
            }

            var colTotal = default(int);
            for (int j = 0, loopTo3 = columnWidth.Count - 2; j <= loopTo3; j++)
            {
                columnWidth[j] = columnWidth[j] + 20;
                colTotal += columnWidth[j];
            }

            columnWidth[columnWidth.Count - 1] = myReport.PageWidth - (myReport.Margins.Left + myReport.Margins.Right) - colTotal;
            return publicSubsNFunctions.successful;
        }

        private static void getWidthSize(string colValue, int colIndex, Font appFont)
        {
            textWidth = string.Empty;
            char[] charArray;
            string textSize = TextRenderer.MeasureText(colValue, appFont).ToString();
            charArray = textSize.ToCharArray();
            for (int i = 0, loopTo = charArray.Length - 1; i <= loopTo; i++)
            {
                if (Conversions.ToString(charArray[i]) == ",")
                {
                    break;
                }
                else if (Information.IsNumeric(charArray[i]))
                {
                    textWidth += Conversions.ToString(charArray[i]);
                }
            }

            if (Information.IsNumeric(textWidth))
            {
                if (Conversions.ToInteger(textWidth) > columnWidth[colIndex])
                {
                    columnWidth[colIndex] = Conversions.ToInteger(textWidth);
                }
            }
        }

        private static DataTable generateDataTable(string query)
        {
            var reportDT = new DataTable();
            try
            {
                var cmd = new OdbcCommand(query, publicSubsNFunctions.dbconn);
                var dbAdapter = new OdbcDataAdapter();
                dbAdapter.SelectCommand = cmd;
                dbAdapter.Fill(reportDT);
                addColumnNumbering(ref reportDT);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error Sourcing Report Data", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

            return reportDT;
        }

        public static object addColumnNumbering(ref DataTable dt)
        {
            dt.Columns.Add("Count", typeof(string)).SetOrdinal(0);
            int counter = 1;
            foreach (DataRow row in dt.Rows)
            {
                row[0] = counter.ToString();
                counter += 1;
            }

            return default;
        }

        public static void InitBands(XtraReport rep)
        {
            // Create bands
            var detail = new DetailBand();
            var pageHeader = new PageHeaderBand();
            var reportFooter = new ReportFooterBand();
            detail.Height = 20;
            reportFooter.Height = 380;
            pageHeader.Height = 20;

            // Place the bands onto a report
            rep.Bands.AddRange(new Band[] { detail, ReportHeader(rep, myReportTitle), pageHeader, reportFooter, footerPageBand() });
        }

        public static void InitStyles(XtraReport rep)
        {
            // Create different odd and even styles
            var oddStyle = new XRControlStyle();
            var evenStyle = new XRControlStyle();

            // Specify the odd style appearance
            // oddStyle.BackColor = Color.LightBlue
            oddStyle.StyleUsing.UseBackColor = true;
            oddStyle.StyleUsing.UseBorders = false;
            oddStyle.Name = "OddStyle";

            // Specify the even style appearance
            // evenStyle.BackColor = Color.LightPink
            evenStyle.StyleUsing.UseBackColor = true;
            evenStyle.StyleUsing.UseBorders = false;
            evenStyle.Name = "EvenStyle";

            // Add styles to report's style sheet
            rep.StyleSheet.AddRange(new XRControlStyle[] { oddStyle, evenStyle });
        }

        private static PageFooterBand footerPageBand()
        {
            var pageFooterBand = new PageFooterBand();
            // 
            // pageInfo
            // 
            var pageInfo = new XRPageInfo();
            pageInfo.LocationFloat = new DevExpress.Utils.PointFloat(269.7917f, 0f);
            pageInfo.Name = "pageInfo";
            pageInfo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            pageInfo.SizeF = new SizeF(100.0f, 23.0f);
            pageInfo.StylePriority.UseTextAlignment = false;
            pageInfo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            pageFooterBand.Controls.AddRange(new XRControl[] { pageInfo });
            pageFooterBand.HeightF = 33.33333f;
            pageFooterBand.Name = "PageFooter";
            return pageFooterBand;
        }

        private static ReportHeaderBand ReportHeader(XtraReport rep, string reportTitle)
        {
            var reportHeaderBand = new ReportHeaderBand();

            // initialize the controls for the page header band
            var lblReportTitle = new XRLabel();
            var lblLocation = new XRLabel();
            var lblTelephonne = new XRLabel();
            var lblMotto = new XRLabel();
            var lblSchoolName = new XRLabel();
            var rptPictureBox = new XRPictureBox();


            // add the controls to the page header band
            reportHeaderBand.Controls.AddRange(new XRControl[] { lblReportTitle, lblLocation, lblTelephonne, lblMotto, lblSchoolName, rptPictureBox });
            reportHeaderBand.HeightF = 172.9167f;

            // determine if the logo is available so as to modify the report
            var schoolInformation = new Dictionary<string, string>();
            schoolInformation.Clear();
            schoolInformation = schoolDetails();
            float xPosition = 0f;
            if (schoolInformation.ContainsKey("image_path") && File.Exists(schoolInformation["image_path"]))
            {
                xPosition = 202.0833f;
                rptPictureBox.Image = Image.FromFile(schoolInformation["image_path"]);
            }
            else if (rep.Landscape == true)
            {
                xPosition = 202.0833f;
            }
            else
            {
                xPosition = 150.0f;
            }


            // position the controls on the band

            // 
            // lblReportTitle
            // 
            lblReportTitle.Font = new Font(My.MySettingsProperty.Settings.userFont, My.MySettingsProperty.Settings.fontSize, FontStyle.Bold);
            lblReportTitle.LocationFloat = new DevExpress.Utils.PointFloat(xPosition, 129.0833f);
            lblReportTitle.Name = "lblReportTitle";
            lblReportTitle.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            lblReportTitle.SizeF = new SizeF(398.9585f, 23.0f);
            lblReportTitle.StylePriority.UseFont = false;
            lblReportTitle.StylePriority.UseTextAlignment = false;
            lblReportTitle.Text = reportTitle;
            lblReportTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;

            // 
            // lblLocation
            // 
            lblLocation.Font = new Font(My.MySettingsProperty.Settings.userFont, My.MySettingsProperty.Settings.fontSize, FontStyle.Bold);
            lblLocation.LocationFloat = new DevExpress.Utils.PointFloat(xPosition, 73.08337f);
            lblLocation.Name = "lblLocation";
            lblLocation.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            lblLocation.SizeF = new SizeF(398.9584f, 23.0f);
            lblLocation.StylePriority.UseFont = false;
            lblLocation.StylePriority.UseTextAlignment = false;
            if (schoolInformation.ContainsKey("town") && schoolInformation["town"] != "--")
            {
                lblLocation.Text = schoolInformation["town"];
            }
            else
            {
                lblLocation.Text = "SCHOOL LOCATION";
            }

            lblLocation.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lblTelephonne
            // 
            lblTelephonne.Font = new Font(My.MySettingsProperty.Settings.userFont, My.MySettingsProperty.Settings.fontSize, FontStyle.Bold);
            lblTelephonne.LocationFloat = new DevExpress.Utils.PointFloat(xPosition, 96.08329f);
            lblTelephonne.Name = "lblTelephonne";
            lblTelephonne.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            lblTelephonne.SizeF = new SizeF(398.9584f, 23.0f);
            lblTelephonne.StylePriority.UseFont = false;
            lblTelephonne.StylePriority.UseTextAlignment = false;
            if (schoolInformation.ContainsKey("telephone") && schoolInformation["telephone"] != "--")
            {
                lblTelephonne.Text = schoolInformation["telephone"];
            }
            else
            {
                lblTelephonne.Text = "TELEPHONE";
            }

            lblTelephonne.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lblMotto
            // 
            lblMotto.Font = new Font(My.MySettingsProperty.Settings.userFont, My.MySettingsProperty.Settings.fontSize, FontStyle.Bold);
            lblMotto.LocationFloat = new DevExpress.Utils.PointFloat(xPosition, 50.08335f);
            lblMotto.Name = "lblMotto";
            lblMotto.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            lblMotto.SizeF = new SizeF(398.9584f, 23.0f);
            lblMotto.StylePriority.UseFont = false;
            lblMotto.StylePriority.UseTextAlignment = false;
            if (schoolInformation.ContainsKey("motto") && schoolInformation["motto"] != "--")
            {
                lblMotto.Text = schoolInformation["motto"];
            }
            else
            {
                lblMotto.Text = "SCHOOL MOTTO";
            }

            lblMotto.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lblSchoolName
            // 
            lblSchoolName.Font = new Font(My.MySettingsProperty.Settings.userFont, My.MySettingsProperty.Settings.fontSize, FontStyle.Bold);
            lblSchoolName.LocationFloat = new DevExpress.Utils.PointFloat(xPosition, 27.08336f);
            lblSchoolName.Name = "lblSchoolName";
            lblSchoolName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0f);
            lblSchoolName.SizeF = new SizeF(398.9584f, 23.0f);
            lblSchoolName.StylePriority.UseFont = false;
            lblSchoolName.StylePriority.UseTextAlignment = false;
            if (schoolInformation.ContainsKey("school_name") && schoolInformation["school_name"] != "--")
            {
                lblSchoolName.Text = schoolInformation["school_name"];
            }
            else
            {
                lblSchoolName.Text = "SCHOOL NAME";
            }

            lblSchoolName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // rptPictureBox
            // 
            rptPictureBox.LocationFloat = new DevExpress.Utils.PointFloat(0f, 0f);
            rptPictureBox.Name = "rptPictureBox";
            rptPictureBox.SizeF = new SizeF(150.0f, 152.0833f);
            rptPictureBox.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            return reportHeaderBand;
        }

        public static void InitDetailsBasedOnXRLabel(XtraReport rep)
        {
            DataSet ds = (DataSet)rep.DataSource;
            int colCount = ds.Tables[0].Columns.Count;
            int colWidth = (int)Math.Round((rep.PageWidth - (rep.Margins.Left + rep.Margins.Right)) / (double)colCount);

            // Create header captions
            for (int i = 0, loopTo = colCount - 1; i <= loopTo; i++)
            {
                var label = new XRLabel();
                label.Location = new Point(colWidth * i, 0);
                label.Size = new Size(colWidth, 20);
                label.Text = ds.Tables[0].Columns[i].Caption;
                if (i > 0)
                {
                    label.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom;
                }
                else
                {
                    label.Borders = DevExpress.XtraPrinting.BorderSide.All;
                }

                // Place the headers onto a PageHeader band
                rep.Bands[BandKind.PageHeader].Controls.Add(label);
            }
            // Create data-bound labels with different odd and even backgrounds
            for (int i = 0, loopTo1 = colCount - 1; i <= loopTo1; i++)
            {
                var label = new XRLabel();
                label.Location = new Point(colWidth * i, 0);
                label.Size = new Size(colWidth, 20);
                label.DataBindings.Add("Text", null, ds.Tables[0].Columns[i].Caption);
                label.OddStyleName = "OddStyle";
                label.EvenStyleName = "EvenStyle";
                if (i > 0)
                {
                    label.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom;
                }
                else
                {
                    label.Borders = DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom;
                }

                // Place the labels onto a Detail band
                rep.Bands[BandKind.Detail].Controls.Add(label);
            }
        }

        public static void InitDetailsBasedonXRTable(XtraReport rep)
        {
            DataSet ds = (DataSet)rep.DataSource;
            int colCount = ds.Tables[0].Columns.Count;
            int colWidth = (int)Math.Round((rep.PageWidth - (rep.Margins.Left + rep.Margins.Right)) / (double)colCount);

            // Create a table to represent headers
            var tableHeader = new XRTable();
            tableHeader.Height = 20;
            tableHeader.Width = rep.PageWidth - (rep.Margins.Left + rep.Margins.Right);
            var headerRow = new XRTableRow();
            headerRow.Width = tableHeader.Width;
            tableHeader.Rows.Add(headerRow);
            tableHeader.BeginInit();

            // Create a table to display data
            var tableDetail = new XRTable();
            tableDetail.Height = 20;
            tableDetail.Width = rep.PageWidth - (rep.Margins.Left + rep.Margins.Right);
            var detailRow = new XRTableRow();
            detailRow.Width = tableDetail.Width;
            tableDetail.Rows.Add(detailRow);
            tableDetail.EvenStyleName = "EvenStyle";
            tableDetail.OddStyleName = "OddStyle";
            tableDetail.BeginInit();
            tableDetail.AdjustSize();

            // Create table cells, fill the header cells with text, bind the cells to data
            for (int i = 0, loopTo = colCount - 1; i <= loopTo; i++)
            {
                var headerCell = new XRTableCell();
                // headerCell.Width = colWidth
                headerCell.Width = columnWidth[i];
                headerCell.Text = ds.Tables[0].Columns[i].Caption;
                var detailCell = new XRTableCell();
                // detailCell.Width = colWidth
                detailCell.Width = columnWidth[i];
                detailCell.DataBindings.Add("Text", null, ds.Tables[0].Columns[i].Caption);
                if (i == 0)
                {
                    headerCell.Borders = DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom;
                    detailCell.Borders = DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom;
                }
                else
                {
                    headerCell.Borders = DevExpress.XtraPrinting.BorderSide.All;
                    detailCell.Borders = DevExpress.XtraPrinting.BorderSide.All;
                }

                // Place the cells into the corresponding tables
                headerRow.Cells.Add(headerCell);
                detailRow.Cells.Add(detailCell);
            }

            tableHeader.EndInit();
            tableDetail.EndInit();
            // Place the table onto a report's Detail band
            rep.Bands[BandKind.PageHeader].Controls.Add(tableHeader);
            rep.Bands[BandKind.Detail].Controls.Add(tableDetail);
        }

        public static void InitChart(XtraReport rep)
        {
            DataSet ds = (DataSet)rep.DataSource;

            // Create a chart
            var xrChart1 = new XRChart();
            xrChart1.Location = new Point(0, 0);
            xrChart1.Name = "xrChart1";

            // Create chart series and bind them to data
            for (int i = 1, loopTo = ds.Tables[0].Columns.Count - 1; i <= loopTo; i++)
            {
                if (ReferenceEquals(ds.Tables[0].Columns[i].DataType, typeof(int)) || ReferenceEquals(ds.Tables[0].Columns[i].DataType, typeof(double)))
                {
                    var series = new DevExpress.XtraCharts.Series(ds.Tables[0].Columns[i].Caption, DevExpress.XtraCharts.ViewType.Bar);
                    series.DataSource = ds.Tables[0];
                    series.ArgumentDataMember = ds.Tables[0].Columns[0].Caption;
                    series.PointOptionsTypeName = "PointOptions";
                    series.ValueDataMembers[0] = ds.Tables[0].Columns[i].Caption;
                    xrChart1.Series.Add(series);
                }
                // Customize the chart appearance
            } ((DevExpress.XtraCharts.XYDiagram)xrChart1.Diagram).AxisX.Label.Angle = 20;
            ((DevExpress.XtraCharts.XYDiagram)xrChart1.Diagram).AxisX.Label.Font = new Font("Tahoma", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
            ((DevExpress.XtraCharts.XYDiagram)xrChart1.Diagram).AxisX.Label.Antialiasing = true;
            xrChart1.SeriesTemplate.PointOptionsTypeName = "PointOptions";
            xrChart1.Size = new Size(650, 360);

            // Place the chart onto a report footer
            rep.Bands[BandKind.ReportFooter].Controls.Add(xrChart1);
        }

        public static Dictionary<string, string> schoolDetails()
        {
            var SchoolDetails__1 = new Dictionary<string, string>();
            string argq = "SELECT * FROM `school_details`";
            if (publicSubsNFunctions.qread(ref argq))
            {
                if (publicSubsNFunctions.dbreader.RecordsAffected > 0)
                {
                    while (publicSubsNFunctions.dbreader.Read())
                    {
                        if (!SchoolDetails__1.ContainsKey(publicSubsNFunctions.dbreader.GetName(1)))
                        {
                            SchoolDetails__1.Add(publicSubsNFunctions.dbreader.GetName(1), publicSubsNFunctions.dbreader.GetString(1));
                        }

                        if (!SchoolDetails__1.ContainsKey(publicSubsNFunctions.dbreader.GetName(10)))
                        {
                            SchoolDetails__1.Add(publicSubsNFunctions.dbreader.GetName(10), publicSubsNFunctions.dbreader.GetString(10));
                        }

                        if (!SchoolDetails__1.ContainsKey(publicSubsNFunctions.dbreader.GetName(4)))
                        {
                            SchoolDetails__1.Add(publicSubsNFunctions.dbreader.GetName(4), publicSubsNFunctions.dbreader.GetString(4));
                        }

                        if (!SchoolDetails__1.ContainsKey(publicSubsNFunctions.dbreader.GetName(2)))
                        {
                            SchoolDetails__1.Add(publicSubsNFunctions.dbreader.GetName(2), publicSubsNFunctions.dbreader.GetString(2));
                        }

                        if (!SchoolDetails__1.ContainsKey(publicSubsNFunctions.dbreader.GetName(11)))
                        {
                            SchoolDetails__1.Add(publicSubsNFunctions.dbreader.GetName(11), publicSubsNFunctions.dbreader.GetString(11));
                        }
                    }
                }
            }

            return SchoolDetails__1;
        }

        public static void exportToExcel(ref DataGridView myView)
        {
            string filePath = string.Empty;
            var myDialog = new SaveFileDialog();
            myDialog.Title = "Export Data";
            myDialog.FileName = "Save Where";
            if (myDialog.ShowDialog() == DialogResult.OK)
            {
                if (!myDialog.FileName.Contains(":"))
                {
                    publicSubsNFunctions.failure("The File Path Is Invalid");
                    return;
                }

                filePath = myDialog.FileName;
            }
            else
            {
                return;
            }

            using (new DevExpress.Utils.WaitDialogForm("Export Data"))
            {
                var myTable = new DataTable();
                for (int k = 0, loopTo = myView.Columns.Count - 1; k <= loopTo; k++)
                    // myTable.Columns.Add(myView.Columns[k].Name.ToString());
                    myTable.Columns.Add(myView.Columns[k].Name.ToString()).Caption = myView.Columns[k].HeaderText;
                var myRow = new List<string>();
                for (int k = 0, loopTo1 = myView.RowCount - 1; k <= loopTo1; k++)
                {
                    for (int j = 0, loopTo2 = myView.Columns.Count - 1; j <= loopTo2; j++)
                    {
                        if (myView.Rows[k].Cells[j].Value is null)
                        {
                            myRow.Add(" ");
                        }
                        else
                        {
                            myRow.Add(myView.Rows[k].Cells[j].Value.ToString());
                        }
                    }

                    myTable.Rows.Add(myRow.ToArray());
                    myRow.Clear();
                }

                // You can import data to worksheet cells from different data sources (for example, arrays, lists and data tables)
                // via the worksheet's Import extension method. Worksheet extensions are defined by the WorksheetExtensions class. 
                // To enable them, add a reference to the DevExpress.Docs.v15.2.dll library and explicitly import the DevExpress.Spreadsheet 
                // namespace into your source code with a using directive (Imports in Visual Basic).

                var mySpreadSheet = new DevExpress.XtraSpreadsheet.SpreadsheetControl();
                var worksheet = mySpreadSheet.Document.Worksheets[0];
                worksheet.Columns.AutoFit(0, myTable.Columns.Count - 1);
                worksheet.Import(myTable, true, 0, 0);

                // mySpreadSheet.ExportToPdf(filePath);

                mySpreadSheet.SaveDocument(filePath + ".xlsx");
            }

            publicSubsNFunctions.success("The Data Was Successfully Exported To" + Environment.NewLine + filePath);
        }
    }
}