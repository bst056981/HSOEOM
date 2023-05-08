using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace Agile.Domain
{
    public class ClecOuts {

        private string _clecOutsId;
        private string _dice;
        private string _name;
        private string _reason;
        private string _panel;
        private string _inactiveDate;
        private string _dealer;
        private string _startDate;
        private string _rep;
        private string _service;
        private string _ban;
        private string _rate;

        public ClecOuts() {

        }

        public string ClecOutsId { get { return _clecOutsId; } set { _clecOutsId = value; } }
        public string Dice { get { return _dice; } set { _dice = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public string Reason { get { return _reason; } set { _reason = value; } }
        public string Panel { get { return _panel; } set { _panel = value; } }
        public string InactiveDate { get { return _inactiveDate; } set { _inactiveDate = value; } }
        public string Dealer { get { return _dealer; } set { _dealer = value; } }
        public string StartDate { get { return _startDate; } set { _startDate = value; } }
        public string Rep { get { return _rep; } set { _rep = value; } }
        public string Service { get { return _service; } set { _service = value; } }
        public string Ban { get { return _ban; } set { _ban = value; } }
        public string Rate { get { return _rate; } set { _rate = value; } }

        #region SQL
        public const string SELECT_CLEC_OUTS =
            "SELECT CLEC_OUTS_ID, DICE, NAME, REASON, PANEL, INACTIVE_DATE, DEALER, START_DATE, REP, SERVICE, BAN, RATE FROM CLEC_OUTS WHERE CLEC_OUTS_ID = :CLEC_OUTS_ID";
        public const string INSERT_CLEC_OUTS =
            "INSERT INTO CLEC_OUTS(CLEC_OUTS_ID, DICE, NAME, REASON, PANEL, INACTIVE_DATE, DEALER, START_DATE, REP, SERVICE, BAN, RATE) VALUES (:CLEC_OUTS_ID, :DICE, :NAME, :REASON, :PANEL, :INACTIVE_DATE, :DEALER, :START_DATE, :REP, :SERVICE, :BAN, :RATE)";
        public const string UPDATE_CLEC_OUTS =
            "UPDATE CLEC_OUTS SET DICE = :DICE, NAME = :NAME, REASON = :REASON, PANEL = :PANEL, INACTIVE_DATE = :INACTIVE_DATE, DEALER = :DEALER, START_DATE = :START_DATE, REP = :REP, SERVICE = :SERVICE, BAN = :BAN, RATE = :RATE WHERE CLEC_OUTS_ID = :CLEC_OUTS_ID";
        public const string DELETE_CLEC_OUTS = 
            "DELETE FROM CLEC_OUTS WHERE CLEC_OUTS_ID = :CLEC_OUTS_ID";
        #endregion
    }
}
