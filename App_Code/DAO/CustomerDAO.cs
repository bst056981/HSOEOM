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
                q.EndDate = (((DataRow)(dt.Rows[i]))["END_DATE"]).ToString();
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

            OracleParameter[] paramsList = new OracleParameter[6];
            paramsList[cntr++] = DBHelper.mp("CUST_ID", p.CustId);
            paramsList[cntr++] = DBHelper.mp("DICE", p.Dice);
            paramsList[cntr++] = DBHelper.mp("NAME", p.Name);
            paramsList[cntr++] = DBHelper.mp("DEALER", p.Dealer);
            paramsList[cntr++] = DBHelper.mp("START_DATE", p.StartDate);
            paramsList[cntr++] = DBHelper.mp("END_DATE", p.EndDate);
            return paramsList;
        }
     }
}
