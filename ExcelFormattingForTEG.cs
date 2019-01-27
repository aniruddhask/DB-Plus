using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Excel;
using System.Collections;
using System.Diagnostics;
//using Microsoft.Office.Interop.Excel;
using System.Windows.Forms.VisualStyles;

namespace CompleteDataBaseAccess
{
    public partial class ExcelFormattingForTEG : Form
    {

        System.Data.DataTable TmpTablePPVT = new System.Data.DataTable("PPVT");
        System.Data.DataTable TmpTablePALS = new System.Data.DataTable("PALS");
        System.Data.DataTable TmpTableRSL = new System.Data.DataTable("RSL");
        System.Data.DataTable TmpTableLAP3 = new System.Data.DataTable("LAP3");
        System.Data.DataTable TmpTableGR2R = new System.Data.DataTable("GR2R");
        System.Data.DataTable TmpTableGIDI = new System.Data.DataTable("GIDI");

        public Excel.Application ExcelApp;
        public Excel.Workbook objBook;
        public Excel.Worksheet objSheet;

        int iCounterForStyle=0;

        public ExcelFormattingForTEG()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            iCounterForStyle = 0;
            GetStudentTestResult(1001);
        }

        private void GetStudentTestResult(Int64 StudentId)
        {
            clsExcelReport ObjReport = new clsExcelReport();
            DataSet dsResult = ObjReport.GetTestDetails('A', StudentId);

            //declaring sessing for all test
            DataSet dsCompleteDataForTest = new DataSet("CompleteDataForTest");
            //Session["CompleteDataForTest"] = dsCompleteDataForTest;
            if (dsResult.Tables.Count > 0)
            {
                TmpTablePPVT.Merge(dsResult.Tables[0]);
                //if (dsResult.Tables[0].Rows.Count > 0)
                //{
                //    TmpTablePPVT.Merge(dsResult.Tables[0]);
                //    //gvTestPPVT.DataSource = TmpTablePPVT;
                //    //Session["PPVT"] = TmpTablePPVT;
                //    //gvTestPPVT.DataBind();
                //    //lblPPVT.Visible = true;

                //    ////adding PPVT result to session for all result
                //    //((DataSet)(Session["CompleteDataForTest"])).Tables.Add(TmpTablePPVT);
                //}
                if (dsResult.Tables.Count > 1 && dsResult.Tables[1].Rows.Count > 0)
                {
                    TmpTablePALS.Merge(dsResult.Tables[1]);
                    //gvTestPALS.DataSource = TmpTablePALS;
                    //Session["PALS"] = TmpTablePALS;
                    //gvTestPALS.DataBind();
                    //lblPALS.Visible = true;

                    ////adding PALS result to session for all result
                    //((DataSet)(Session["CompleteDataForTest"])).Tables.Add(TmpTablePALS);
                }
                if (dsResult.Tables.Count > 2 && dsResult.Tables[2].Rows.Count > 0)
                {
                    TmpTableRSL.Merge(dsResult.Tables[2]);
                    //gvTestRSL.DataSource = TmpTableRSL;
                    //Session["RSL"] = TmpTableRSL;
                    //gvTestRSL.DataBind();
                    //lblRSL.Visible = true;

                    ////adding RSL result to session for all result
                    //((DataSet)(Session["CompleteDataForTest"])).Tables.Add(TmpTableRSL);
                }
                if (dsResult.Tables.Count > 3 && dsResult.Tables[3].Rows.Count > 0)
                {
                    TmpTableLAP3.Merge(dsResult.Tables[3]);
                    //gvTestLAP3.DataSource = TmpTableLAP3;
                    //Session["LAP"] = TmpTableLAP3;
                    //gvTestLAP3.DataBind();
                    //lblLAP3.Visible = true;

                    ////adding LAP3 result to session for all result
                    //((DataSet)(Session["CompleteDataForTest"])).Tables.Add(TmpTableLAP3);
                }
                if (dsResult.Tables.Count > 4 && dsResult.Tables[4].Rows.Count > 0)
                {
                    TmpTableGR2R.Merge(dsResult.Tables[4]);
                    //gvTestGR2R.DataSource = TmpTableGR2R;
                    //Session["GR2R"] = TmpTableGR2R;
                    //gvTestGR2R.DataBind();
                    //lblGR2R.Visible = true;

                    ////adding GR2R result to session for all result
                    //((DataSet)(Session["CompleteDataForTest"])).Tables.Add(TmpTableGR2R);
                }
                if (dsResult.Tables.Count > 5 && dsResult.Tables[5].Rows.Count > 0)
                {
                    TmpTableGIDI.Merge(dsResult.Tables[5]);
                    //gvTestGIDI.DataSource = TmpTableGIDI;
                    //Session["GIDI"] = TmpTableGIDI;
                    //gvTestGIDI.DataBind();
                    //lblGidi.Visible = true;

                    ////adding GIDI result to session for all result
                    //((DataSet)(Session["CompleteDataForTest"])).Tables.Add(TmpTableGIDI);
                }
                ExportToExcel();
            }
        }

        /// <summary>
        /// To formate selected range.
        /// </summary>
        /// <param name="StyleName">string</param>
        /// <param name="FontName">string</param>
        /// <param name="FontSize">int</param>
        /// <param name="FontColor">Color</param>
        /// <param name="FontBackground">Color</param>
        /// <param name="RangePattern">Excel.XlPattern</param>
        /// <param name="IsBold">bool</param>
        /// <returns>Excel.Style</returns>
        private Excel.Style getFomattedStyle(string StyleName, string FontName, int FontSize, Color FontColor, Color FontBackground, Excel.XlPattern RangePattern, bool bIsBold)
        {
            Excel.Style sty;
            ++iCounterForStyle;
            String strStyleName = "c" + StyleName +iCounterForStyle.ToString();
            try
            {
                sty = objBook.Styles[strStyleName];
            }
            catch
            {
                sty = objBook.Styles.Add(strStyleName, Type.Missing);
            }
            sty.Font.Name = FontName;
            sty.Font.Size = FontSize;
            sty.Font.Bold = bIsBold;
            sty.Font.Color = ColorTranslator.ToOle(FontColor);
            sty.Interior.Color = ColorTranslator.ToOle(FontBackground);
            sty.Interior.Pattern = RangePattern;
            System.Drawing.Color myCol = System.Drawing.Color.Black;
            int Clr = myCol.ToArgb();
            sty.Borders[Excel.XlBordersIndex.xlEdgeLeft].Color = Clr;
            return sty;
        }

        #region GIDI

        private void writeGIDI(System.Data.DataTable dtGIDI, Int32 iSheetNumber, string sDate, string eDate)
        {
            objSheet = (Excel.Worksheet)objBook.Sheets.get_Item(iSheetNumber);

            Excel.Range xlRange = null;
            Excel.Range xlRange1 = null;
            Excel.Range xlRange3 = null;
            
            xlRange = objSheet.get_Range("A1:H1", Type.Missing);
            xlRange.Style = getFomattedStyle("HeadingGR2R", "Arial", 16, Color.Black, Color.White, Excel.XlPattern.xlPatternSolid, true);
            xlRange.Cells.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, 1);
            xlRange.RowHeight = "20.25";
            xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
            xlRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            xlRange.Orientation = 0;
            xlRange.WrapText = true;
            xlRange.MergeCells = true;
            xlRange.Cells.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, 1);
            objSheet.Cells[1, 1] = "HEART ERF Spreadsheet Year 1: August 2007-June 2008";

            xlRange1 = objSheet.get_Range("A4:N4", Type.Missing);
            xlRange1.Style = getFomattedStyle("HeadingGR2R", "Arial", 16, Color.Blue, Color.White, Excel.XlPattern.xlPatternSolid, false);
            xlRange1.Cells.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, 1);
            xlRange1.RowHeight = "20";
            xlRange1.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            xlRange1.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            xlRange1.WrapText = true;
            xlRange1.MergeCells = true;
            objSheet.Cells[4, 1] = "Identifiers and Demographics";

            xlRange3 = objSheet.get_Range("A5:R5", Type.Missing);
            xlRange3.Style = getFomattedStyle("Heading3GR2R", "Arial", 10, Color.White, Color.Black, Excel.XlPattern.xlPatternSolid, true);
            xlRange3.Cells.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, 1);
            xlRange3.RowHeight = "46";
            xlRange3.ColumnWidth = "22.71";
            xlRange3.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
            xlRange3.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            xlRange3.Cells.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, 1);
            xlRange3.WrapText = true;

            int iColumnIndex = 1;
            foreach (DataColumn dcColumnName in dtGIDI.Columns)
            {
                objSheet.Cells[5, iColumnIndex] = dcColumnName.ColumnName;
                iColumnIndex++;
            }

            int iRowIndex = 6;
            foreach (DataRow drGIDI in dtGIDI.Rows)
            {
                iColumnIndex = 1;
                foreach (DataColumn dcColumnName in dtGIDI.Columns)
                {
                    xlRange = objSheet.get_Range(Convert.ToChar(iColumnIndex + 64) + iRowIndex.ToString(), Type.Missing);
                    xlRange.Style = getFomattedStyle("cellsGR2R", "Arial", 10, Color.Black, Color.FromArgb(255, 255, 255), Excel.XlPattern.xlPatternSolid, false);
                    xlRange.Cells.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, 1);
                    if (dcColumnName.ColumnName.ToLower().Contains("date"))
                        objSheet.Cells[iRowIndex, iColumnIndex] = drGIDI[dcColumnName].ToString() == "" ? "" : Convert.ToDateTime(drGIDI[dcColumnName].ToString()).ToShortDateString();
                    else
                        objSheet.Cells[iRowIndex, iColumnIndex] = drGIDI[dcColumnName].ToString();
                    iColumnIndex++;
                }
                iRowIndex++;
            }
        }

        #endregion

        #region GR2R
        private void writeGR2R(System.Data.DataTable dtGR2R, Int32 iSheetNumber, string strCenter, string strCoaches, string sDate, string eDate)
        {
            objSheet = (Excel.Worksheet)objBook.Sheets.get_Item(iSheetNumber);

            Excel.Range xlRange = null;
            Excel.Range xlRange1 = null;
            Excel.Range xlRange2 = null;
            Excel.Range xlRange3 = null;
            Excel.Range xlRange4 = null;

            xlRange = objSheet.get_Range("A1:H1", Type.Missing);
            xlRange.Style = getFomattedStyle("HeadingGR2R", "Arial", 16, Color.Black, Color.White, Excel.XlPattern.xlPatternSolid, true);
            xlRange.RowHeight = "20.25";
            xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
            xlRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            xlRange.Orientation = 0;
            xlRange.WrapText = true;
            xlRange.MergeCells = true;
            xlRange.Cells.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, 1);
            objSheet.Cells[1, 1] = "BLOCK ERF Spreadsheet Year 1:  " + sDate + " - ." + eDate;

            xlRange1 = objSheet.get_Range("A2:H2", Type.Missing);
            xlRange1.Style = getFomattedStyle("HeadingGR2R", "Arial", 16, Color.Black, Color.White, Excel.XlPattern.xlPatternSolid, false);
            xlRange1.RowHeight = "20";
            xlRange1.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
            xlRange1.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            xlRange1.Orientation = 0;
            xlRange1.WrapText = true;
            xlRange1.MergeCells = true;
            objSheet.Cells[2, 1] = "Center: " + strCenter + "Coaches: " + strCoaches;

            xlRange2 = objSheet.get_Range("A2:H2", Type.Missing);
            xlRange2.Style = getFomattedStyle("HeadingGR2R", "Arial", 16, Color.Blue, Color.White, Excel.XlPattern.xlPatternSolid, true);
            xlRange2.RowHeight = "20";
            xlRange2.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
            xlRange2.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            xlRange2.Orientation = 0;
            xlRange2.WrapText = true;
            xlRange2.MergeCells = true;
            objSheet.Cells[3, 1] = "LAP 3 Student Reports";

            xlRange3 = objSheet.get_Range("A4:H4", Type.Missing);
            xlRange3.Style = getFomattedStyle("Heading3GR2R", "Arial", 10, Color.White, Color.Black, Excel.XlPattern.xlPatternSolid, true);
            xlRange3.RowHeight = "206";
            xlRange3.ColumnWidth = "11.14";
            xlRange3.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            xlRange3.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            xlRange3.Orientation = 90;
            xlRange3.Cells.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, 1);
            xlRange3.WrapText = true;

            xlRange4 = objSheet.get_Range("A4:D4", Type.Missing);
            xlRange4.Style = getFomattedStyle("Heading4GR2R", "Arial", 10, Color.Yellow, Color.FromArgb(0, 0, 0), Excel.XlPattern.xlPatternSolid, true);
            xlRange4.RowHeight = "206";
            xlRange4.ColumnWidth = "11.14";
            xlRange4.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            xlRange4.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            xlRange4.Orientation = 90;
            xlRange4.Cells.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, 1);
            xlRange4.WrapText = true;

            int iColumnIndex = 1;
            foreach (DataColumn dcColumnName in dtGR2R.Columns)
            {
                objSheet.Cells[4, iColumnIndex] = dcColumnName.ColumnName;
                iColumnIndex++;
            }

            int iRowIndex = 5;
            foreach (DataRow drGR2R in dtGR2R.Rows)
            {
                iColumnIndex = 1;
                foreach (DataColumn dcColumnName in dtGR2R.Columns)
                {
                    xlRange = objSheet.get_Range(Convert.ToChar(iColumnIndex + 64) + iRowIndex.ToString(), Type.Missing);
                    if (iColumnIndex == 6 || iColumnIndex == 8)
                    {
                        xlRange.Style = getFomattedStyle("cellsGR2R", "Arial", 10, Color.Black, drGR2R[dcColumnName].ToString() == "" ? Color.Red : Convert.ToInt32(drGR2R[dcColumnName].ToString()) > 10 ? Color.Green : Convert.ToInt32(drGR2R[dcColumnName].ToString()) > 5 ? Color.Yellow : Color.Red, Excel.XlPattern.xlPatternSolid, false);
                        xlRange.Cells.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, 1);
                        objSheet.Cells[iRowIndex, iColumnIndex] = drGR2R[dcColumnName].ToString();
                    }
                    else
                    {
                        xlRange.Cells.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, 1);
                        xlRange.Style = getFomattedStyle("cellsGR2R", "Arial", 10, Color.Black, Color.FromArgb(255, 255, 255), Excel.XlPattern.xlPatternSolid, false);
                        xlRange.Cells.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, 1);
                        if (dcColumnName.ColumnName.ToLower().Contains("date"))
                            objSheet.Cells[iRowIndex, iColumnIndex] = drGR2R[dcColumnName].ToString() == "" ? "" : Convert.ToDateTime(drGR2R[dcColumnName].ToString()).ToShortDateString();
                        else
                            objSheet.Cells[iRowIndex, iColumnIndex] = drGR2R[dcColumnName].ToString();
                }
                    iColumnIndex++;
                }
                iRowIndex++;
            }
        }
        #endregion

        #region LAP-3
        private void writeLAP3(System.Data.DataTable dtLAP3, Int32 iSheetNumber, string strCenter, string strCoaches, string sDate, string eDate)
        {
            objSheet = (Excel.Worksheet)objBook.Sheets.get_Item(iSheetNumber);

            Excel.Range xlRange = null;
            Excel.Range xlRange1 = null;
            Excel.Range xlRange2 = null;
            Excel.Range xlRange3 = null;
            Excel.Range xlRange4 = null;

            xlRange = objSheet.get_Range("A1:Z1", Type.Missing);
            xlRange.Style = getFomattedStyle("Heading", "Arial", 16, Color.Black, Color.White, Excel.XlPattern.xlPatternSolid, true);
            xlRange.RowHeight = "20.25";
            xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
            xlRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            xlRange.Orientation = 0;
            xlRange.WrapText = true;
            xlRange.MergeCells = true;
            xlRange.Cells.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, 1);
            objSheet.Cells[1, 1] = "BLOCK ERF Spreadsheet Year 1:  " + sDate + " - ." + eDate;

            xlRange1 = objSheet.get_Range("A2:Z2", Type.Missing);
            xlRange1.Style = getFomattedStyle("Heading", "Arial", 16, Color.Black, Color.White, Excel.XlPattern.xlPatternSolid, false);
            xlRange1.RowHeight = "20";
            xlRange1.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
            xlRange1.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            xlRange1.Orientation = 0;
            xlRange1.WrapText = true;
            xlRange1.MergeCells = true;
            objSheet.Cells[2, 1] = "Center: " + strCenter + "Coaches: " + strCoaches;

            xlRange2 = objSheet.get_Range("A2:Z2", Type.Missing);
            xlRange2.Style = getFomattedStyle("Heading", "Arial", 16, Color.Blue, Color.White, Excel.XlPattern.xlPatternSolid, true);
            xlRange2.RowHeight = "20";
            xlRange2.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
            xlRange2.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            xlRange2.Orientation = 0;
            xlRange2.WrapText = true;
            xlRange2.MergeCells = true;
            objSheet.Cells[3, 1] = "LAP 3 Student Reports";

            xlRange3 = objSheet.get_Range("A5:R5", Type.Missing);
            xlRange3.Style = getFomattedStyle("Heading3", "Arial", 10, Color.White, Color.Black, Excel.XlPattern.xlPatternSolid, true);
            xlRange3.RowHeight = "51";
            xlRange3.ColumnWidth = "12.14";
            xlRange3.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            xlRange3.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            xlRange3.Orientation = 0;
            xlRange3.Cells.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, 1);
            xlRange3.WrapText = true;

            xlRange4 = objSheet.get_Range("E5", Type.Missing);
            xlRange4.Style = getFomattedStyle("Heading4", "Arial", 10, Color.Yellow, Color.FromArgb(0,0,0), Excel.XlPattern.xlPatternSolid, true);
            xlRange4.RowHeight = "51";
            xlRange4.ColumnWidth = "12.14";
            xlRange4.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            xlRange4.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            xlRange4.Orientation = 0;
            xlRange4.Cells.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, 1);
            xlRange4.WrapText = true;
            int iColumnIndex = 1;
            foreach (DataColumn dcColumnName in dtLAP3.Columns)
            {
                objSheet.Cells[5, iColumnIndex] = dcColumnName.ColumnName.Contains("Blank") == true ? "" : dcColumnName.ColumnName;
                iColumnIndex++;
            }

            int iRowIndex = 6;
            foreach (DataRow drLAP3 in dtLAP3.Rows)
            {
                iColumnIndex = 1;
                foreach (DataColumn dcColumnName in dtLAP3.Columns)
                {
                    xlRange = objSheet.get_Range(Convert.ToChar(iColumnIndex + 64) + iRowIndex.ToString(), Type.Missing);
                    xlRange.Style = getFomattedStyle("cells", "Arial", 10, Color.Black, Color.FromArgb(255, 255, 255), Excel.XlPattern.xlPatternSolid, false);
                    xlRange.Cells.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, 1);
                    if (dcColumnName.ColumnName != "% Growth from Beginning to End")
                    {
                        if (dcColumnName.ColumnName.ToLower().Contains("date"))
                            objSheet.Cells[iRowIndex, iColumnIndex] = drLAP3[dcColumnName].ToString() == "" ? "" : Convert.ToDateTime(drLAP3[dcColumnName].ToString()).ToShortDateString();
                        else
                            objSheet.Cells[iRowIndex, iColumnIndex] = drLAP3[dcColumnName].ToString();
                    }
                    else
                        objSheet.Cells[iRowIndex, iColumnIndex] = "=" + drLAP3[dcColumnName].ToString().Replace("RowIndex", iRowIndex.ToString());
                    iColumnIndex++;
                }
                iRowIndex++;
            }
        }

        #endregion

        #region RSL
        private void writeRSL(System.Data.DataTable dtRSL, Int32 iSheetNumber, string strCenter, string strCoaches, string sDate, string eDate)
        {
            objSheet = (Excel.Worksheet)objBook.Sheets.get_Item(iSheetNumber);

            Excel.Range xlRange = null;
            Excel.Range xlRange1 = null;
            Excel.Range xlRange2 = null;
            Excel.Range xlRange3 = null;
            Excel.Range xlRange4 = null;
            Excel.Range xlRange5 = null;
            Excel.Range xlRange6 = null;
            Excel.Range xlRange7 = null;
            Excel.Range xlRange8 = null;
            Excel.Range xlRange9 = null;
            Excel.Range xlRange10 = null;
            Excel.Range xlRange11 = null;

            xlRange = objSheet.get_Range("A1:AE1", Type.Missing);
            xlRange.Style = getFomattedStyle("Heading", "Arial", 16, Color.Black, Color.White, Excel.XlPattern.xlPatternSolid, true);
            xlRange.RowHeight = "20";
            xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
            xlRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            xlRange.Orientation = 0;
            xlRange.WrapText = true;
            xlRange.MergeCells = true;
            xlRange.Cells.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, 1);
            objSheet.Cells[1, 1] = "BLOCK ERF Spreadsheet Year 1:  " + sDate + " - ." + eDate;

            xlRange1 = objSheet.get_Range("A2:AE2", Type.Missing);
            xlRange1.Style = getFomattedStyle("Heading1", "Arial", 16, Color.Black, Color.White, Excel.XlPattern.xlPatternSolid, false);
            xlRange1.RowHeight = "20";
            xlRange1.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
            xlRange1.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            xlRange1.Orientation = 0;
            xlRange1.WrapText = true;
            xlRange1.MergeCells = true;
            xlRange1.Cells.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, 1);
            objSheet.Cells[2, 1] = "Center: " + strCenter + "Coaches: " + strCoaches;

            xlRange2 = objSheet.get_Range("A3:AE3", Type.Missing);
            xlRange2.Style = getFomattedStyle("Heading2", "Arial", 16, Color.Blue, Color.White, Excel.XlPattern.xlPatternSolid, true);
            xlRange2.RowHeight = "20";
            xlRange2.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
            xlRange2.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            xlRange2.Orientation = 0;
            xlRange2.WrapText = true;
            xlRange2.MergeCells = true;
            xlRange2.Cells.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, 1);
            objSheet.Cells[3, 1] = "RSL Students Report";

            xlRange3 = objSheet.get_Range("A4:G4", Type.Missing);
            xlRange3.Style = getFomattedStyle("Heading3", "Arial", 16, Color.Blue, Color.White, Excel.XlPattern.xlPatternSolid, true);
            xlRange3.RowHeight = "20";
            xlRange3.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
            xlRange3.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            xlRange3.Orientation = 0;
            xlRange3.WrapText = true;
            xlRange3.MergeCells = true;
            xlRange3.Cells.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, 1);
            objSheet.Cells[4, 1] = "Identifiers";

            xlRange4 = objSheet.get_Range("H4:p4", Type.Missing);
            xlRange4.Style = getFomattedStyle("Heading4", "Arial", 16, Color.Blue, Color.White, Excel.XlPattern.xlPatternSolid, true);
            xlRange4.RowHeight = "20";
            xlRange4.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            xlRange4.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            xlRange4.Orientation = 0;
            xlRange4.WrapText = true;
            xlRange4.MergeCells = true;
            xlRange4.Cells.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, 1);
            objSheet.Cells[4, 8] = "RSL #1";

            xlRange5 = objSheet.get_Range("R4:Z4", Type.Missing);
            xlRange5.Style = getFomattedStyle("Heading5", "Arial", 16, Color.Blue, Color.White, Excel.XlPattern.xlPatternSolid, true);
            xlRange5.RowHeight = "20";
            xlRange5.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            xlRange5.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            xlRange5.Orientation = 0;
            xlRange5.WrapText = true;
            xlRange5.MergeCells = true;
            xlRange5.Cells.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, 1);
            objSheet.Cells[4, 18] = "RSL #2";

            xlRange6 = objSheet.get_Range("AB4:AJ4", Type.Missing);
            xlRange6.Style = getFomattedStyle("Heading6", "Arial", 16, Color.Blue, Color.White, Excel.XlPattern.xlPatternSolid, true);
            xlRange6.RowHeight = "20";
            xlRange6.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            xlRange6.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            xlRange6.Orientation = 0;
            xlRange6.WrapText = true;
            xlRange6.MergeCells = true;
            xlRange6.Cells.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, 1);
            objSheet.Cells[4, 28] = "RSL #3";

            xlRange7 = objSheet.get_Range("AL4:AT4", Type.Missing);
            xlRange7.Style = getFomattedStyle("Heading7", "Arial", 16, Color.Blue, Color.White, Excel.XlPattern.xlPatternSolid, true);
            xlRange7.RowHeight = "20";
            xlRange7.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            xlRange7.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            xlRange7.Orientation = 0;
            xlRange7.WrapText = true;
            xlRange7.MergeCells = true;
            xlRange7.Cells.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, 1);
            objSheet.Cells[4, 38] = "RSL #4";

            xlRange8 = objSheet.get_Range("AV4:BD4", Type.Missing);
            xlRange8.Style = getFomattedStyle("Heading8", "Arial", 16, Color.Blue, Color.White, Excel.XlPattern.xlPatternSolid, true);
            xlRange8.RowHeight = "20";
            xlRange8.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            xlRange8.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            xlRange8.Orientation = 0;
            xlRange8.WrapText = true;
            xlRange8.MergeCells = true;
            xlRange8.Cells.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, 1);
            objSheet.Cells[4, 48] = "RSL #5";

            xlRange9 = objSheet.get_Range("BF4:BN4", Type.Missing);
            xlRange9.Style = getFomattedStyle("Heading9", "Arial", 16, Color.Blue, Color.White, Excel.XlPattern.xlPatternSolid, true);
            xlRange9.RowHeight = "20";
            xlRange9.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            xlRange9.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            xlRange9.Orientation = 0;
            xlRange9.WrapText = true;
            xlRange9.MergeCells = true;
            xlRange9.Cells.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, 1);
            objSheet.Cells[4, 58] = "RSL #6";

            xlRange10 = objSheet.get_Range("A5:G5", Type.Missing);
            xlRange10.Style = getFomattedStyle("Heading10", "Arial", 10, Color.Yellow, Color.FromArgb(51, 51, 51), Excel.XlPattern.xlPatternSolid, true);
            xlRange10.RowHeight = "20";
            xlRange10.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            xlRange10.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            xlRange10.Orientation = 0;
            xlRange10.Cells.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, 1);
            xlRange10.WrapText = true;

            xlRange11 = objSheet.get_Range("H5:BN5", Type.Missing);
            xlRange11.Style = getFomattedStyle("Heading11", "Arial", 10, Color.White, Color.FromArgb(51, 51, 51), Excel.XlPattern.xlPatternSolid, true);
            xlRange11.RowHeight = "102.75";
            xlRange11.ColumnWidth = "5.29";
            xlRange11.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            xlRange11.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            xlRange11.Orientation = 90;
            xlRange11.Cells.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, 1);
            xlRange11.WrapText = true;

            int iColumnIndex = 1;
            foreach (DataColumn dcColumnName in dtRSL.Columns)
            {
                objSheet.Cells[5, iColumnIndex] = dcColumnName.ColumnName.Contains("Blank") == true ? "" : dcColumnName.ColumnName;
                iColumnIndex++;
            }

            int iRowIndex = 6;
            foreach (DataRow drRSL in dtRSL.Rows)
            {
                iColumnIndex = 1;
                foreach (DataColumn dcColumnName in dtRSL.Columns)
                {
                    if (!dcColumnName.ColumnName.Contains("Blank"))
                    {
                        if (iColumnIndex < 27)
                            xlRange = objSheet.get_Range(Convert.ToChar(iColumnIndex + 64) + iRowIndex.ToString(), Type.Missing);
                        else if (iColumnIndex < 53)
                            xlRange = objSheet.get_Range("A" + Convert.ToChar(iColumnIndex + 64 - 26) + iRowIndex.ToString(), Type.Missing);
                        else
                            xlRange = objSheet.get_Range("B" + Convert.ToChar(iColumnIndex + 64 - 52) + iRowIndex.ToString(), Type.Missing);
                        xlRange.Cells.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, 1);

                        if (iColumnIndex > 7)
                            xlRange.Style = getFomattedStyle(drRSL[dcColumnName].ToString() == "-1000" ? "Red" : Convert.ToInt32(drRSL[dcColumnName].ToString()) < 10 ? "Red" : Convert.ToInt32(drRSL[dcColumnName].ToString()) < 15 ? "Yellow" : "Green", "Arial", 10, Color.Black, drRSL[dcColumnName].ToString() == "" ? Color.Red : Convert.ToInt32(drRSL[dcColumnName].ToString()) < 10 ? Color.Red : Convert.ToInt32(drRSL[dcColumnName].ToString()) < 15 ? Color.Yellow : Color.Green, Excel.XlPattern.xlPatternSolid, false);
                        else
                            xlRange.Style = getFomattedStyle("Gray", "Arial", 10, Color.Black, Color.FromArgb(192, 192, 192), Excel.XlPattern.xlPatternSolid, false);
                        xlRange.Cells.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, 1);

                        if (dcColumnName.ColumnName.ToLower().Contains("date"))
                            objSheet.Cells[iRowIndex, iColumnIndex] = drRSL[dcColumnName].ToString() == "" ? "" : Convert.ToDateTime(drRSL[dcColumnName].ToString()).ToShortDateString();
                        else
                            objSheet.Cells[iRowIndex, iColumnIndex] = drRSL[dcColumnName].ToString() == "-1000" ? "" : drRSL[dcColumnName].ToString();
                    }
                    else
                    {
                        if (dcColumnName.ColumnName.ToLower().Contains("date"))
                            objSheet.Cells[iRowIndex, iColumnIndex] = drRSL[dcColumnName].ToString() == "" ? "" : Convert.ToDateTime(drRSL[dcColumnName].ToString()).ToShortDateString();
                        else
                            objSheet.Cells[iRowIndex, iColumnIndex] = drRSL[dcColumnName].ToString();
                    }
                    iColumnIndex++;
                }
                iRowIndex++;
            }
        }
        #endregion

        #region PASL
        private void writePASL(System.Data.DataTable dtPASL, Int32 iSheetNumber)
        {
            objSheet = (Excel.Worksheet)objBook.Sheets.get_Item(iSheetNumber);

            Excel.Range xlRange = null;
            Excel.Range xlRange1 = null;
            Excel.Range xlRange2 = null;
            Excel.Range xlRange3 = null;
            Excel.Range xlRange4 = null;
            Excel.Range xlRange5 = null;
            xlRange = objSheet.get_Range("A1:I1", Type.Missing);
            xlRange.Style = getFomattedStyle("Heading", "Arial", 10, Color.Yellow, Color.FromArgb(51, 51, 51), Excel.XlPattern.xlPatternSolid, true);
            xlRange.ColumnWidth = "10.57";
            xlRange.RowHeight = "135";
            xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            xlRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            xlRange.Orientation = 0;
            xlRange.Cells.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, 1);
            xlRange.WrapText = true;

            xlRange1 = objSheet.get_Range("J1:P1", Type.Missing);
            xlRange1.Style = getFomattedStyle("Heading1", "Arial", 10, Color.White, Color.FromArgb(51, 51, 51), Excel.XlPattern.xlPatternSolid, true);
            xlRange1.ColumnWidth = "5";
            xlRange1.RowHeight = "135";
            xlRange1.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            xlRange1.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            xlRange1.Orientation = 90;
            xlRange1.Cells.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, 1);
            xlRange1.WrapText = true;

            xlRange2 = objSheet.get_Range("Q1", Type.Missing);
            xlRange2.Style = getFomattedStyle("Heading2", "Arial", 10, Color.White, Color.FromArgb(51, 51, 51), Excel.XlPattern.xlPatternSolid, true);
            xlRange2.ColumnWidth = "12.5";
            xlRange2.RowHeight = "135";
            xlRange2.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            xlRange2.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            xlRange2.Orientation = 0;
            xlRange2.Cells.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, 1);
            xlRange2.WrapText = true;

            xlRange3 = objSheet.get_Range("R1:X1", Type.Missing);
            xlRange3.Style = getFomattedStyle("Heading3", "Arial", 10, Color.White, Color.FromArgb(51, 51, 51), Excel.XlPattern.xlPatternSolid, true);
            xlRange3.ColumnWidth = "5";
            xlRange3.RowHeight = "135";
            xlRange3.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            xlRange3.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            xlRange3.Orientation = 90;
            xlRange3.Cells.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, 1);
            xlRange3.WrapText = true;

            xlRange4 = objSheet.get_Range("Y1", Type.Missing);
            xlRange4.Style = getFomattedStyle("Heading4", "Arial", 10, Color.White, Color.FromArgb(51, 51, 51), Excel.XlPattern.xlPatternSolid, true);
            xlRange4.ColumnWidth = "12.5";
            xlRange4.RowHeight = "135";
            xlRange4.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            xlRange4.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            xlRange4.Orientation = 0;
            xlRange4.Cells.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, 1);
            xlRange4.WrapText = true;

            xlRange5 = objSheet.get_Range("Z1:AF1", Type.Missing);
            xlRange5.Style = getFomattedStyle("Heading5", "Arial", 10, Color.White, Color.FromArgb(51, 51, 51), Excel.XlPattern.xlPatternSolid, true);
            xlRange5.ColumnWidth = "5";
            xlRange5.RowHeight = "135";
            xlRange5.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            xlRange5.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            xlRange5.Orientation = 90;
            xlRange5.Cells.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, 1);
            xlRange5.WrapText = true;

            int iColumnIndex = 1;
            foreach (DataColumn dcColumnName in dtPASL.Columns)
            {
                objSheet.Cells[1, iColumnIndex] = dcColumnName.ColumnName;
                iColumnIndex++;
            }

            int iRowIndex = 2;

            foreach (DataRow drPALS in dtPASL.Rows)
            {
                iColumnIndex = 1;
                foreach (DataColumn dcColumnName in dtPASL.Columns)
                {
                    if (iColumnIndex < 27)
                        xlRange = objSheet.get_Range(Convert.ToChar(iColumnIndex + 64) + iRowIndex.ToString(), Type.Missing);
                    else
                        xlRange = objSheet.get_Range("A" + Convert.ToChar(iColumnIndex + 64 - 26) + iRowIndex.ToString(), Type.Missing);
                    if (iColumnIndex == 9 || iColumnIndex == 17 || iColumnIndex == 25)
                        xlRange.Style = getFomattedStyle("White", "Arial", 10, Color.Black, Color.White, Excel.XlPattern.xlPatternSolid, false);
                    else if (iColumnIndex > 9 && iColumnIndex != 17 && iColumnIndex != 25)
                        xlRange.Style = getFomattedStyle(drPALS[dcColumnName].ToString() == "" ? "Red" : Convert.ToInt32(drPALS[dcColumnName].ToString()) < 10 ? "Red" : Convert.ToInt32(drPALS[dcColumnName].ToString()) < 15 ? "Yellow" : "Green", "Arial", 10, Color.Black, drPALS[dcColumnName].ToString() == "" ? Color.Red : Convert.ToInt32(drPALS[dcColumnName].ToString()) < 10 ? Color.Red : Convert.ToInt32(drPALS[dcColumnName].ToString()) < 15 ? Color.Yellow : Color.Green, Excel.XlPattern.xlPatternSolid, false);
                    else
                        xlRange.Style = getFomattedStyle("Gray", "Arial", 10, Color.Black, Color.FromArgb(192, 192, 192), Excel.XlPattern.xlPatternSolid, false);
                    xlRange.Cells.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, 1);
                    if (dcColumnName.ColumnName.ToLower().Contains("date"))
                        objSheet.Cells[iRowIndex, iColumnIndex] = drPALS[dcColumnName].ToString() == "" ? "" : Convert.ToDateTime(drPALS[dcColumnName].ToString()).ToShortDateString();
                    else
                        objSheet.Cells[iRowIndex, iColumnIndex] = drPALS[dcColumnName].ToString();
                    iColumnIndex++;
                }
                iRowIndex++;
            }
        }
        #endregion

        #region PPVT Test
        public void writeToPPVT(System.Data.DataTable dt, Int32 iSheetNumber)
        {
            objSheet = (Excel.Worksheet)objBook.Sheets.get_Item(iSheetNumber);

            Excel.Range xlRange = null;
            xlRange = objSheet.get_Range("A1:AA1", Type.Missing);
            xlRange.Style = getFomattedStyle("Heading", "Arial", 10, Color.Yellow, Color.FromArgb(51, 51, 51), Excel.XlPattern.xlPatternSolid, true);
            xlRange.ColumnWidth = "12";
            xlRange.RowHeight = "77.25";
            xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            xlRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            xlRange.Cells.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, 1);
            xlRange.WrapText = true;

            ArrayList arrlstExtroColumnsWithFunction = new ArrayList();
            arrlstExtroColumnsWithFunction.Add(new clsNameValue("Posttest Autofunction 1", "=(YEAR(MiRowNumber)-YEAR(BiRowNumber))*12+MONTH(MiRowNumber)-MONTH(BiRowNumber)"));
            arrlstExtroColumnsWithFunction.Add(new clsNameValue("Postest Auto function 2", "=NiRowNumber/12"));
            arrlstExtroColumnsWithFunction.Add(new clsNameValue("Posttest Auto function 3", "=ROUNDDOWN(OiRowNumber,0)*12"));
            arrlstExtroColumnsWithFunction.Add(new clsNameValue("Post autofunction 4", "=IF(ISBLANK(MiRowNumber), '', ROUNDDOWN(OiRowNumber,0))"));
            arrlstExtroColumnsWithFunction.Add(new clsNameValue("Post autofunction 5", "=IF(ISBLANK(MiRowNumber),'',NiRowNumber-PiRowNumber)"));
            arrlstExtroColumnsWithFunction.Add(new clsNameValue("Post autofunction 6", "=IF(DAY(MiRowNumber)-DAY(BiRowNumber)<0,(RiRowNumber-1),RiRowNumber-0)"));
            arrlstExtroColumnsWithFunction.Add(new clsNameValue("Post autofunction 7", "=SiRowNumber"));
            arrlstExtroColumnsWithFunction.Add(new clsNameValue("Chronological Age in Years (post-test)", "=IF(SiRowNumber<0,QiRowNumber-1,QiRowNumber-0)"));
            arrlstExtroColumnsWithFunction.Add(new clsNameValue("Chronological Age in Months (post-test)", "=IF(SiRowNumber<0,11,TiRowNumber)"));

            int iColumnIndex = 1;
            int iRowNumber = 2;
            bool bIsExtraOver = false;
            foreach (DataColumn dcTableHeader in dt.Columns)
            {
                if (iColumnIndex < 14 || bIsExtraOver)
                {
                    objSheet.Cells[1, iColumnIndex] = dcTableHeader.ColumnName;
                }
                else
                {
                    foreach (clsNameValue deExtraColumn in arrlstExtroColumnsWithFunction)
                    {
                        objSheet.Cells[1, iColumnIndex] = deExtraColumn.cName.ToString();
                        iColumnIndex++;
                        bIsExtraOver = true;
                    }
                    iColumnIndex--;
                }
                iColumnIndex++;
            }


            foreach (DataRow drTableData in dt.Rows)
            {
                iColumnIndex = 1;
                bIsExtraOver = false;
                foreach (DataColumn dcTableHeader in dt.Columns)
                {
                    if (iColumnIndex < 14 || bIsExtraOver)
                    {
                        xlRange = objSheet.get_Range(Convert.ToChar(iColumnIndex + 64) + iRowNumber.ToString(), Type.Missing);
                        if (iColumnIndex == 10 || iColumnIndex == 23)
                        {
                            xlRange.Style = getFomattedStyle(Convert.ToInt32(drTableData[dcTableHeader]) <= 39 ? "White" : Convert.ToInt32(drTableData[dcTableHeader]) <= 79 ? "Red" : Convert.ToInt32(drTableData[dcTableHeader]) <= 85 ? "Yellow" : "Green", "Arial", 10, Color.Black, Convert.ToInt32(drTableData[dcTableHeader]) <= 39 ? Color.White : Convert.ToInt32(drTableData[dcTableHeader]) <= 79 ? Color.Red : Convert.ToInt32(drTableData[dcTableHeader]) <= 85 ? Color.Yellow : Color.Green, Excel.XlPattern.xlPatternSolid, false);
                        }
                        else if (iColumnIndex != 3 && iColumnIndex != 9 && iColumnIndex != 11 && iColumnIndex != 12 && iColumnIndex != 13 && iColumnIndex != 23 && iColumnIndex != 25 && iColumnIndex != 26 && iColumnIndex != 27)
                            xlRange.Style = getFomattedStyle("Gray", "Arial", 10, Color.Black, Color.FromArgb(192, 192, 192), Excel.XlPattern.xlPatternSolid, false);
                        xlRange.Cells.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, 1);
                        if (dcTableHeader.ColumnName.ToLower().Contains("date"))
                            objSheet.Cells[iRowNumber, iColumnIndex] = drTableData[dcTableHeader].ToString() == "" ? "" : Convert.ToDateTime(drTableData[dcTableHeader].ToString()).ToShortDateString();
                        else
                            objSheet.Cells[iRowNumber, iColumnIndex] = drTableData[dcTableHeader].ToString();
                    }
                    else
                    {
                        foreach (clsNameValue deExtraColumn in arrlstExtroColumnsWithFunction)
                        {
                            xlRange = objSheet.get_Range(Convert.ToChar(iColumnIndex + 64) + iRowNumber.ToString(), Type.Missing);
                            xlRange.Style = getFomattedStyle("Gray", "Arial", 10, Color.Black, Color.FromArgb(192, 192, 192), Excel.XlPattern.xlPatternSolid, false);
                            xlRange.Cells.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, 1);
                            objSheet.Cells[iRowNumber, iColumnIndex] = deExtraColumn.cValue.ToString().Replace("iRowNumber", iRowNumber.ToString()).Replace("''", "" + Convert.ToChar(34) + Convert.ToChar(34) + "");
                            iColumnIndex++;
                            bIsExtraOver = true;
                        }
                        iColumnIndex--;
                    }
                    iColumnIndex++;
                }
                iRowNumber++;
            }
        }
        #endregion

        private void closeExcel()
        {
            foreach (Process excelInstance in Process.GetProcessesByName("Excel"))
            {
                try
                {
                    //excelInstance.Kill();
                }
                catch { }
            }
        }


        #region Aniruddha Singh

        private void ExportToExcel()
        {
            //Code for Sheet
            object missing = System.Reflection.Missing.Value;
            object fileName = "normal.xls";
            object newTemplate = false;
            object docType = 0;
            object isVisible = false;

            ExcelApp = new Excel.ApplicationClass();
            ExcelApp.Visible = false;
            objBook = ExcelApp.Workbooks.Add(missing);

            //declaring arraylist for names of Tests.
            ArrayList arrlstTestName = new ArrayList();
            arrlstTestName.Add("Identifier");
            arrlstTestName.Add("PPVT");
            arrlstTestName.Add("PALS");
            arrlstTestName.Add("RSL");
            arrlstTestName.Add("LAP3");
            arrlstTestName.Add("GR2R");
            arrlstTestName.Add("GIDI");

            //code for adding more sheets to excel file if needed.
            for (int iCounterForExistingSheetsInExcel = objBook.Sheets.Count + 1; iCounterForExistingSheetsInExcel <= arrlstTestName.Count; iCounterForExistingSheetsInExcel++)
            {
                objSheet = (Excel.Worksheet)objBook.Sheets.Add(missing, missing, missing, missing);
            }

            //code for changing the name of sheet which are already exists in Excel.
            for (int iCounterForExistingSheetsInExcel = 0; iCounterForExistingSheetsInExcel < objBook.Sheets.Count; iCounterForExistingSheetsInExcel++)
            {
                ((Excel.Worksheet)objBook.Sheets.get_Item(iCounterForExistingSheetsInExcel + 1)).Name = arrlstTestName[iCounterForExistingSheetsInExcel].ToString();

                System.Drawing.Color myCol = System.Drawing.Color.Green;
                int Clr = myCol.ToArgb();
                ((Excel.Worksheet)objBook.Sheets.get_Item(iCounterForExistingSheetsInExcel + 1)).Tab.Color = Clr;
            }


            writeToPPVT(TmpTablePPVT, 2);
            writePASL(TmpTablePALS, 3);
            writeRSL(TmpTableRSL, 4, "", "", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortDateString());
            writeLAP3(TmpTableLAP3, 5, "", "", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortDateString());
            writeGR2R(TmpTableGR2R, 6, "", "", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortDateString());
            writeGIDI(TmpTableGIDI, 7, DateTime.Now.ToShortDateString(), DateTime.Now.ToShortDateString());

            objBook.SaveCopyAs(@".\TestExcel\aniruddha" + System.IO.Directory.GetFiles(@"C:\Documents and Settings\Aniruddha Singh\My Documents\TestExcel").Length.ToString() + ".xls");
            objBook.Close(false, missing, missing);
            ExcelApp.Workbooks.Close();
            ExcelApp.Quit();
            ExcelApp = null;
            GC.Collect();
            closeExcel();
        }


        #endregion

    }
}