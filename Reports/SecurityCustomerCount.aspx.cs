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

    //protected void ddlYear_OnTextChanged(object sender, EventArgs e)
    //{
    //    hfYear.Value = ddlYear.SelectedItem.Value;
    //}

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
        Excel.ExportToExcelCenter(dt, "Security Customer Count Report");
    }
}