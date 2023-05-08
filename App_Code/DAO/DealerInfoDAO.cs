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
    public class DealerInfoDAO {

        public DealerInfoDAO() {

        }

        public DealerInfo Select(string p) {
            DealerInfo q = new DealerInfo();
            DataTable dt = DBHelper.SelectDataTable(DealerInfo.SELECT_DEALER_INFO, DBHelper.mp("DEALER_ID", p));
            for (int i = 0; i < dt.Rows.Count; i++) {
                q.DealerId = (((DataRow)(dt.Rows[i]))["DEALER_ID"]).ToString();
                q.Dealer = (((DataRow)(dt.Rows[i]))["DEALER"]).ToString();
                q.DealerReport = (((DataRow)(dt.Rows[i]))["DEALER_REPORT"]).ToString();
            }
            return q;
        }

        public void Insert(DealerInfo p) {
            OracleParameter[] paramsList = createParamList(p);
            DBHelper.Execute(DealerInfo.INSERT_DEALER_INFO, paramsList);
        }

        public void Update(DealerInfo p) {
            OracleParameter[] paramsList = createParamList(p);
            DBHelper.Execute(DealerInfo.UPDATE_DEALER_INFO, paramsList);
        }

        public void Delete(string p) {
            DBHelper.Execute(DealerInfo.DELETE_DEALER_INFO, DBHelper.mp("DEALER_ID", p));
        }

        private OracleParameter[] createParamList(DealerInfo p) {
            int cntr = 0;

            OracleParameter[] paramsList = new OracleParameter[3];
            paramsList[cntr++] = DBHelper.mp("DEALER_ID", p.DealerId);
            paramsList[cntr++] = DBHelper.mp("DEALER", p.Dealer);
            paramsList[cntr++] = DBHelper.mp("DEALER_REPORT", p.DealerReport);
            return paramsList;
        }
     }
}
