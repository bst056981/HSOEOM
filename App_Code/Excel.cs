using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GemBox.Spreadsheet;
using System.Data;
using System.Drawing;

/// <summary>
/// Summary description for Excel
/// </summary>
public class Excel
{
	public Excel()
	{
        
	}
     public static void ExportToExcel(DataTable dt, String fileNme) {
        SpreadsheetInfo.SetLicense("E1H4-7MV0-01A9-XF45");
        ExcelFile excelFile = new ExcelFile();
        ExcelWorksheetCollection worksheets = excelFile.Worksheets;
        ExcelWorksheet ws = worksheets.Add(fileNme);
        ws.InsertDataTable(dt, "A1", true);
        for (int i = 0; i < dt.Columns.Count; i++) {
            ws.Rows[0].Cells[i].Style.FillPattern.SetPattern(FillPatternStyle.Gray12, Color.LightGray, Color.LightGray);
            ws.Rows[0].Cells[i].Style.Font.Weight = ExcelFont.BoldWeight;
            ws.Columns[i].AutoFit();
        }
        HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
        HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + fileNme + ".xls");
        excelFile.SaveXls(HttpContext.Current.Response.OutputStream);
    }

     public static void ExportToExcelCenter(DataTable dt, String fileNme)
     {
         SpreadsheetInfo.SetLicense("E1H4-7MV0-01A9-XF45");
         ExcelFile excelFile = new ExcelFile();
         ExcelWorksheetCollection worksheets = excelFile.Worksheets;
         ExcelWorksheet ws = worksheets.Add(fileNme);
         ws.InsertDataTable(dt, "A1", true);
         for (int i = 0; i < dt.Columns.Count; i++)
         {
             ws.Rows[0].Cells[i].Style.FillPattern.SetPattern(FillPatternStyle.Gray12, Color.LightGray, Color.LightGray);
             ws.Rows[0].Cells[i].Style.Font.Weight = ExcelFont.BoldWeight;
             ws.Columns[i].AutoFit();
         }
         for (int r = 0; r <= dt.Rows.Count; r++)
         {
             for (int c = 0; c <= dt.Columns.Count; c++)
             {
                 ws.Rows[r].Cells[c].Style.HorizontalAlignment = HorizontalAlignmentStyle.Center;
             }
         }
         HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
         HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + fileNme + ".xls");
         excelFile.SaveXls(HttpContext.Current.Response.OutputStream);
     }
     public static void ExportToExcel(DataTable dt, String fileNme, String tabNme) {
         SpreadsheetInfo.SetLicense("E1H4-7MV0-01A9-XF45");
         ExcelFile excelFile = new ExcelFile();
         ExcelWorksheetCollection worksheets = excelFile.Worksheets;
         ExcelWorksheet ws = worksheets.Add(tabNme);
         ws.InsertDataTable(dt, "A1", true);
         for (int i = 0; i < dt.Columns.Count; i++) {
             ws.Rows[0].Cells[i].Style.FillPattern.SetPattern(FillPatternStyle.Gray12, Color.LightGray, Color.LightGray);
             ws.Rows[0].Cells[i].Style.Font.Weight = ExcelFont.BoldWeight;
             ws.Columns[i].AutoFit();
         }
         HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
         HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + fileNme + ".xls");
         excelFile.SaveXls(HttpContext.Current.Response.OutputStream);
     }
}

