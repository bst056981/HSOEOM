using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace Agile.Domain
{
    public class IlecOutsKeep {

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
        private string _enteredDate;
        private string _enteredId;

        public IlecOutsKeep() {

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
        public string EnteredDate { get { return _enteredDate; } set { _enteredDate = value; } }
        public string EnteredId { get { return _enteredId; } set { _enteredId = value; } }

        #region SQL
        public const string SELECT_ILEC_OUTS_KEEP =
            "SELECT ILEC_OUTS_ID, DICE, NAME, REASON, PANEL, INACTIVE_DATE, DEALER, START_DATE, REP, SERVICE, BAN, RATE, ENTERED_DATE, ENTERED_ID FROM ILEC_OUTS_KEEP WHERE ILEC_OUTS_ID = :ILEC_OUTS_ID";
        public const string INSERT_ILEC_OUTS_KEEP =
            "INSERT INTO ILEC_OUTS_KEEP(ILEC_OUTS_ID, DICE, NAME, REASON, PANEL, INACTIVE_DATE, DEALER, START_DATE, REP, SERVICE, BAN, RATE, ENTERED_DATE, ENTERED_ID) VALUES (:ILEC_OUTS_ID, :DICE, :NAME, :REASON, :PANEL, :INACTIVE_DATE, :DEALER, :START_DATE, :REP, :SERVICE, :BAN, :RATE, :ENTERED_DATE, :ENTERED_ID)";
        public const string UPDATE_ILEC_OUTS_KEEP =
            "UPDATE ILEC_OUTS_KEEP SET DICE = :DICE, NAME = :NAME, REASON = :REASON, PANEL = :PANEL, INACTIVE_DATE = :INACTIVE_DATE, DEALER = :DEALER, START_DATE = :START_DATE, REP = :REP, SERVICE = :SERVICE, BAN = :BAN, RATE = :RATE, ENTERED_DATE = :ENTERED_DATE, ENTERED_ID = :ENTERED_ID WHERE ILEC_OUTS_ID = :ILEC_OUTS_ID";
        public const string DELETE_ILEC_OUTS_KEEP = 
            "DELETE FROM ILEC_OUTS_KEEP WHERE ILEC_OUTS_ID = :ILEC_OUTS_ID";
        #endregion
    }
}
