using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Agile.DAO;
using Agile.Domain;
//using Agile.Services.decimalerface;
using Agile.Services.Impl;
using System.Drawing;
using Agile.Helper;
using System.Globalization;
using System.Threading;

public partial class Reports_SecurityCustomerCount : System.Web.UI.Page
{
    protected string _dollorFormat = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            //hfYear.Value = ddlYear.SelectedItem.Value;
        }
        else
        {
            //ddlYear.SelectedValue = hfYear.Value = DateTime.Now.Year.ToString();
        }
    }

    protected void ddlDate_OnTextChanged(object sender, EventArgs e)
    {
        GridView.DataBind();
    }


    protected void Gridview_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            DateTime d_0 = DateTime.Parse(ddlDate.SelectedValue);
            string sql = "SELECT DISTINCT CUST_CNT_DATE FROM CUSTOMER_COUNT WHERE to_date(CUST_CNT_DATE, 'MM/DD/YYYY') <=  to_date('" + ddlDate.SelectedValue + "', 'MM/DD/YYYY')  ORDER BY to_date(CUST_CNT_DATE, 'MM/DD/YYYY') DESC";
            DataTable dt = DBHelper.SelectDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                GridView.Columns[15 - i].HeaderText = dt.Rows[i][0].ToString();
                if (i >= 12)
                    i = 99;
            }
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TableCell statusCell = e.Row.Cells[2];

            if (statusCell.Text == "ILEC MARKET ACCOUNTS" || statusCell.Text == "WHOLESALE DEALER ACCOUNTS" || statusCell.Text == "BREAK DOWN" || statusCell.Text == "TOTALS" || statusCell.Text == "Smart/Security Break Down" || statusCell.Text == "Smart/Security Adds/Outs" || statusCell.Text == "NET RECURRING REVENUE")
            {
                e.Row.Cells[1].BackColor = Color.Orange;
                e.Row.Cells[2].BackColor = Color.Orange;
                e.Row.Cells[3].BackColor = Color.Orange;
                e.Row.Cells[4].BackColor = Color.Orange;
                e.Row.Cells[5].BackColor = Color.Orange;
                e.Row.Cells[6].BackColor = Color.Orange;
                e.Row.Cells[7].BackColor = Color.Orange;
                e.Row.Cells[8].BackColor = Color.Orange;
                e.Row.Cells[9].BackColor = Color.Orange;
                e.Row.Cells[10].BackColor = Color.Orange;
                e.Row.Cells[11].BackColor = Color.Orange;
                e.Row.Cells[12].BackColor = Color.Orange;
                e.Row.Cells[13].BackColor = Color.Orange;
                e.Row.Cells[14].BackColor = Color.Orange;
                e.Row.Cells[15].BackColor = Color.Orange;
                e.Row.Cells[16].BackColor = Color.Orange;

                string sql = "SELECT DISTINCT CUST_CNT_DATE FROM CUSTOMER_COUNT WHERE to_date(CUST_CNT_DATE, 'MM/DD/YYYY') <=  to_date('" + ddlDate.SelectedValue + "', 'MM/DD/YYYY')  ORDER BY to_date(CUST_CNT_DATE, 'MM/DD/YYYY') DESC";
                DataTable dt = DBHelper.SelectDataTable(sql);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    e.Row.Cells[15 - i].Text = dt.Rows[i][0].ToString();
                    if (i >= 12)
                        i = 99;
                }

                e.Row.Cells[16].Text = "Diff";

            }

            if (statusCell.Text == "NET RECURRING REVENUE")
                _dollorFormat = "Y";

            if (statusCell.Text == "Monroe Office")
                _dollorFormat = " ";

            CultureInfo culture = new CultureInfo("en-us");
            culture.NumberFormat.CurrencyNegativePattern = 1;

            Thread.CurrentThread.CurrentUICulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;

            if (_dollorFormat == "Y" && (statusCell.Text == "ILEC Smart Adds" || statusCell.Text == "ILEC Security Adds" || statusCell.Text == "ILEC Smart Outs" || statusCell.Text == "ILEC Security Outs" || statusCell.Text == "ILEC Smart Net" || statusCell.Text == "ILEC Security Net" || statusCell.Text == "ILEC Total Net" ||
                statusCell.Text == "CLEC Smart Adds" || statusCell.Text == "CLEC Security Adds" || statusCell.Text == "CLEC Smart Outs" || statusCell.Text == "CLEC Security Outs" || statusCell.Text == "CLEC Smart Net" || statusCell.Text == "CLEC Security Net" || statusCell.Text == "CLEC Total Net" || 
                statusCell.Text == "Smart Total" || statusCell.Text == "Security Total" || statusCell.Text == "Overall Total"))
            {
                e.Row.Cells[3].Text = String.Format("{0:C2}", Convert.ToDecimal(e.Row.Cells[3].Text));
                e.Row.Cells[4].Text = String.Format("{0:C2}", Convert.ToDecimal(e.Row.Cells[4].Text));
                e.Row.Cells[5].Text = String.Format("{0:C2}", Convert.ToDecimal(e.Row.Cells[5].Text));
                e.Row.Cells[6].Text = String.Format("{0:C2}", Convert.ToDecimal(e.Row.Cells[6].Text));
                e.Row.Cells[7].Text = String.Format("{0:C2}", Convert.ToDecimal(e.Row.Cells[7].Text));
                e.Row.Cells[8].Text = String.Format("{0:C2}", Convert.ToDecimal(e.Row.Cells[8].Text));
                e.Row.Cells[9].Text = String.Format("{0:C2}", Convert.ToDecimal(e.Row.Cells[9].Text));
                e.Row.Cells[10].Text = String.Format("{0:C2}", Convert.ToDecimal(e.Row.Cells[10].Text));
                e.Row.Cells[11].Text = String.Format("{0:C2}", Convert.ToDecimal(e.Row.Cells[11].Text));
                e.Row.Cells[12].Text = String.Format("{0:C2}", Convert.ToDecimal(e.Row.Cells[12].Text));
                e.Row.Cells[13].Text = String.Format("{0:C2}", Convert.ToDecimal(e.Row.Cells[13].Text));
                e.Row.Cells[14].Text = String.Format("{0:C2}", Convert.ToDecimal(e.Row.Cells[14].Text));
                e.Row.Cells[15].Text = String.Format("{0:C2}", Convert.ToDecimal(e.Row.Cells[15].Text));
                e.Row.Cells[16].Text = String.Format("{0:C2}", Convert.ToDecimal(e.Row.Cells[16].Text));
            }
        }
    }
    protected void OnUpdate(object sender, EventArgs e)
    {
        GridView.DataBind();
    }
    protected void btnCreate_Click(object sender, EventArgs e)
    {
        DataView dv = (DataView)dsCountExportAll.Select(DataSourceSelectArguments.Empty);
        DataTable dt = (DataTable)dv.ToTable();
        dt.Columns.Remove("REC_ID");               
        dt.Columns["HEADING1"].ColumnName = "DEALER";
        dt.Columns["HEADING2"].ColumnName = "CLEC ACCOUNTS";

        DateTime d_0 = DateTime.Parse(ddlDate.SelectedValue);
        string sql = "SELECT DISTINCT CUST_CNT_DATE FROM CUSTOMER_COUNT WHERE to_date(CUST_CNT_DATE, 'MM/DD/YYYY') <=  to_date('" + ddlDate.SelectedValue + "', 'MM/DD/YYYY')  ORDER BY to_date(CUST_CNT_DATE, 'MM/DD/YYYY') DESC";
        DataTable dt1 = DBHelper.SelectDataTable(sql);

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            dt.Columns["CNT" + i].ColumnName = dt1.Rows[i][0].ToString();
            if (i >= 12)
                i = 99;
        }

        Excel.ExportToExcelCenter(dt, "Security Customer Count Report");
    }
}