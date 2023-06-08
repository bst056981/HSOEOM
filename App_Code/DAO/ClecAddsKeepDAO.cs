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
    public class ClecAddsKeepDAO {

        public ClecAddsKeepDAO() {

        }

        public ClecAddsKeep Select(string p) {
            ClecAddsKeep q = new ClecAddsKeep();
            DataTable dt = DBHelper.SelectDataTable(ClecAddsKeep.SELECT_CLEC_ADDS_KEEP, DBHelper.mp("CLEC_ADDS_ID", p));
            for (int i = 0; i < dt.Rows.Count; i++) {
                q.ClecAddsId = (((DataRow)(dt.Rows[i]))["CLEC_ADDS_ID"]).ToString();
                q.Dice = (((DataRow)(dt.Rows[i]))["DICE"]).ToString();
                q.Name = (((DataRow)(dt.Rows[i]))["NAME"]).ToString();
                q.Type = (((DataRow)(dt.Rows[i]))["TYPE"]).ToString();
                q.Panel = (((DataRow)(dt.Rows[i]))["PANEL"]).ToString();
                q.Dealer = (((DataRow)(dt.Rows[i]))["DEALER"]).ToString();
                q.StartDate = (((DataRow)(dt.Rows[i]))["START_DATE"]).ToString();
                q.Cycle = (((DataRow)(dt.Rows[i]))["CYCLE"]).ToString();
                q.Branch = (((DataRow)(dt.Rows[i]))["BRANCH"]).ToString();
                q.Amount = (((DataRow)(dt.Rows[i]))["AMOUNT"]).ToString();
                q.Rep = (((DataRow)(dt.Rows[i]))["REP"]).ToString();
                q.Service = (((DataRow)(dt.Rows[i]))["SERVICE"]).ToString();
                q.Tech = (((DataRow)(dt.Rows[i]))["TECH"]).ToString();
                q.Ban = (((DataRow)(dt.Rows[i]))["BAN"]).ToString();
                q.Rate = (((DataRow)(dt.Rows[i]))["RATE"]).ToString();
                q.EnteredDate = (((DataRow)(dt.Rows[i]))["ENTERED_DATE"]).ToString();
                q.EnteredId = (((DataRow)(dt.Rows[i]))["ENTERED_ID"]).ToString();
            }
            return q;
        }

        public void Insert(ClecAddsKeep p) {
            OracleParameter[] paramsList = createParamList(p);
            DBHelper.Execute(ClecAddsKeep.INSERT_CLEC_ADDS_KEEP, paramsList);
        }

        public void Update(ClecAddsKeep p) {
            OracleParameter[] paramsList = createParamList(p);
            DBHelper.Execute(ClecAddsKeep.UPDATE_CLEC_ADDS_KEEP, paramsList);
        }

        public void Delete(string p) {
            DBHelper.Execute(ClecAddsKeep.DELETE_CLEC_ADDS_KEEP, DBHelper.mp("CLEC_ADDS_ID", p));
        }

        private OracleParameter[] createParamList(ClecAddsKeep p) {
            int cntr = 0;

            OracleParameter[] paramsList = new OracleParameter[17];
            paramsList[cntr++] = DBHelper.mp("CLEC_ADDS_ID", p.ClecAddsId);
            paramsList[cntr++] = DBHelper.mp("DICE", p.Dice);
            paramsList[cntr++] = DBHelper.mp("NAME", p.Name);
            paramsList[cntr++] = DBHelper.mp("TYPE", p.Type);
            paramsList[cntr++] = DBHelper.mp("PANEL", p.Panel);
            paramsList[cntr++] = DBHelper.mp("DEALER", p.Dealer);
            paramsList[cntr++] = DBHelper.mp("START_DATE", p.StartDate);
            paramsList[cntr++] = DBHelper.mp("CYCLE", p.Cycle);
            paramsList[cntr++] = DBHelper.mp("BRANCH", p.Branch);
            paramsList[cntr++] = DBHelper.mp("AMOUNT", p.Amount);
            paramsList[cntr++] = DBHelper.mp("REP", p.Rep);
            paramsList[cntr++] = DBHelper.mp("SERVICE", p.Service);
            paramsList[cntr++] = DBHelper.mp("TECH", p.Tech);
            paramsList[cntr++] = DBHelper.mp("BAN", p.Ban);
            paramsList[cntr++] = DBHelper.mp("RATE", p.Rate);
            paramsList[cntr++] = DBHelper.mp("ENTERED_DATE", p.EnteredDate);
            paramsList[cntr++] = DBHelper.mp("ENTERED_ID", p.EnteredId);
            return paramsList;
        }
     }
}
