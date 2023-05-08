using Agile.Helper;
using Agile.Services.Interface;
using Agile.Services.Impl;
using Agile.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Web.Security;
using System.Net;
using System.Data;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LITsiteName.Text = (WebConfigurationManager.AppSettings["environmentLabel"]) + (WebConfigurationManager.AppSettings["siteName"]);
            lblSiteName.Text = (WebConfigurationManager.AppSettings["environmentLabel"]) + (WebConfigurationManager.AppSettings["siteName"]);

            lblUserInfo.Text = String.Empty;

            LOGO.Attributes.Add("title", Dns.GetHostName());
        }
        //****************************************************************//
        //********** COMMENT IF YOU DO NOT WANT A PING SERVICE ***********//
        //****************************************************************//
        ScriptManager sm = ScriptManager.GetCurrent(Page);
        if (sm.AsyncPostBackSourceElementID.Equals(""))
        {
            string script = "enablePing();";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "myPingTimer", script, true);
        }
        //****************************************************************//
        //*********************** END PING SERVICE ***********************//
        //****************************************************************//
    }

    protected void Logout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        FormsAuthentication.SignOut();
        Response.Redirect("~/Secure/Login.aspx?ReturnUrl=" + Request.Url.PathAndQuery.ToString());
    }

    protected void Login_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Secure/Login.aspx?ReturnUrl=" + Request.Url.PathAndQuery.ToString());
    }
}