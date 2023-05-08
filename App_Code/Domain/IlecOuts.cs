using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace Agile.Domain
{
    public class IlecOuts {

        private string _ilecOutsId;
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

        public IlecOuts() {

        }

        public string IlecOutsId { get { return _ilecOutsId; } set { _ilecOutsId = value; } }
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
        public const string SELECT_ILEC_OUTS =
            "SELECT ILEC_OUTS_ID, DICE, NAME, REASON, PANEL, INACTIVE_DATE, DEALER, START_DATE, REP, SERVICE, BAN, RATE FROM ILEC_OUTS WHERE ILEC_OUTS_ID = :ILEC_OUTS_ID";
        public const string INSERT_ILEC_OUTS =
            "INSERT INTO ILEC_OUTS(ILEC_OUTS_ID, DICE, NAME, REASON, PANEL, INACTIVE_DATE, DEALER, START_DATE, REP, SERVICE, BAN, RATE) VALUES (:ILEC_OUTS_ID, :DICE, :NAME, :REASON, :PANEL, :INACTIVE_DATE, :DEALER, :START_DATE, :REP, :SERVICE, :BAN, :RATE)";
        public const string UPDATE_ILEC_OUTS =
            "UPDATE ILEC_OUTS SET DICE = :DICE, NAME = :NAME, REASON = :REASON, PANEL = :PANEL, INACTIVE_DATE = :INACTIVE_DATE, DEALER = :DEALER, START_DATE = :START_DATE, REP = :REP, SERVICE = :SERVICE, BAN = :BAN, RATE = :RATE WHERE ILEC_OUTS_ID = :ILEC_OUTS_ID";
        public const string DELETE_ILEC_OUTS = 
            "DELETE FROM ILEC_OUTS WHERE ILEC_OUTS_ID = :ILEC_OUTS_ID";
        #endregion
    }
}
