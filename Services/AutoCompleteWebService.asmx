<%@ WebService Language="C#" Class="AutoCompleteWebService" %>

using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Collections.Generic;
using Oracle.DataAccess.Client;
using System.Configuration;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]
public class AutoCompleteWebService  : System.Web.Services.WebService {
    [WebMethod]
    public bool Ping()
    {
        return true;
    }

    private string [] GetSuggestions(string strSQL, int count) 
    {
        List<string> temp = new List<string>();
        OracleConnection conn;
        OracleCommand cmnd;
        OracleDataAdapter adr;
        DataSet  ds;
        
        
        try
        {
            conn = new OracleConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            adr = new OracleDataAdapter();
            //cmnd = new OracleCommand("SELECT DISTINCT CLLICODE FROM GENERAL " + filter + " ORDER BY " + "CLLICODE", conn);
                        
            cmnd = new OracleCommand(strSQL, conn);
            adr.SelectCommand = cmnd;
            ds = new DataSet();
            adr.Fill(ds);
            for (int i=0; i<ds.Tables[0].Rows.Count; i++)
            {
                temp.Add(ds.Tables[0].Rows[i][0].ToString());
            }
            if (temp.Count == 0)
            {
                temp.Add("-- No Matches Found --");
            }
        }
        catch (Exception e)
        {
            string msg = e.Message;
        }
        return temp.ToArray();
    }
    
    
    [WebMethod]
    public string[] GetSuggestionsCentrex(string prefixText, int count)
    {
        //string str = " WHERE UPPER(CLLICODE) LIKE '" + prefixText.ToUpper() + "%'";
        string strSQL = "SELECT DISTINCT Project FROM tblCentrexPro WHERE UPPER(Project) LIKE '" + prefixText.ToUpper() + "%'  ORDER BY Project" ;
        return GetSuggestions(strSQL, count);
    }

    [WebMethod]
    public string[] GetSuggestionsEng(string prefixText, int count)
    {
        //string str = " WHERE UPPER(CLLICODE) LIKE '" + prefixText.ToUpper() + "%'";
        string strSQL = "SELECT DISTINCT ProjectName FROM tblEngSpecPro WHERE UPPER(ProjectName) LIKE '" + prefixText.ToUpper() + "%'  ORDER BY ProjectName";
        return GetSuggestions(strSQL, count);
    }
}

