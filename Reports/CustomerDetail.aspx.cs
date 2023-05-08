using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Agile.Domain;
using Agile.DAO;
using Agile.Services.Impl;
using Agile.Services.Interface;
using Agile.Helper;
using System.Data;
using System.Drawing;

public partial class Reports_CustomerDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string startDate = "01/01/0001";
        string endDate = "12/31/9999";
        if (!String.IsNullOrEmpty(txtStartDate.Text))
            startDate = txtStartDate.Text;
        if (!String.IsNullOrEmpty(txtEndDate.Text))
            endDate = txtEndDate.Text;


        this.GridView1.Columns[4].Visible = false;
        if (ddlStatus.SelectedValue == "Inactive")
            this.GridView1.Columns[4].Visible = true;
    }
    protected void ddlStatus_Click(object sender, EventArgs e)
    {
        GridView1.DataBind();
    }
    protected void ddlDealer_Click(object sender, EventArgs e)
    {
        GridView1.DataBind();
    }
    protected void ddlAddAll(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;
        ddl.Items.Insert(0, new ListItem("All", "%"));
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        GridView1.DataBind();
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        LinkButton btn = sender as LinkButton;
        GridViewRow row = btn.NamingContainer as GridViewRow;
        string id = GridView1.DataKeys[row.RowIndex].Value.ToString();
    }
    protected void btnCreate_Click(object sender, EventArgs e)
    {
        DataView dv = (DataView)dsCustomerExportAll.Select(DataSourceSelectArguments.Empty);
        DataTable dt = (DataTable)dv.ToTable();
        if (ddlStatus.SelectedValue == "Active")
            dt.Columns.Remove("END_DATE"); ;

        Excel.ExportToExcel(dt, ddlStatus.Text + " Customer Detail Report");
    }
}