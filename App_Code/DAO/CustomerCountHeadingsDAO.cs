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
    public class CustomerCountHeadingsDAO {

        public CustomerCountHeadingsDAO() {

        }

        public CustomerCountHeadings Select(string p) {
            CustomerCountHeadings q = new CustomerCountHeadings();
            DataTable dt = DBHelper.SelectDataTable(CustomerCountHeadings.SELECT_CUSTOMER_COUNT_HEADINGS, DBHelper.mp("CUST_CNT_HDR_REC_ID", p));
            for (int i = 0; i < dt.Rows.Count; i++) {
                q.CustCntHdrRecId = (((DataRow)(dt.Rows[i]))["CUST_CNT_HDR_REC_ID"]).ToString();
                q.Heading1 = (((DataRow)(dt.Rows[i]))["HEADING1"]).ToString();
                q.Heading2 = (((DataRow)(dt.Rows[i]))["HEADING2"]).ToString();
            }
            return q;
        }

        public void Insert(CustomerCountHeadings p) {
            OracleParameter[] paramsList = createParamList(p);
            DBHelper.Execute(CustomerCountHeadings.INSERT_CUSTOMER_COUNT_HEADINGS, paramsList);
        }

        public void Update(CustomerCountHeadings p) {
            OracleParameter[] paramsList = createParamList(p);
            DBHelper.Execute(CustomerCountHeadings.UPDATE_CUSTOMER_COUNT_HEADINGS, paramsList);
        }

        public void Delete(string p) {
            DBHelper.Execute(CustomerCountHeadings.DELETE_CUSTOMER_COUNT_HEADINGS, DBHelper.mp("CUST_CNT_HDR_REC_ID", p));
        }

        private OracleParameter[] createParamList(CustomerCountHeadings p) {
            int cntr = 0;

            OracleParameter[] paramsList = new OracleParameter[3];
            paramsList[cntr++] = DBHelper.mp("CUST_CNT_HDR_REC_ID", p.CustCntHdrRecId);
            paramsList[cntr++] = DBHelper.mp("HEADING1", p.Heading1);
            paramsList[cntr++] = DBHelper.mp("HEADING2", p.Heading2);
            return paramsList;
        }
     }
}
