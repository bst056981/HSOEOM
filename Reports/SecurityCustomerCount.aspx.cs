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

public partial class Reports_SecurityCustomerCount : System.Web.UI.Page
{
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
            DateTime d_1 = d_0.AddMonths(-1);
            DateTime d_2 = d_0.AddMonths(-2);
            DateTime d_3 = d_0.AddMonths(-3);
            DateTime d_4 = d_0.AddMonths(-4);
            DateTime d_5 = d_0.AddMonths(-5);
            DateTime d_6 = d_0.AddMonths(-6);
            DateTime d_7 = d_0.AddMonths(-7);
            DateTime d_8 = d_0.AddMonths(-8);
            DateTime d_9 = d_0.AddMonths(-9);
            DateTime d_10 = d_0.AddMonths(-10);
            DateTime d_11 = d_0.AddMonths(-11);
            DateTime d_12 = d_0.AddMonths(-12);

            GridView.Columns[3].HeaderText = d_12.ToShortDateString();
            GridView.Columns[4].HeaderText = d_11.ToShortDateString();
            GridView.Columns[5].HeaderText = d_10.ToShortDateString();
            GridView.Columns[6].HeaderText = d_9.ToShortDateString();
            GridView.Columns[7].HeaderText = d_8.ToShortDateString();
            GridView.Columns[8].HeaderText = d_7.ToShortDateString();
            GridView.Columns[9].HeaderText = d_6.ToShortDateString();
            GridView.Columns[10].HeaderText = d_5.ToShortDateString();
            GridView.Columns[11].HeaderText = d_4.ToShortDateString();
            GridView.Columns[12].HeaderText = d_3.ToShortDateString();
            GridView.Columns[13].HeaderText = d_2.ToShortDateString();
            GridView.Columns[14].HeaderText = d_1.ToShortDateString();
            GridView.Columns[15].HeaderText = d_0.ToShortDateString();
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

                DateTime d_0 = DateTime.Parse(ddlDate.SelectedValue);
                DateTime d_1 = d_0.AddMonths(-1);
                DateTime d_2 = d_0.AddMonths(-2);
                DateTime d_3 = d_0.AddMonths(-3);
                DateTime d_4 = d_0.AddMonths(-4);
                DateTime d_5 = d_0.AddMonths(-5);
                DateTime d_6 = d_0.AddMonths(-6);
                DateTime d_7 = d_0.AddMonths(-7);
                DateTime d_8 = d_0.AddMonths(-8);
                DateTime d_9 = d_0.AddMonths(-9);
                DateTime d_10 = d_0.AddMonths(-10);
                DateTime d_11 = d_0.AddMonths(-11);
                DateTime d_12 = d_0.AddMonths(-12);

                e.Row.Cells[3].Text = d_12.ToShortDateString();
                e.Row.Cells[4].Text = d_11.ToShortDateString();
                e.Row.Cells[5].Text = d_10.ToShortDateString();
                e.Row.Cells[6].Text = d_9.ToShortDateString();
                e.Row.Cells[7].Text = d_8.ToShortDateString();
                e.Row.Cells[8].Text = d_7.ToShortDateString();
                e.Row.Cells[9].Text = d_6.ToShortDateString();
                e.Row.Cells[10].Text = d_5.ToShortDateString();
                e.Row.Cells[11].Text = d_4.ToShortDateString();
                e.Row.Cells[12].Text = d_3.ToShortDateString();
                e.Row.Cells[13].Text = d_2.ToShortDateString();
                e.Row.Cells[14].Text = d_1.ToShortDateString();
                e.Row.Cells[15].Text = d_0.ToShortDateString();
                e.Row.Cells[16].Text = "Diff";
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

        DateTime d_0 = DateTime.Parse(ddlDate.SelectedValue);
        DateTime d_1 = d_0.AddMonths(-1);
        DateTime d_2 = d_0.AddMonths(-2);
        DateTime d_3 = d_0.AddMonths(-3);
        DateTime d_4 = d_0.AddMonths(-4);
        DateTime d_5 = d_0.AddMonths(-5);
        DateTime d_6 = d_0.AddMonths(-6);
        DateTime d_7 = d_0.AddMonths(-7);
        DateTime d_8 = d_0.AddMonths(-8);
        DateTime d_9 = d_0.AddMonths(-9);
        DateTime d_10 = d_0.AddMonths(-10);
        DateTime d_11 = d_0.AddMonths(-11);
        DateTime d_12 = d_0.AddMonths(-12);

        dt.Columns["HEADING1"].ColumnName = "DEALER";
        dt.Columns["HEADING2"].ColumnName = "CLEC ACCOUNTS";
        dt.Columns["CNT12"].ColumnName = d_12.ToShortDateString();
        dt.Columns["CNT11"].ColumnName = d_11.ToShortDateString();
        dt.Columns["CNT10"].ColumnName = d_10.ToShortDateString();
        dt.Columns["CNT9"].ColumnName = d_9.ToShortDateString();
        dt.Columns["CNT8"].ColumnName = d_8.ToShortDateString();
        dt.Columns["CNT7"].ColumnName = d_7.ToShortDateString();
        dt.Columns["CNT6"].ColumnName = d_6.ToShortDateString();
        dt.Columns["CNT5"].ColumnName = d_5.ToShortDateString();
        dt.Columns["CNT4"].ColumnName = d_4.ToShortDateString();
        dt.Columns["CNT3"].ColumnName = d_3.ToShortDateString();
        dt.Columns["CNT2"].ColumnName = d_2.ToShortDateString();
        dt.Columns["CNT1"].ColumnName = d_1.ToShortDateString();
        dt.Columns["CNT0"].ColumnName = d_0.ToShortDateString();

        Excel.ExportToExcelCenter(dt, "Security Customer Count Report");
    }
}