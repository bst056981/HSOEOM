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
    public class IlecOutsDAO {

        public IlecOutsDAO() {

        }

        public IlecOuts Select(string p) {
            IlecOuts q = new IlecOuts();
            DataTable dt = DBHelper.SelectDataTable(IlecOuts.SELECT_ILEC_OUTS, DBHelper.mp("ILEC_OUTS_ID", p));
            for (int i = 0; i < dt.Rows.Count; i++) {
                q.IlecOutsId = (((DataRow)(dt.Rows[i]))["ILEC_OUTS_ID"]).ToString();
                q.Dice = (((DataRow)(dt.Rows[i]))["DICE"]).ToString();
                q.Name = (((DataRow)(dt.Rows[i]))["NAME"]).ToString();
                q.Reason = (((DataRow)(dt.Rows[i]))["REASON"]).ToString();
                q.Panel = (((DataRow)(dt.Rows[i]))["PANEL"]).ToString();
                q.InactiveDate = (((DataRow)(dt.Rows[i]))["INACTIVE_DATE"]).ToString();
                q.Dealer = (((DataRow)(dt.Rows[i]))["DEALER"]).ToString();
                q.StartDate = (((DataRow)(dt.Rows[i]))["START_DATE"]).ToString();
                q.Rep = (((DataRow)(dt.Rows[i]))["REP"]).ToString();
                q.Service = (((DataRow)(dt.Rows[i]))["SERVICE"]).ToString();
                q.Ban = (((DataRow)(dt.Rows[i]))["BAN"]).ToString();
                q.Rate = (((DataRow)(dt.Rows[i]))["RATE"]).ToString();
            }
            return q;
        }

        public void Insert(IlecOuts p) {
            OracleParameter[] paramsList = createParamList(p);
            DBHelper.Execute(IlecOuts.INSERT_ILEC_OUTS, paramsList);
        }

        public void Update(IlecOuts p) {
            OracleParameter[] paramsList = createParamList(p);
            DBHelper.Execute(IlecOuts.UPDATE_ILEC_OUTS, paramsList);
        }

        public void Delete(string p) {
            DBHelper.Execute(IlecOuts.DELETE_ILEC_OUTS, DBHelper.mp("ILEC_OUTS_ID", p));
        }

        private OracleParameter[] createParamList(IlecOuts p) {
            int cntr = 0;

            OracleParameter[] paramsList = new OracleParameter[12];
            paramsList[cntr++] = DBHelper.mp("ILEC_OUTS_ID", p.IlecOutsId);
            paramsList[cntr++] = DBHelper.mp("DICE", p.Dice);
            paramsList[cntr++] = DBHelper.mp("NAME", p.Name);
            paramsList[cntr++] = DBHelper.mp("REASON", p.Reason);
            paramsList[cntr++] = DBHelper.mp("PANEL", p.Panel);
            paramsList[cntr++] = DBHelper.mp("INACTIVE_DATE", p.InactiveDate);
            paramsList[cntr++] = DBHelper.mp("DEALER", p.Dealer);
            paramsList[cntr++] = DBHelper.mp("START_DATE", p.StartDate);
            paramsList[cntr++] = DBHelper.mp("REP", p.Rep);
            paramsList[cntr++] = DBHelper.mp("SERVICE", p.Service);
            paramsList[cntr++] = DBHelper.mp("BAN", p.Ban);
            paramsList[cntr++] = DBHelper.mp("RATE", p.Rate);
            return paramsList;
        }
     }
}
