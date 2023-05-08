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

public partial class Reports_DealerAmounts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void ddlType_Click(object sender, EventArgs e)
    {
        this.GridView1.Columns[2].Visible = true;
        this.GridView1.Columns[3].Visible = true;
        if (ddlType.SelectedValue == "NON MON" || ddlType.SelectedValue == "OTHER")
        {
            this.GridView1.Columns[2].Visible = false;
            this.GridView1.Columns[3].Visible = false;
        }

        GridView1.DataBind();
    }

    protected void ddlAddAll(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;
        //ddl.Items.Insert(0, new ListItem("All", "%"));
    }

    protected void btnView_Click(object sender, EventArgs e)
    {
        LinkButton btn = sender as LinkButton;
        GridViewRow row = btn.NamingContainer as GridViewRow;
        string id = GridView1.DataKeys[row.RowIndex].Value.ToString();
    }
    protected void btnCreate_Click(object sender, EventArgs e)
    {
        DataView dv = (DataView)dsOutsDetailExportAll.Select(DataSourceSelectArguments.Empty);
        DataTable dt = (DataTable)dv.ToTable();

        if (ddlType.SelectedValue == "NON MON" || ddlType.SelectedValue == "OTHER")
        {
            dt.Columns.Remove("RATE_OUTS");
            dt.Columns.Remove("RATE_ADDS");
        }

        Excel.ExportToExcel(dt, ddlType.Text + " Dealer Outs Adds Amounts");
    }
}