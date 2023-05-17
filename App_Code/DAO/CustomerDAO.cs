using System;
using System.Web;
using System.Data;
using Oracle.DataAccess.Client;
using Agile.Domain;
using Agile.DAO;
using Agile.Helper;
using Agile.Services.Impl;
using Agile.Services.Interface;
using System.Collections;

namespace Agile.DAO {
    public class CustomerDAO {

        public CustomerDAO() {

        }

        public Customer Select(string p) {
            Customer q = new Customer();
            DataTable dt = DBHelper.SelectDataTable(Customer.SELECT_CUSTOMER, DBHelper.mp("CUST_ID", p));
            for (int i = 0; i < dt.Rows.Count; i++) {
                q.CustId = (((DataRow)(dt.Rows[i]))["CUST_ID"]).ToString();
                q.Dice = (((DataRow)(dt.Rows[i]))["DICE"]).ToString();
                q.Name = (((DataRow)(dt.Rows[i]))["NAME"]).ToString();
                q.Dealer = (((DataRow)(dt.Rows[i]))["DEALER"]).ToString();
                q.StartDate = (((DataRow)(dt.Rows[i]))["START_DATE"]).ToString();
                q.InactiveDate = (((DataRow)(dt.Rows[i]))["INACTIVE_DATE"]).ToString();
                q.EnteredDate = (((DataRow)(dt.Rows[i]))["ENTERED_DATE"]).ToString();
                q.EnteredId = (((DataRow)(dt.Rows[i]))["ENTERED_ID"]).ToString();
                q.Type = (((DataRow)(dt.Rows[i]))["TYPE"]).ToString();
                q.Panel = (((DataRow)(dt.Rows[i]))["PANEL"]).ToString();
                q.Cycle = (((DataRow)(dt.Rows[i]))["CYCLE"]).ToString();
                q.Branch = (((DataRow)(dt.Rows[i]))["BRANCH"]).ToString();
                q.Amount = (((DataRow)(dt.Rows[i]))["AMOUNT"]).ToString();
                q.Rep = (((DataRow)(dt.Rows[i]))["REP"]).ToString();
                q.Service = (((DataRow)(dt.Rows[i]))["SERVICE"]).ToString();
                q.Tech = (((DataRow)(dt.Rows[i]))["TECH"]).ToString();
                q.Ban = (((DataRow)(dt.Rows[i]))["BAN"]).ToString();
                q.Rate = (((DataRow)(dt.Rows[i]))["RATE"]).ToString();
                q.Reason = (((DataRow)(dt.Rows[i]))["REASON"]).ToString();
            }
            return q;
        }

        public void Insert(Customer p) {
            OracleParameter[] paramsList = createParamList(p);
            DBHelper.Execute(Customer.INSERT_CUSTOMER, paramsList);
        }

        public void Update(Customer p) {
            OracleParameter[] paramsList = createParamList(p);
            DBHelper.Execute(Customer.UPDATE_CUSTOMER, paramsList);
        }

        public void Delete(string p) {
            DBHelper.Execute(Customer.DELETE_CUSTOMER, DBHelper.mp("CUST_ID", p));
        }

        private OracleParameter[] createParamList(Customer p) {
            int cntr = 0;

            OracleParameter[] paramsList = new OracleParameter[19];
            paramsList[cntr++] = DBHelper.mp("CUST_ID", p.CustId);
            paramsList[cntr++] = DBHelper.mp("DICE", p.Dice);
            paramsList[cntr++] = DBHelper.mp("NAME", p.Name);
            paramsList[cntr++] = DBHelper.mp("DEALER", p.Dealer);
            paramsList[cntr++] = DBHelper.mp("START_DATE", p.StartDate);
            paramsList[cntr++] = DBHelper.mp("INACTIVE_DATE", p.InactiveDate);
            paramsList[cntr++] = DBHelper.mp("ENTERED_DATE", p.EnteredDate);
            paramsList[cntr++] = DBHelper.mp("ENTERED_ID", p.EnteredId);
            paramsList[cntr++] = DBHelper.mp("TYPE", p.Type);
            paramsList[cntr++] = DBHelper.mp("PANEL", p.Panel);
            paramsList[cntr++] = DBHelper.mp("CYCLE", p.Cycle);
            paramsList[cntr++] = DBHelper.mp("BRANCH", p.Branch);
            paramsList[cntr++] = DBHelper.mp("AMOUNT", p.Amount);
            paramsList[cntr++] = DBHelper.mp("REP", p.Rep);
            paramsList[cntr++] = DBHelper.mp("SERVICE", p.Service);
            paramsList[cntr++] = DBHelper.mp("TECH", p.Tech);
            paramsList[cntr++] = DBHelper.mp("BAN", p.Ban);
            paramsList[cntr++] = DBHelper.mp("RATE", p.Rate);
            paramsList[cntr++] = DBHelper.mp("REASON", p.Reason);
            return paramsList;
        }
     }
}
