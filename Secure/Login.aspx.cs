using System;
using System.Data;
using System.Web;
using System.Text.RegularExpressions;
using System.Web.Security;
using System.Web.Configuration;
using Agile.Helper;
using Agile.Services.Interface;
using Agile.Services.Impl;
using Agile.Domain;

public partial class Secure_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.txtUserName.Focus();
        mv1.SetActiveView(vNotLoggedIn);
    }

    protected void cmdLogin_Click(object sender, EventArgs e)
    {
        if (txtUserName.Text.Trim() != "" && txtPassword.Text.Trim() != "")
        {
            string userId = txtUserName.Text.Trim();


            string sql = "select * from users where user_id = '" + userId + "'";
            DataTable dt = signOnDBHelper.SelectDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                if (txtPassword.Text != (((DataRow)(dt.Rows[0]))["PASSWORD"]).ToString())
                {
                    lblResponse.Text = "Invalid password";
                    this.txtPassword.Focus();
                }
                else
                {
                    Session["user"] = txtUserName.Text;
                    FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, true);
                }
            }
            else
            {
                lblResponse.Text = "Invalid User id";
                this.txtPassword.Focus();
            }
        }
    }
}