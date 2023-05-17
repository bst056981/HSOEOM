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

public partial class Reports_BreakdownOfAccounts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string sql = "SELECT DISTINCT CUST_CNT_DATE FROM CUSTOMER_COUNT ORDER BY to_date(CUST_CNT_DATE, 'MM-DD-YYYY') DESC";
        DataTable dt = DBHelper.SelectDataTable(sql);

        hfDate.Value = (((DataRow)(dt.Rows[0]))["CUST_CNT_DATE"]).ToString();
        
    }

    protected void ddlDate_OnTextChanged(object sender, EventArgs e)
    {
        GridView.DataBind();
    }

    protected void Gridview_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }
    protected void OnUpdate(object sender, EventArgs e)
    {
        GridView.DataBind();
    }
    protected void btnCreate_Click(object sender, EventArgs e)
    {
        DataView dv = (DataView)dsCountExportAll.Select(DataSourceSelectArguments.Empty);
        DataTable dt = (DataTable)dv.ToTable();     
        
        Excel.ExportToExcelCenter(dt, "Breakdown of Accounts Report");
    }
}