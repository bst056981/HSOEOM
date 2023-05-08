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
    public class CustomerCountDAO {

        public CustomerCountDAO() {

        }

        public CustomerCount Select(string p) {
            CustomerCount q = new CustomerCount();
            DataTable dt = DBHelper.SelectDataTable(CustomerCount.SELECT_CUSTOMER_COUNT, DBHelper.mp("REC_ID", p));
            for (int i = 0; i < dt.Rows.Count; i++) {
                q.RecId = (((DataRow)(dt.Rows[i]))["REC_ID"]).ToString();
                q.CustCntRecId = (((DataRow)(dt.Rows[i]))["CUST_CNT_REC_ID"]).ToString();
                q.CustCntDate = (((DataRow)(dt.Rows[i]))["CUST_CNT_DATE"]).ToString();
                q.CustCnt = (((DataRow)(dt.Rows[i]))["CUST_CNT"]).ToString();
            }
            return q;
        }

        public void Insert(CustomerCount p) {
            OracleParameter[] paramsList = createParamList(p);
            DBHelper.Execute(CustomerCount.INSERT_CUSTOMER_COUNT, paramsList);
        }

        public void Update(CustomerCount p) {
            OracleParameter[] paramsList = createParamList(p);
            DBHelper.Execute(CustomerCount.UPDATE_CUSTOMER_COUNT, paramsList);
        }

        public void Delete(string p) {
            DBHelper.Execute(CustomerCount.DELETE_CUSTOMER_COUNT, DBHelper.mp("REC_ID", p));
        }

        private OracleParameter[] createParamList(CustomerCount p) {
            int cntr = 0;

            OracleParameter[] paramsList = new OracleParameter[4];
            paramsList[cntr++] = DBHelper.mp("REC_ID", p.RecId);
            paramsList[cntr++] = DBHelper.mp("CUST_CNT_REC_ID", p.CustCntRecId);
            paramsList[cntr++] = DBHelper.mp("CUST_CNT_DATE", p.CustCntDate);
            paramsList[cntr++] = DBHelper.mp("CUST_CNT", p.CustCnt);
            return paramsList;
        }
     }
}
