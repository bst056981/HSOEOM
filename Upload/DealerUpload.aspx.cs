using Agile.Domain;
using Agile.Helper;
using Agile.Services.Impl;
using Agile.Services.Interface;
using GemBox.Spreadsheet;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Text;
using System.Web;
using System.Web.Configuration;

public partial class Upload_DealerUpload : System.Web.UI.Page
{
    protected string _upload_date = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        divError.Visible = false;
        lblSuccess.Text = string.Empty;
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        lblSuccess.Text = string.Empty;
        if (uploadFile.HasFile)
        {
            string fileName = saveFile(uploadFile.PostedFile, WebConfigurationManager.AppSettings["DealerUpload"].ToString());
            string errors = UploadTempTable(fileName);
            if (errors.Contains("correctly"))
            {
                lblSuccess.Text = errors;
            }
            else
            {
                spanError.InnerHtml = errors;
                divError.Visible = true;
            }
        }
        else
        {
            spanError.InnerHtml = "No file!";
            divError.Visible = true;
        }
    }
    private string saveFile(HttpPostedFile file, string filefolder)
    {
        string fn = file.FileName.Substring(file.FileName.LastIndexOf("\\") + 1).Split('.')[0];
        DateTime _dateTime = DateTime.Now;
        string formattedTime = _dateTime.ToString("hhmmssfff");
        string formattedDate = _dateTime.ToString("MMddyyyy");
        string formattedFile = fn.Replace(" ", "") + "_" + formattedDate + "_" + formattedTime + "." + file.FileName.Split('.')[1];

        string path = HttpContext.Current.Request.MapPath("");
        path = path.Substring(0, 3);

        string SaveLocation = path + filefolder + "\\" + formattedFile;
        file.SaveAs(SaveLocation);

        return SaveLocation;
    }

    private string UploadTempTable(string fileName)
    {
        string errors = "";
        Customer c = new Customer();
        CustomerImpl ci = new CustomerImpl();

        OracleConnection conn = new OracleConnection(DBHelper.ConnString);
        DataTable dtExcelData = ReadExcelToDataTable(fileName);

        if (dtExcelData.Columns.Count != 16 && dtExcelData.Columns[0].ColumnName.Contains("ACCOUNT_NUMBER") && dtExcelData.Columns[1].ColumnName.Contains("COMPANY_NAME") && dtExcelData.Columns[4].ColumnName.Contains("PANEL_TYPE"))
            {
            return "File not loaded. Upload file format is not correct.";
        }
        else
        {
            string sql = "TRUNCATE TABLE CUSTOMER_TEST";
            //string sql = "TRUNCATE TABLE CUSTOMER";
            DataTable dt = DBHelper.SelectDataTable(sql);
            if (dt.Rows.Count != 0)
            {
                errors = "Customer table not deleted.";
            }
            else
            {
                //for (int i = 0; i < dtExcelData.Rows.Count; i++)
                //{
                //    c.CustId = DBHelper.SelectDecimal(Customer.GET_CUST_ID).ToString();
                //    c.Dice = dtExcelData.Rows[i][0].ToString().Trim();
                //    c.Name = dtExcelData.Rows[i][1].ToString().Trim();
                //    c.Dealer = dtExcelData.Rows[i][6].ToString().Trim();
                //    if (!String.IsNullOrEmpty(dtExcelData.Rows[i][7].ToString()))
                //    {
                //        DateTime dat = DateTime.Parse(dtExcelData.Rows[i][7].ToString());
                //        c.StartDate = dat.ToString("MM/dd/yyyy");
                //    }
                //    else { c.StartDate = ""; }
                //    if (!String.IsNullOrEmpty(dtExcelData.Rows[i][5].ToString()))
                //    {
                //        DateTime dat = DateTime.Parse(dtExcelData.Rows[i][5].ToString());
                //        c.InactiveDate = dat.ToString("MM/dd/yyyy");
                //    }
                //    else { c.InactiveDate = ""; }
                //    c.EnteredDate = DateTime.Now.ToString("MM/dd/yyyy");
                //    c.EnteredId = Session["userId"].ToString();
                //    ci.Insert(c);
                //    errors = i +  " Customers were loaded correctly!";
                //}

                string sql1 = "SELECT DISTINCT to_date(START_DATE, 'MM-DD-YYYY') START_DATE FROM CUSTOMER WHERE START_DATE IS NOT NULL ORDER BY START_DATE DESC";
                DataTable dt1 = DBHelper.SelectDataTable(sql1);

                var uploadDt = DateTime.Parse(dt1.Rows[0][0].ToString());
                var uploadDtDay1 = new DateTime(uploadDt.Year, uploadDt.Month, 1);
                var previousMonth = uploadDtDay1.AddDays(-1);
                _upload_date = previousMonth.ToString("MM/dd/yyyy");

                sql = "TRUNCATE TABLE CLEC_ADDS";
                dt = DBHelper.SelectDataTable(sql);
                if (dt.Rows.Count != 0)
                {
                    errors = "CLEC_ADDS table not deleted.";
                }
                else
                {
                    sql = "SELECT* FROM CUSTOMER C, DEALER_INFO DI WHERE C.DEALER = DI.DEALER AND DEALER_BREAKDOWN = 'Y' AND DEALER_REPORT NOT LIKE 'ILEC%' AND to_date(START_DATE, 'MM/DD/YYYY') >= to_date('" + _upload_date + "', 'MM/DD/YYYY')";                    
                    dt = DBHelper.SelectDataTable(sql);
                    if (dt.Rows.Count > 0)
                    {
                        ClecAdds ca = new ClecAdds();
                        ClecAddsImpl cai = new ClecAddsImpl();

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            ca.ClecAddsId = DBHelper.SelectDecimal(ClecAdds.GET_CLEC_ADDS_ID).ToString();
                            ca.Dice = dt.Rows[i][0].ToString().Trim();
                            ca.Name = dt.Rows[i][1].ToString().Trim();
                            ca.Type = dt.Rows[i][2].ToString().Trim();
                            ca.Panel = dt.Rows[i][3].ToString().Trim();
                            ca.Dealer = dt.Rows[i][4].ToString().Trim();
                            if (!String.IsNullOrEmpty(dt.Rows[i][5].ToString()))
                            {
                                DateTime dat = DateTime.Parse(dt.Rows[i][5].ToString());
                                ca.StartDate = dat.ToString("MM/dd/yyyy");
                            }
                            else { c.StartDate = ""; }
                            ca.Cycle = dt.Rows[i][6].ToString().Trim();
                            ca.Branch = dt.Rows[i][7].ToString().Trim();
                            ca.Amount = dt.Rows[i][8].ToString().Trim();
                            ca.Rep = dt.Rows[i][9].ToString().Trim();
                            ca.Service = dt.Rows[i][10].ToString().Trim();
                            ca.Tech = dt.Rows[i][11].ToString().Trim();
                            ca.Ban = dt.Rows[i][12].ToString().Trim();
                            ca.Rate = dt.Rows[i][13].ToString().Trim();
                            ca.EnteredDate = DateTime.Now.ToString("MM/dd/yyyy");
                            ca.EnteredId = Session["userId"].ToString();
                            cai.Insert(ca);
                        }
                    }

                    sql = "TRUNCATE TABLE CLEC_OUTS";
                    dt = DBHelper.SelectDataTable(sql);
                    if (dt.Rows.Count != 0)
                    {
                        errors = "CLEC_OUTS table not deleted.";
                    }
                    else
                    {
                        sql = "SELECT* FROM CUSTOMER C, DEALER_INFO DI WHERE C.DEALER = DI.DEALER AND DEALER_BREAKDOWN = 'Y' AND DEALER_REPORT NOT LIKE 'ILEC%' AND to_date(InactiveDate, 'MM/DD/YYYY') >= to_date('" + _upload_date + "', 'MM/DD/YYYY')";
                        dt = DBHelper.SelectDataTable(sql);
                        if (dt.Rows.Count > 0)
                        {
                            ClecOuts co = new ClecOuts();
                            ClecOutsImpl coi = new ClecOutsImpl();

                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                co.ClecOutsId = DBHelper.SelectDecimal(ClecOuts.GET_CLEC_OUTS_ID).ToString();
                                co.Dice = dt.Rows[i][0].ToString().Trim();
                                co.Name = dt.Rows[i][1].ToString().Trim();
                                co.Reason = dt.Rows[i][2].ToString().Trim();
                                co.Panel = dt.Rows[i][3].ToString().Trim();
                                if (!String.IsNullOrEmpty(dt.Rows[i][4].ToString()))
                                {
                                    DateTime dat = DateTime.Parse(dt.Rows[i][4].ToString());
                                    co.InactiveDate = dat.ToString("MM/dd/yyyy");
                                }
                                else { co.InactiveDate = ""; }
                                co.Dealer = dt.Rows[i][5].ToString().Trim();
                                if (!String.IsNullOrEmpty(dt.Rows[i][6].ToString()))
                                {
                                    DateTime dat = DateTime.Parse(dt.Rows[i][6].ToString());
                                    co.StartDate = dat.ToString("MM/dd/yyyy");
                                }
                                else { co.StartDate = ""; }
                                co.Rep = dt.Rows[i][7].ToString().Trim();
                                co.Service = dt.Rows[i][8].ToString().Trim();
                                co.Ban = dt.Rows[i][9].ToString().Trim();
                                co.Rate = dt.Rows[i][10].ToString().Trim();
                                co.EnteredDate = DateTime.Now.ToString("MM/dd/yyyy");
                                co.EnteredId = Session["userId"].ToString();
                                coi.Insert(co);
                            }
                        }

                        sql = "TRUNCATE TABLE ILEC_ADDS";
                        dt = DBHelper.SelectDataTable(sql);
                        if (dt.Rows.Count != 0)
                        {
                            errors = "ILEC_ADDS table not deleted.";
                        }
                        else
                        {
                            sql = "SELECT* FROM CUSTOMER C, DEALER_INFO DI WHERE C.DEALER = DI.DEALER AND DEALER_BREAKDOWN = 'Y' AND DEALER_REPORT LIKE 'ILEC%' AND to_date(START_DATE, 'MM/DD/YYYY') >= to_date('" + _upload_date + "', 'MM/DD/YYYY')";
                            dt = DBHelper.SelectDataTable(sql);
                            if (dt.Rows.Count > 0)
                            {
                                IlecAdds ia = new IlecAdds();
                                IlecAddsImpl iai = new IlecAddsImpl();

                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    ia.IlecAddsId = DBHelper.SelectDecimal(IlecAdds.GET_ILEC_ADDS_ID).ToString();
                                    ia.Dice = dt.Rows[i][0].ToString().Trim();
                                    ia.Name = dt.Rows[i][1].ToString().Trim();
                                    ia.Type = dt.Rows[i][2].ToString().Trim();
                                    ia.Panel = dt.Rows[i][3].ToString().Trim();
                                    ia.Dealer = dt.Rows[i][4].ToString().Trim();
                                    if (!String.IsNullOrEmpty(dt.Rows[i][5].ToString()))
                                    {
                                        DateTime dat = DateTime.Parse(dt.Rows[i][5].ToString());
                                        ia.StartDate = dat.ToString("MM/dd/yyyy");
                                    }
                                    else { ia.StartDate = ""; }
                                    ia.Cycle = dt.Rows[i][6].ToString().Trim();
                                    ia.Branch = dt.Rows[i][7].ToString().Trim();
                                    ia.Amount = dt.Rows[i][8].ToString().Trim();
                                    ia.Rep = dt.Rows[i][9].ToString().Trim();
                                    ia.Service = dt.Rows[i][10].ToString().Trim();
                                    ia.Tech = dt.Rows[i][11].ToString().Trim();
                                    ia.Ban = dt.Rows[i][12].ToString().Trim();
                                    ia.Rate = dt.Rows[i][13].ToString().Trim();
                                    ia.EnteredDate = DateTime.Now.ToString("MM/dd/yyyy");
                                    ia.EnteredId = Session["userId"].ToString();
                                    iai.Insert(ia);
                                }
                            }

                            sql = "TRUNCATE TABLE ILEC_OUTS";
                            dt = DBHelper.SelectDataTable(sql);
                            if (dt.Rows.Count != 0)
                            {
                                errors = "ILEC_OUTS table not deleted.";
                            }
                            else
                            {
                                sql = "SELECT* FROM CUSTOMER C, DEALER_INFO DI WHERE C.DEALER = DI.DEALER AND DEALER_BREAKDOWN = 'Y' AND DEALER_REPORT LIKE 'ILEC%' AND to_date(InactiveDate, 'MM/DD/YYYY') >= to_date('" + _upload_date + "', 'MM/DD/YYYY')";
                                dt = DBHelper.SelectDataTable(sql);
                                if (dt.Rows.Count > 0)
                                {
                                    IlecOuts io = new IlecOuts();
                                    IlecOutsImpl ioi = new IlecOutsImpl();

                                    for (int i = 0; i < dt.Rows.Count; i++)
                                    {
                                        io.IlecOutsId = DBHelper.SelectDecimal(IlecOuts.GET_ILEC_OUTS_ID).ToString();
                                        io.Dice = dt.Rows[i][0].ToString().Trim();
                                        io.Name = dt.Rows[i][1].ToString().Trim();
                                        io.Reason = dt.Rows[i][2].ToString().Trim();
                                        io.Panel = dt.Rows[i][3].ToString().Trim();
                                        if (!String.IsNullOrEmpty(dt.Rows[i][4].ToString()))
                                        {
                                            DateTime dat = DateTime.Parse(dt.Rows[i][4].ToString());
                                            io.InactiveDate = dat.ToString("MM/dd/yyyy");
                                        }
                                        else { io.InactiveDate = ""; }
                                        io.Dealer = dt.Rows[i][5].ToString().Trim();
                                        if (!String.IsNullOrEmpty(dt.Rows[i][6].ToString()))
                                        {
                                            DateTime dat = DateTime.Parse(dt.Rows[i][6].ToString());
                                            io.StartDate = dat.ToString("MM/dd/yyyy");
                                        }
                                        else {io.StartDate = ""; }
                                        io.Rep = dt.Rows[i][7].ToString().Trim();
                                        io.Service = dt.Rows[i][8].ToString().Trim();
                                        io.Ban = dt.Rows[i][9].ToString().Trim();
                                        io.Rate = dt.Rows[i][10].ToString().Trim();
                                        io.EnteredDate = DateTime.Now.ToString("MM/dd/yyyy");
                                        io.EnteredId = Session["userId"].ToString();
                                        ioi.Insert(io);
                                    }
                                }

                            }


                        }
                    }
                }
            }
        }

        return errors;
    }

    private DataTable ReadExcelToDataTable(string filename)
    {
        DataTable dtExcelData = new DataTable("DealerUpload");

        string xlsxConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0 xml;HDR=Yes;'";
        xlsxConn = string.Format(xlsxConn, filename);

        using (OleDbConnection oleDbCon = new OleDbConnection(xlsxConn))
        {
            string query = string.Format("SELECT ACCOUNT_NUMBER, COMPANY_NAME, IDENTIFIER_1, IDENTIFIER_2, PANEL_TYPE, INACT_DATE, DEALER, START_DATE, MAP, S_BRANCH, SITE_SALES_TAX_GROUP, SITE_SALESREP_GROUP, SERVICE_CODE, GEO_CODE, BLANKET_PO_NUMBER, RATE_TABLE FROM [ALSUBSCR$]");
            //string query = string.Format("SELECT * FROM [ALSUBSCR$]");
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter();
            dataAdapter.SelectCommand = new OleDbCommand(query, oleDbCon);
            dataAdapter.Fill(dtExcelData);
            return dtExcelData;
        }
    }
}