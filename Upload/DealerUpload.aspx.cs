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
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;

public partial class Upload_DealerUpload : System.Web.UI.Page
{
    protected string _endOfMonth = "";
    protected string _prevEndOfMonth = "";
    protected string _prev2EndOfMonth = "";
    protected int _total1 = 0;
    protected int _total2 = 0;
    protected int _total3 = 0;
    protected decimal _addsIlecTotal1 = 0;
    protected decimal _addsIlecTotal2 = 0;
    protected decimal _addsIlecTotal3 = 0;
    protected decimal _addsIlecTotal4 = 0;
    protected decimal _outsIlecTotal1 = 0;
    protected decimal _outsIlecTotal2 = 0;
    protected decimal _outsIlecTotal3 = 0;
    protected decimal _outsIlecTotal4 = 0;
    protected decimal _addsClecTotal1 = 0;
    protected decimal _addsClecTotal2 = 0;
    protected decimal _addsClecTotal3 = 0;
    protected decimal _addsClecTotal4 = 0;
    protected decimal _outsClecTotal1 = 0;
    protected decimal _outsClecTotal2 = 0;
    protected decimal _outsClecTotal3 = 0;
    protected decimal _outsClecTotal4 = 0;
    protected decimal _decTotal1 = 0;
    protected decimal _decTotal2 = 0;
    protected decimal _decTotal3 = 0;
    protected decimal _decTotal4 = 0;
    protected decimal _decTotal5 = 0;
    protected decimal _decTotal6 = 0;
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
                calculate_totals();
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

    private string UploadTempTableTest(string fileName)
    {
        string errors = "";
        Customer c = new Customer();
        CustomerImpl ci = new CustomerImpl();

        OracleConnection conn = new OracleConnection(DBHelper.ConnString);
        DataTable dtExcelData = ReadExcelToDataTable(fileName);
        return errors;
    }

    private string UploadTempTable(string fileName)
    {
        int cntRec = 0;
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
            string sql = "TRUNCATE TABLE CUSTOMER";
            DataTable dt = DBHelper.SelectDataTable(sql);
            if (dt.Rows.Count != 0)
            {
                errors = "Customer table not deleted. ";
            }
            else
            {
                for (int i = 0; i < dtExcelData.Rows.Count; i++)
                {
                    if (!String.IsNullOrEmpty(dtExcelData.Rows[i][1].ToString()))
                    {
                        c.CustId = DBHelper.SelectDecimal(Customer.GET_CUST_ID).ToString();
                        c.Dice = dtExcelData.Rows[i][0].ToString().Trim();
                        c.Name = dtExcelData.Rows[i][1].ToString().Trim();
                        c.Reason = dtExcelData.Rows[i][2].ToString().Trim();
                        c.Type = dtExcelData.Rows[i][3].ToString().Trim();
                        c.Panel = dtExcelData.Rows[i][4].ToString().Trim();
                        if (!String.IsNullOrEmpty(dtExcelData.Rows[i][5].ToString()))
                        {
                            DateTime dat = DateTime.Parse(dtExcelData.Rows[i][5].ToString());
                            c.InactiveDate = dat.ToString("MM/dd/yyyy");
                        }
                        else { c.InactiveDate = ""; }
                        c.Dealer = dtExcelData.Rows[i][6].ToString().Trim();
                        if (!String.IsNullOrEmpty(dtExcelData.Rows[i][7].ToString()))
                        {
                            DateTime dat = DateTime.Parse(dtExcelData.Rows[i][7].ToString());
                            c.StartDate = dat.ToString("MM/dd/yyyy");
                        }
                        else { c.StartDate = ""; }
                        c.Cycle = dtExcelData.Rows[i][8].ToString().Trim();
                        c.Branch = dtExcelData.Rows[i][9].ToString().Trim();
                        c.Amount = dtExcelData.Rows[i][10].ToString().Trim();
                        c.Rep = dtExcelData.Rows[i][11].ToString().Trim();
                        c.Service = dtExcelData.Rows[i][12].ToString().Trim();
                        c.Tech = dtExcelData.Rows[i][13].ToString().Trim();
                        c.Ban = dtExcelData.Rows[i][14].ToString().Trim();
                        c.Rate = dtExcelData.Rows[i][15].ToString().Trim();

                        bool isNumeric = Regex.IsMatch(c.Rate, @"^[0-9]+(\.[0-9]+)?$");
                        if (!isNumeric)
                            c.Rate = "0.00";

                        c.EnteredDate = DateTime.Now.ToString("MM/dd/yyyy");
                        c.EnteredId = Session["userId"].ToString();
                        ci.Insert(c);
                        cntRec = cntRec + 1;
                        errors = cntRec + " Customers were loaded correctly!";
                    }
                }

                DateTime today = DateTime.Today;
                _endOfMonth = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month)).ToShortDateString();
                _prevEndOfMonth = new DateTime(today.Year, today.Month - 1, DateTime.DaysInMonth(today.Year, today.Month - 1)).ToShortDateString();
                _prev2EndOfMonth = new DateTime(today.Year, today.Month - 2, DateTime.DaysInMonth(today.Year, today.Month - 2)).ToShortDateString();

                _endOfMonth = Convert.ToDateTime(_endOfMonth).ToString("MM/dd/yyyy");
                _prevEndOfMonth = Convert.ToDateTime(_prevEndOfMonth).ToString("MM/dd/yyyy");
                _prev2EndOfMonth = Convert.ToDateTime(_prev2EndOfMonth).ToString("MM/dd/yyyy");



                sql = "TRUNCATE TABLE CLEC_ADDS";
                dt = DBHelper.SelectDataTable(sql);
                if (dt.Rows.Count != 0)
                {
                    errors = errors + "CLEC_ADDS table not deleted. ";
                }
                else
                {
                    sql = "SELECT * FROM CUSTOMER C, DEALER_INFO DI WHERE C.DEALER = DI.DEALER AND DEALER_BREAKDOWN = 'Y' AND ADDS_OUTS = 'CLEC' AND to_date(START_DATE, 'MM/DD/YYYY') > to_date('" + _prevEndOfMonth + "', 'MM/DD/YYYY') AND (INACTIVE_DATE IS NULL OR INACTIVE_DATE = ' ')";
                    dt = DBHelper.SelectDataTable(sql);
                    if (dt.Rows.Count > 0)
                    {
                        ClecAdds ca = new ClecAdds();
                        ClecAddsImpl cai = new ClecAddsImpl();

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            ca.ClecAddsId = DBHelper.SelectDecimal(ClecAdds.GET_CLEC_ADDS_ID).ToString();
                            ca.Dice = dt.Rows[i][1].ToString().Trim();
                            ca.Name = dt.Rows[i][2].ToString().Trim();
                            ca.Dealer = dt.Rows[i][3].ToString().Trim();
                            if (!String.IsNullOrEmpty(dt.Rows[i][4].ToString()))
                            {
                                DateTime dat = DateTime.Parse(dt.Rows[i][4].ToString());
                                ca.StartDate = dat.ToString("MM/dd/yyyy");
                            }
                            else { ca.StartDate = ""; }
                            ca.Type = dt.Rows[i][8].ToString().Trim();
                            ca.Panel = dt.Rows[i][9].ToString().Trim();
                            ca.Cycle = dt.Rows[i][10].ToString().Trim();
                            ca.Branch = dt.Rows[i][11].ToString().Trim();
                            ca.Amount = dt.Rows[i][12].ToString().Trim();
                            ca.Rep = dt.Rows[i][13].ToString().Trim();
                            ca.Service = dt.Rows[i][14].ToString().Trim();
                            ca.Tech = dt.Rows[i][15].ToString().Trim();
                            ca.Ban = dt.Rows[i][16].ToString().Trim();
                            ca.Rate = dt.Rows[i][17].ToString().Trim();
                            ca.EnteredDate = DateTime.Now.ToString("MM/dd/yyyy");
                            ca.EnteredId = Session["userId"].ToString();
                            cai.Insert(ca);
                        }
                    }

                    sql = "TRUNCATE TABLE CLEC_OUTS";
                    dt = DBHelper.SelectDataTable(sql);
                    if (dt.Rows.Count != 0)
                    {
                        errors = errors + "CLEC_OUTS table not deleted. ";
                    }
                    else
                    {
                        sql = "SELECT * FROM CUSTOMER C, DEALER_INFO DI WHERE C.DEALER = DI.DEALER AND DEALER_BREAKDOWN = 'Y' AND ADDS_OUTS = 'CLEC' AND to_date(INACTIVE_DATE, 'MM/DD/YYYY') > to_date('" + _prevEndOfMonth + "', 'MM/DD/YYYY') AND to_date(START_DATE, 'MM/DD/YYYY') <= to_date('" + _prevEndOfMonth + "', 'MM/DD/YYYY')";
                        dt = DBHelper.SelectDataTable(sql);
                        if (dt.Rows.Count > 0)
                        {
                            ClecOuts co = new ClecOuts();
                            ClecOutsImpl coi = new ClecOutsImpl();

                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                co.ClecOutsId = DBHelper.SelectDecimal(ClecOuts.GET_CLEC_OUTS_ID).ToString();
                                co.Dice = dt.Rows[i][1].ToString().Trim();
                                co.Name = dt.Rows[i][2].ToString().Trim();
                                co.Dealer = dt.Rows[i][3].ToString().Trim();
                                if (!String.IsNullOrEmpty(dt.Rows[i][4].ToString()))
                                {
                                    DateTime dat = DateTime.Parse(dt.Rows[i][4].ToString());
                                    co.StartDate = dat.ToString("MM/dd/yyyy");
                                }
                                else { co.StartDate = ""; }
                                if (!String.IsNullOrEmpty(dt.Rows[i][5].ToString()))
                                {
                                    DateTime dat = DateTime.Parse(dt.Rows[i][5].ToString());
                                    co.InactiveDate = dat.ToString("MM/dd/yyyy");
                                }
                                else { co.InactiveDate = ""; }
                                co.Panel = dt.Rows[i][9].ToString().Trim();
                                co.Rep = dt.Rows[i][13].ToString().Trim();
                                co.Service = dt.Rows[i][14].ToString().Trim();
                                co.Ban = dt.Rows[i][16].ToString().Trim();
                                co.Rate = dt.Rows[i][17].ToString().Trim();
                                co.Reason = dt.Rows[i][18].ToString().Trim();
                                co.EnteredDate = DateTime.Now.ToString("MM/dd/yyyy");
                                co.EnteredId = Session["userId"].ToString();
                                coi.Insert(co);
                            }
                        }

                        sql = "TRUNCATE TABLE ILEC_ADDS";
                        dt = DBHelper.SelectDataTable(sql);
                        if (dt.Rows.Count != 0)
                        {
                            errors = errors + "ILEC_ADDS table not deleted. ";
                        }
                        else
                        {
                            sql = "SELECT * FROM CUSTOMER C, DEALER_INFO DI WHERE C.DEALER = DI.DEALER AND DEALER_BREAKDOWN = 'Y' AND ADDS_OUTS = 'ILEC' AND to_date(START_DATE, 'MM/DD/YYYY') > to_date('" + _prevEndOfMonth + "', 'MM/DD/YYYY')  AND (INACTIVE_DATE IS NULL OR INACTIVE_DATE = ' ')";
                            dt = DBHelper.SelectDataTable(sql);
                            if (dt.Rows.Count > 0)
                            {
                                IlecAdds ia = new IlecAdds();
                                IlecAddsImpl iai = new IlecAddsImpl();

                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    ia.IlecAddsId = DBHelper.SelectDecimal(IlecAdds.GET_ILEC_ADDS_ID).ToString();
                                    ia.Dice = dt.Rows[i][1].ToString().Trim();
                                    ia.Name = dt.Rows[i][2].ToString().Trim();
                                    ia.Dealer = dt.Rows[i][3].ToString().Trim();
                                    if (!String.IsNullOrEmpty(dt.Rows[i][4].ToString()))
                                    {
                                        DateTime dat = DateTime.Parse(dt.Rows[i][4].ToString());
                                        ia.StartDate = dat.ToString("MM/dd/yyyy");
                                    }
                                    else { ia.StartDate = ""; }
                                    ia.Type = dt.Rows[i][8].ToString().Trim();
                                    ia.Panel = dt.Rows[i][9].ToString().Trim();
                                    ia.Cycle = dt.Rows[i][10].ToString().Trim();
                                    ia.Branch = dt.Rows[i][11].ToString().Trim();
                                    ia.Amount = dt.Rows[i][12].ToString().Trim();
                                    ia.Rep = dt.Rows[i][13].ToString().Trim();
                                    ia.Service = dt.Rows[i][14].ToString().Trim();
                                    ia.Tech = dt.Rows[i][15].ToString().Trim();
                                    ia.Ban = dt.Rows[i][16].ToString().Trim();
                                    ia.Rate = dt.Rows[i][17].ToString().Trim();
                                    ia.EnteredDate = DateTime.Now.ToString("MM/dd/yyyy");
                                    ia.EnteredId = Session["userId"].ToString();
                                    iai.Insert(ia);
                                }
                            }

                            sql = "TRUNCATE TABLE ILEC_OUTS";
                            dt = DBHelper.SelectDataTable(sql);
                            if (dt.Rows.Count != 0)
                            {
                                errors = errors + "ILEC_OUTS table not deleted. ";
                            }
                            else
                            {
                                sql = "SELECT * FROM CUSTOMER C, DEALER_INFO DI WHERE C.DEALER = DI.DEALER AND DEALER_BREAKDOWN = 'Y' AND ADDS_OUTS = 'ILEC' AND to_date(INACTIVE_DATE, 'MM/DD/YYYY') > to_date('" + _prevEndOfMonth + "', 'MM/DD/YYYY') AND to_date(START_DATE, 'MM/DD/YYYY') <= to_date('" + _prevEndOfMonth + "', 'MM/DD/YYYY')";
                                dt = DBHelper.SelectDataTable(sql);
                                if (dt.Rows.Count > 0)
                                {
                                    IlecOuts io = new IlecOuts();
                                    IlecOutsImpl ioi = new IlecOutsImpl();

                                    for (int i = 0; i < dt.Rows.Count; i++)
                                    {
                                        io.IlecOutsId = DBHelper.SelectDecimal(IlecOuts.GET_ILEC_OUTS_ID).ToString();
                                        io.Dice = dt.Rows[i][1].ToString().Trim();
                                        io.Name = dt.Rows[i][2].ToString().Trim();
                                        io.Dealer = dt.Rows[i][3].ToString().Trim();
                                        if (!String.IsNullOrEmpty(dt.Rows[i][4].ToString()))
                                        {
                                            DateTime dat = DateTime.Parse(dt.Rows[i][4].ToString());
                                            io.StartDate = dat.ToString("MM/dd/yyyy");
                                        }
                                        else { io.StartDate = ""; }
                                        if (!String.IsNullOrEmpty(dt.Rows[i][5].ToString()))
                                        {
                                            DateTime dat = DateTime.Parse(dt.Rows[i][5].ToString());
                                            io.InactiveDate = dat.ToString("MM/dd/yyyy");
                                        }
                                        else { io.InactiveDate = ""; }
                                        io.Panel = dt.Rows[i][9].ToString().Trim();
                                        io.Rep = dt.Rows[i][13].ToString().Trim();
                                        io.Service = dt.Rows[i][14].ToString().Trim();
                                        io.Ban = dt.Rows[i][16].ToString().Trim();
                                        io.Rate = dt.Rows[i][17].ToString().Trim();
                                        io.Reason = dt.Rows[i][18].ToString().Trim();
                                        io.EnteredDate = DateTime.Now.ToString("MM/dd/yyyy");
                                        io.EnteredId = Session["userId"].ToString();
                                        ioi.Insert(io);
                                    }
                                }
                                sql = "DELETE FROM CUSTOMER_COUNT WHERE to_date(CUST_CNT_DATE, 'MM/DD/YYYY') = to_date('" + _endOfMonth + "', 'MM/DD/YYYY')";
                                dt = DBHelper.SelectDataTable(sql);
                            }
                        }
                    }
                }
            }
        }

        return errors;
    }

    protected void calculate_totals()
    {
        string sql = "SELECT DI.DEALER, COALESCE(ACTIVE.CNT, 0) ACTIVE, HDR.CUST_CNT_HDR_REC_ID FROM DEALER_INFO DI LEFT OUTER JOIN (SELECT DISTINCT DEALER, COUNT(DEALER) AS CNT FROM CUSTOMER WHERE INACTIVE_DATE IS NULL AND DEALER != 'CPRT' GROUP BY DEALER UNION SELECT DISTINCT DEALER, 113 AS CNT  FROM CUSTOMER WHERE INACTIVE_DATE IS NULL AND DEALER = 'CPRT'  GROUP BY DEALER) ACTIVE ON DI.DEALER = ACTIVE.DEALER LEFT OUTER JOIN (SELECT DISTINCT HEADING1 AS DEALER, CUST_CNT_HDR_REC_ID  FROM CUSTOMER_COUNT_HEADINGS) HDR ON DI.DEALER = HDR.DEALER WHERE CUST_CNT_HDR_REC_ID< 103300 ORDER BY DEALER";
        DataTable dtDealerTotal = DBHelper.SelectDataTable(sql);

        CustomerCount cc = new CustomerCount();
        CustomerCountImpl cci = new CustomerCountImpl();
        cc.CustCntDate = _endOfMonth;

        for (int i = 0; i < dtDealerTotal.Rows.Count; i++)
        {
            cc.RecId = DBHelper.SelectDecimal(CustomerCount.GET_REC_ID).ToString();
            cc.CustCnt = dtDealerTotal.Rows[i][1].ToString().Trim();
            cc.CustCntRecId = dtDealerTotal.Rows[i][2].ToString();
            cci.Insert(cc);
            switch (cc.CustCntRecId)
            {
                case "100100":
                case "100200":
                case "100300":
                case "100400":
                case "100500":
                case "100600":
                case "100700":
                case "100800":
                case "100900":
                case "101000":
                case "101100":
                case "101200":
                case "101300":
                case "101400":
                case "101500":
                case "101600":
                case "101700":
                case "101800":
                case "101900":
                case "102000":
                    _total1 = _total1 + Convert.ToInt32(cc.CustCnt);
                    break;
                case "102300":
                case "102400":
                    _total2 = _total2 + Convert.ToInt32(cc.CustCnt);
                    break;
                case "102700":
                case "102800":
                case "102900":
                case "103000":
                case "103100":
                case "103200":
                case "103300":
                    _total3 = _total3 + Convert.ToInt32(cc.CustCnt);
                    break;

            }
        }
        // Clec Monitored Accts
        cc.RecId = DBHelper.SelectDecimal(CustomerCount.GET_REC_ID).ToString();
        cc.CustCnt = _total1.ToString();
        cc.CustCntRecId = "102100";
        cci.Insert(cc);
        cc.RecId = DBHelper.SelectDecimal(CustomerCount.GET_REC_ID).ToString();
        cc.CustCntRecId = "103500";
        cci.Insert(cc);

        // Ilec Agent Accounts 
        cc.RecId = DBHelper.SelectDecimal(CustomerCount.GET_REC_ID).ToString();
        cc.CustCnt = _total2.ToString();
        cc.CustCntRecId = "102500";
        cci.Insert(cc);
        cc.RecId = DBHelper.SelectDecimal(CustomerCount.GET_REC_ID).ToString();
        cc.CustCntRecId = "103600";
        cci.Insert(cc);

        // Wholesale Dealer Accounts
        cc.RecId = DBHelper.SelectDecimal(CustomerCount.GET_REC_ID).ToString();
        cc.CustCnt = _total3.ToString();
        cc.CustCntRecId = "103300";
        cci.Insert(cc);
        cc.RecId = DBHelper.SelectDecimal(CustomerCount.GET_REC_ID).ToString();
        cc.CustCntRecId = "103700";
        cci.Insert(cc);

        // Total accounts monitored
        cc.RecId = DBHelper.SelectDecimal(CustomerCount.GET_REC_ID).ToString();
        int total = _total1 + _total2 + _total3;
        cc.CustCnt = total.ToString();
        cc.CustCntRecId = "103900";
        cci.Insert(cc);

        sql = "(SELECT (CURR - PREV) CNT FROM (SELECT DISTINCT (SELECT sum(CUST_CNT) CUST_CNT FROM CUSTOMER_COUNT WHERE(CUST_CNT_REC_ID = '100100' OR CUST_CNT_REC_ID = '100200' OR CUST_CNT_REC_ID = '100400' OR CUST_CNT_REC_ID = '100500') AND((to_char(to_date(CUST_CNT_DATE, 'MM-DD-YYYY'), 'DD-MON-YYYY')) = (to_char(to_date('" + _prev2EndOfMonth + "', 'MM-DD-YYYY'), 'DD-MON-YYYY'))) GROUP BY CUST_CNT_DATE) AS PREV, (SELECT sum(CUST_CNT) CUST_CNT FROM CUSTOMER_COUNT WHERE(CUST_CNT_REC_ID = '100100' OR CUST_CNT_REC_ID = '100200' OR CUST_CNT_REC_ID = '100400' OR CUST_CNT_REC_ID = '100500') AND((to_char(to_date(CUST_CNT_DATE, 'MM-DD-YYYY'), 'DD-MON-YYYY')) = (to_char(to_date('" + _prevEndOfMonth + "', 'MM-DD-YYYY'), 'DD-MON-YYYY'))) GROUP BY CUST_CNT_DATE) AS CURR FROM CUSTOMER_COUNT)) UNION ALL (SELECT (CURR -PREV) CNT FROM(SELECT DISTINCT (SELECT sum(CUST_CNT) CUST_CNT FROM CUSTOMER_COUNT WHERE CUST_CNT_REC_ID = '102100' AND ((to_char(to_date(CUST_CNT_DATE, 'MM-DD-YYYY'), 'DD-MON-YYYY')) = (to_char(to_date('" + _prev2EndOfMonth + "', 'MM-DD-YYYY'), 'DD-MON-YYYY'))) GROUP BY CUST_CNT_DATE) AS PREV, (SELECT sum(CUST_CNT) CUST_CNT FROM CUSTOMER_COUNT WHERE CUST_CNT_REC_ID = '102100' AND((to_char(to_date(CUST_CNT_DATE, 'MM-DD-YYYY'), 'DD-MON-YYYY')) = (to_char(to_date('" + _prevEndOfMonth + "', 'MM-DD-YYYY'), 'DD-MON-YYYY'))) GROUP BY CUST_CNT_DATE) AS CURR FROM CUSTOMER_COUNT)) UNION ALL (SELECT (CURR -PREV) CNT FROM(SELECT DISTINCT (SELECT sum(CUST_CNT) CUST_CNT FROM CUSTOMER_COUNT WHERE CUST_CNT_REC_ID = '102500' AND ((to_char(to_date(CUST_CNT_DATE, 'MM-DD-YYYY'), 'DD-MON-YYYY')) = (to_char(to_date('" + _prev2EndOfMonth + "', 'MM-DD-YYYY'), 'DD-MON-YYYY'))) GROUP BY CUST_CNT_DATE) AS PREV, (SELECT sum(CUST_CNT) CUST_CNT FROM CUSTOMER_COUNT WHERE CUST_CNT_REC_ID = '102500' AND((to_char(to_date(CUST_CNT_DATE, 'MM-DD-YYYY'), 'DD-MON-YYYY')) = (to_char(to_date('" + _prevEndOfMonth + "', 'MM-DD-YYYY'), 'DD-MON-YYYY'))) GROUP BY CUST_CNT_DATE) AS CURR FROM CUSTOMER_COUNT)) UNION ALL (SELECT (CURR -PREV) CNT FROM(SELECT DISTINCT (SELECT sum(CUST_CNT) CUST_CNT FROM CUSTOMER_COUNT WHERE CUST_CNT_REC_ID = '103300' AND ((to_char(to_date(CUST_CNT_DATE, 'MM-DD-YYYY'), 'DD-MON-YYYY')) = (to_char(to_date('" + _prev2EndOfMonth + "', 'MM-DD-YYYY'), 'DD-MON-YYYY'))) GROUP BY CUST_CNT_DATE) AS PREV, (SELECT sum(CUST_CNT) CUST_CNT FROM CUSTOMER_COUNT WHERE CUST_CNT_REC_ID = '103300' AND((to_char(to_date(CUST_CNT_DATE, 'MM-DD-YYYY'), 'DD-MON-YYYY')) = (to_char(to_date('" + _prevEndOfMonth + "', 'MM-DD-YYYY'), 'DD-MON-YYYY'))) GROUP BY CUST_CNT_DATE) AS CURR FROM CUSTOMER_COUNT))";
        DataTable dtDealerGainedTotal = DBHelper.SelectDataTable(sql);

        for (int i = 0; i < dtDealerGainedTotal.Rows.Count; i++)
        {
            cc.RecId = DBHelper.SelectDecimal(CustomerCount.GET_REC_ID).ToString();
            cc.CustCnt = dtDealerGainedTotal.Rows[i][0].ToString().Trim();

            switch (i)
            {
                case 0:
                    cc.CustCntRecId = "104000";
                    _decTotal1 = Convert.ToDecimal(dtDealerGainedTotal.Rows[i][0].ToString());
                    _decTotal6 = Convert.ToDecimal(dtDealerGainedTotal.Rows[i][0].ToString());
                    break;
                case 1:
                    cc.CustCntRecId = "104100";
                    _decTotal2 = Convert.ToDecimal(dtDealerGainedTotal.Rows[i][0].ToString());
                    _decTotal5 = _decTotal2 - _decTotal1;
                    _decTotal6 = _decTotal6 + _decTotal5;
                    cc.CustCnt = _decTotal5.ToString();
                    break;
                case 2:
                    cc.CustCntRecId = "104200";
                    _decTotal3 = Convert.ToDecimal(dtDealerGainedTotal.Rows[i][0].ToString());
                    _decTotal6 = _decTotal6 + _decTotal3;
                    break;
                case 3:
                    cc.CustCntRecId = "104300";
                    _decTotal4 = Convert.ToDecimal(dtDealerGainedTotal.Rows[i][0].ToString());
                    _decTotal6 = _decTotal6 + _decTotal4;
                    break;
            }
            cci.Insert(cc);
        }

        cc.CustCntRecId = "104400";
        cc.CustCnt = _decTotal6.ToString();
        cci.Insert(cc);


        _total1 = _total2 = _total3 = 0;
        decimal adds = 0;
        decimal outs = 0;

        sql = "SELECT DEALER_REPORT, SUM(CNT) CNT, SUM(RATE_OUTS) AS RATE_OUTS, SUM(RATE_ADDS) AS RATE_ADDS FROM DEALER_CNT_RATES_VW VW, DEALER_INFO D WHERE VW.DEALER = D.DEALER AND DEALER_REPORT != 'OTHER' GROUP BY DEALER_REPORT UNION ALL SELECT 'CLEC WHOLSALE' DEALER_REPORT, SUM(CNT) CNT, SUM(RATE_OUTS) AS RATE_OUTS, SUM(RATE_ADDS) AS RATE_ADDS FROM DEALER_CNT_RATES_VW VW, DEALER_INFO D WHERE VW.DEALER = D.DEALER AND(DEALER_REPORT = 'CLEC SEC' OR DEALER_REPORT = 'WHOLESALE')  GROUP BY 1 ORDER BY DEALER_REPORT";
        DataTable dtDealerReportTotal = DBHelper.SelectDataTable(sql);

        for (int i = 0; i < dtDealerReportTotal.Rows.Count; i++)
        {
            cc.RecId = DBHelper.SelectDecimal(CustomerCount.GET_REC_ID).ToString();
            cc.CustCnt = dtDealerReportTotal.Rows[i][1].ToString().Trim();

            adds = outs = 0;

            if (!String.IsNullOrEmpty(dtDealerReportTotal.Rows[i][2].ToString()))
                outs = Convert.ToDecimal(dtDealerReportTotal.Rows[i][2].ToString());

            if (!String.IsNullOrEmpty(dtDealerReportTotal.Rows[i][3].ToString()))
                adds = Convert.ToDecimal(dtDealerReportTotal.Rows[i][3].ToString());


            if (String.IsNullOrEmpty(cc.CustCnt))
                cc.CustCnt = "0";
            switch (dtDealerReportTotal.Rows[i][0].ToString())
            {
                case "CLEC SMART":
                    cc.CustCntRecId = "105200";
                    _total1 = _total1 + Convert.ToInt32(cc.CustCnt);
                    _outsClecTotal1 = _outsClecTotal1 + outs;
                    _addsClecTotal1 = _addsClecTotal1 + adds;
                    break;
                case "ILEC SMART":
                    cc.CustCntRecId = "105300";
                    _total1 = _total1 + Convert.ToInt32(cc.CustCnt);
                    _outsIlecTotal1 = _outsIlecTotal1 + outs;
                    _addsIlecTotal1 = _addsIlecTotal1 + adds;
                    break;
                case "CLEC WHOLSALE":
                    cc.CustCntRecId = "105400";
                    _total2 = _total2 + Convert.ToInt32(cc.CustCnt);
                    _outsClecTotal2 = _outsClecTotal2 + outs;
                    _addsClecTotal2 = _addsClecTotal2 + adds;
                    break;
                case "ILEC SEC":
                    cc.CustCntRecId = "105500";
                    _total2 = _total2 + Convert.ToInt32(cc.CustCnt);
                    _outsIlecTotal2 = _outsIlecTotal2 + outs;
                    _addsIlecTotal2 = _addsIlecTotal2 + adds;
                    break;
                case "NON MON":
                    cc.CustCntRecId = "105600";
                    break;
                case "WHOLESALE":
                    cc.CustCntRecId = "105700";
                    break;

            }
            if (dtDealerReportTotal.Rows[i][0].ToString() != "CLEC SEC")
                cci.Insert(cc);
        }

        // Total Smarthome Accounts - 105200 + 105300
        cc.RecId = DBHelper.SelectDecimal(CustomerCount.GET_REC_ID).ToString();
        cc.CustCnt = _total1.ToString();
        cc.CustCntRecId = "105800";
        cci.Insert(cc);

        // Total Security Accounts - 105400 + 105500
        cc.RecId = DBHelper.SelectDecimal(CustomerCount.GET_REC_ID).ToString();
        cc.CustCnt = _total2.ToString();
        cc.CustCntRecId = "105900";
        cci.Insert(cc);

        // Total accounts - 105200 + 105300 + 105400 + 105500
        cc.RecId = DBHelper.SelectDecimal(CustomerCount.GET_REC_ID).ToString();
        _total3 = _total2 + _total1;
        cc.CustCnt = _total3.ToString();
        cc.CustCntRecId = "106000";
        cci.Insert(cc);

        // ILEC SMART ADDS
        cc.RecId = DBHelper.SelectDecimal(CustomerCount.GET_REC_ID).ToString();
        cc.CustCnt = _addsIlecTotal1.ToString();
        cc.CustCntRecId = "108100";
        cci.Insert(cc);

        // ILEC SECURITY ADDS
        cc.RecId = DBHelper.SelectDecimal(CustomerCount.GET_REC_ID).ToString();
        cc.CustCnt = _addsIlecTotal2.ToString();
        cc.CustCntRecId = "108200";
        cci.Insert(cc);

        // ILEC SMART OUTS
        cc.RecId = DBHelper.SelectDecimal(CustomerCount.GET_REC_ID).ToString();
        cc.CustCnt = _outsIlecTotal1.ToString();
        cc.CustCntRecId = "108300";
        cci.Insert(cc);

        // ILEC SMART OUTS
        cc.RecId = DBHelper.SelectDecimal(CustomerCount.GET_REC_ID).ToString();
        cc.CustCnt = _outsIlecTotal2.ToString();
        cc.CustCntRecId = "108400";
        cci.Insert(cc);

        // ILEC SMART NET - 108100 - 108300
        cc.RecId = DBHelper.SelectDecimal(CustomerCount.GET_REC_ID).ToString();
        _decTotal1 = _addsIlecTotal1 - _outsIlecTotal1;
        cc.CustCnt = _decTotal1.ToString();
        cc.CustCntRecId = "108500";
        cci.Insert(cc);

        // ILEC SECURITY NET - 108200 - 108400
        cc.RecId = DBHelper.SelectDecimal(CustomerCount.GET_REC_ID).ToString();
        _decTotal2 = _addsIlecTotal2 - _outsIlecTotal2;
        cc.CustCnt = _decTotal2.ToString();
        cc.CustCntRecId = "108600";
        cci.Insert(cc);

        // ILEC TOTAL NET - 108500 + 108600
        cc.RecId = DBHelper.SelectDecimal(CustomerCount.GET_REC_ID).ToString();
        _decTotal3 = _decTotal1 + _decTotal2;
        cc.CustCnt = _decTotal3.ToString();
        cc.CustCntRecId = "108700";
        cci.Insert(cc);

        // CLEC SMART ADDS
        cc.RecId = DBHelper.SelectDecimal(CustomerCount.GET_REC_ID).ToString();
        cc.CustCnt = _addsClecTotal1.ToString();
        cc.CustCntRecId = "108800";
        cci.Insert(cc);

        // CLEC SECURITY ADDS
        cc.RecId = DBHelper.SelectDecimal(CustomerCount.GET_REC_ID).ToString();
        cc.CustCnt = _addsClecTotal2.ToString();
        cc.CustCntRecId = "108900";
        cci.Insert(cc);

        // CLEC SMART OUTS
        cc.RecId = DBHelper.SelectDecimal(CustomerCount.GET_REC_ID).ToString();
        cc.CustCnt = _outsClecTotal1.ToString();
        cc.CustCntRecId = "109000";
        cci.Insert(cc);

        // CLEC SMART OUTS
        cc.RecId = DBHelper.SelectDecimal(CustomerCount.GET_REC_ID).ToString();
        cc.CustCnt = _outsClecTotal2.ToString();
        cc.CustCntRecId = "109100";
        cci.Insert(cc);

        // CLEC SMART NET - 108800 - 109000
        cc.RecId = DBHelper.SelectDecimal(CustomerCount.GET_REC_ID).ToString();
        _decTotal4 = _addsClecTotal1 - _outsClecTotal1;
        cc.CustCnt = _decTotal4.ToString();
        cc.CustCntRecId = "109200";
        cci.Insert(cc);

        // CLEC SECURITY NET - 108900 - 109100
        cc.RecId = DBHelper.SelectDecimal(CustomerCount.GET_REC_ID).ToString();
        _decTotal5 = _addsClecTotal2 - _outsClecTotal2;
        cc.CustCnt = _decTotal5.ToString();
        cc.CustCntRecId = "109300";
        cci.Insert(cc);

        // CLEC TOTAL NET - 109200 + 109300
        cc.RecId = DBHelper.SelectDecimal(CustomerCount.GET_REC_ID).ToString();
        _decTotal6 = _decTotal4 + _decTotal5;
        cc.CustCnt = _decTotal6.ToString();
        cc.CustCntRecId = "109400";
        cci.Insert(cc);

        // SMART TOTAL - 108500 + 109200
        cc.RecId = DBHelper.SelectDecimal(CustomerCount.GET_REC_ID).ToString();
        _decTotal4 = _decTotal1 + _decTotal4;
        cc.CustCnt = _decTotal4.ToString();
        cc.CustCntRecId = "109500";
        cci.Insert(cc);

        // SECURITY TOTAL - 108600 + 109300
        cc.RecId = DBHelper.SelectDecimal(CustomerCount.GET_REC_ID).ToString();
        _decTotal5 = _decTotal2 + _decTotal5;
        cc.CustCnt = _decTotal5.ToString();
        cc.CustCntRecId = "109600";
        cci.Insert(cc);

        // OVERALL TOTAL - 108700 + 109400
        cc.RecId = DBHelper.SelectDecimal(CustomerCount.GET_REC_ID).ToString();
        _decTotal6 = _decTotal3 + _decTotal6;
        cc.CustCnt = _decTotal6.ToString();
        cc.CustCntRecId = "109700";
        cci.Insert(cc);

        sql = "SELECT DEALER_REPORT, SUM(CNT_ADDS) CNT_ADDS, SUM(CNT_OUTS) CNT_OUTS FROM BREAKDOWN_VW BA, DEALER_INFO DI WHERE BA.DEALER = DI.DEALER AND DEALER_REPORT != 'NON MON' GROUP BY DEALER_REPORT ORDER BY DEALER_REPORT";
        DataTable dtAddsOutsTotal = DBHelper.SelectDataTable(sql);

        for (int i = 0; i < dtAddsOutsTotal.Rows.Count; i++)
        {
            cc.RecId = DBHelper.SelectDecimal(CustomerCount.GET_REC_ID).ToString();
            cc.CustCnt = dtAddsOutsTotal.Rows[i][1].ToString();
            string Outs = dtAddsOutsTotal.Rows[i][2].ToString();
            string RecId = "";

            switch (dtAddsOutsTotal.Rows[i][0].ToString())
            {
                case "CLEC SMART":
                    cc.CustCntRecId = "106200";
                    RecId = "106400";
                    _addsClecTotal1 = Convert.ToDecimal(cc.CustCnt);
                    _outsClecTotal1 = Convert.ToDecimal(Outs);
                    break;
                case "CLEC SEC":
                    cc.CustCntRecId = "106300";
                    RecId = "106500";
                    _addsClecTotal2 = Convert.ToDecimal(cc.CustCnt);
                    _outsClecTotal2 = Convert.ToDecimal(Outs);
                    break;
                case "ILEC SMART":
                    cc.CustCntRecId = "106600";
                    RecId = "106800";
                    _addsIlecTotal1 = Convert.ToDecimal(cc.CustCnt);
                    _outsIlecTotal1 = Convert.ToDecimal(Outs);
                    break;
                case "ILEC SEC":
                    cc.CustCntRecId = "106700";
                    RecId = "106900";
                    _addsIlecTotal2 = Convert.ToDecimal(cc.CustCnt);
                    _outsIlecTotal2 = Convert.ToDecimal(Outs);
                    break;
                case "WHOLESALE":
                    cc.CustCntRecId = "107000";
                    RecId = "107100";
                    _addsClecTotal3 = Convert.ToDecimal(cc.CustCnt);
                    _outsClecTotal3 = Convert.ToDecimal(Outs);
                    break;

            }
            cci.Insert(cc);
            cc.RecId = DBHelper.SelectDecimal(CustomerCount.GET_REC_ID).ToString();
            cc.CustCntRecId = RecId;
            cc.CustCnt = Outs;
            cci.Insert(cc);
        }

        // TOTAL SMART ADDS - 106200 + 106600
        cc.RecId = DBHelper.SelectDecimal(CustomerCount.GET_REC_ID).ToString();
        _decTotal1 = _addsClecTotal1 + _addsIlecTotal1;
        cc.CustCnt = _decTotal1.ToString();
        cc.CustCntRecId = "107200";
        cci.Insert(cc);

        // TOTAL SMART OUTS - 106400 + 106800
        cc.RecId = DBHelper.SelectDecimal(CustomerCount.GET_REC_ID).ToString();
        _decTotal1 = _outsClecTotal1 + _outsIlecTotal1;
        cc.CustCnt = _decTotal1.ToString();
        cc.CustCntRecId = "107300";
        cci.Insert(cc);

        // TOTAL SECURITY ADDS - 106300 + 106700 + 107000
        cc.RecId = DBHelper.SelectDecimal(CustomerCount.GET_REC_ID).ToString();
        _decTotal1 = _addsClecTotal2 + _addsIlecTotal2 + _addsClecTotal3;
        cc.CustCnt = _decTotal1.ToString();
        cc.CustCntRecId = "107400";
        cci.Insert(cc);

        // TOTAL SECURITY OUTS - 106500 + 106900 + 107100
        cc.RecId = DBHelper.SelectDecimal(CustomerCount.GET_REC_ID).ToString();
        _decTotal1 = _outsClecTotal2 + _outsIlecTotal2 + _outsClecTotal3;
        cc.CustCnt = _decTotal1.ToString();
        cc.CustCntRecId = "107500";
        cci.Insert(cc);

        // TOTAL CLEC ADDS - 106200 + 106300 + 107000
        cc.RecId = DBHelper.SelectDecimal(CustomerCount.GET_REC_ID).ToString();
        _decTotal1 = _addsClecTotal1 + _addsClecTotal2 + _addsClecTotal3;
        cc.CustCnt = _decTotal1.ToString();
        cc.CustCntRecId = "107600";
        cci.Insert(cc);

        // TOTAL ILEC ADDS - 106600 + 106700
        cc.RecId = DBHelper.SelectDecimal(CustomerCount.GET_REC_ID).ToString();
        _decTotal1 = _addsIlecTotal1 + _addsIlecTotal2;
        cc.CustCnt = _decTotal1.ToString();
        cc.CustCntRecId = "107700";
        cci.Insert(cc);

        // TOTAL CLEC OUTS - 106400 + 106500 + 107100
        cc.RecId = DBHelper.SelectDecimal(CustomerCount.GET_REC_ID).ToString();
        _decTotal1 = _outsClecTotal1 + _outsClecTotal2 + _outsClecTotal3;
        cc.CustCnt = _decTotal1.ToString();
        cc.CustCntRecId = "107800";
        cci.Insert(cc);

        // TOTAL ILEC OUTS - 106800 + 106900
        cc.RecId = DBHelper.SelectDecimal(CustomerCount.GET_REC_ID).ToString();
        _decTotal1 = _outsIlecTotal1 + _outsIlecTotal2;
        cc.CustCnt = _decTotal1.ToString();
        cc.CustCntRecId = "107900";
        cci.Insert(cc);
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