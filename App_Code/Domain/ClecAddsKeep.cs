using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace Agile.Domain
{
    public class ClecAddsKeep {

        private string _clecAddsId;
        private string _dice;
        private string _name;
        private string _type;
        private string _panel;
        private string _dealer;
        private string _startDate;
        private string _cycle;
        private string _branch;
        private string _amount;
        private string _rep;
        private string _service;
        private string _tech;
        private string _ban;
        private string _rate;
        private string _enteredDate;
        private string _enteredId;

        public ClecAddsKeep() {

        }

        public string ClecAddsId { get { return _clecAddsId; } set { _clecAddsId = value; } }
        public string Dice { get { return _dice; } set { _dice = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public string Type { get { return _type; } set { _type = value; } }
        public string Panel { get { return _panel; } set { _panel = value; } }
        public string Dealer { get { return _dealer; } set { _dealer = value; } }
        public string StartDate { get { return _startDate; } set { _startDate = value; } }
        public string Cycle { get { return _cycle; } set { _cycle = value; } }
        public string Branch { get { return _branch; } set { _branch = value; } }
        public string Amount { get { return _amount; } set { _amount = value; } }
        public string Rep { get { return _rep; } set { _rep = value; } }
        public string Service { get { return _service; } set { _service = value; } }
        public string Tech { get { return _tech; } set { _tech = value; } }
        public string Ban { get { return _ban; } set { _ban = value; } }
        public string Rate { get { return _rate; } set { _rate = value; } }
        public string EnteredDate { get { return _enteredDate; } set { _enteredDate = value; } }
        public string EnteredId { get { return _enteredId; } set { _enteredId = value; } }

        #region SQL
        public const string SELECT_CLEC_ADDS_KEEP =
            "SELECT CLEC_ADDS_ID, DICE, NAME, TYPE, PANEL, DEALER, START_DATE, CYCLE, BRANCH, AMOUNT, REP, SERVICE, TECH, BAN, RATE, ENTERED_DATE, ENTERED_ID FROM CLEC_ADDS_KEEP WHERE CLEC_ADDS_ID = :CLEC_ADDS_ID";
        public const string INSERT_CLEC_ADDS_KEEP =
            "INSERT INTO CLEC_ADDS_KEEP(CLEC_ADDS_ID, DICE, NAME, TYPE, PANEL, DEALER, START_DATE, CYCLE, BRANCH, AMOUNT, REP, SERVICE, TECH, BAN, RATE, ENTERED_DATE, ENTERED_ID) VALUES (:CLEC_ADDS_ID, :DICE, :NAME, :TYPE, :PANEL, :DEALER, :START_DATE, :CYCLE, :BRANCH, :AMOUNT, :REP, :SERVICE, :TECH, :BAN, :RATE, :ENTERED_DATE, :ENTERED_ID)";
        public const string UPDATE_CLEC_ADDS_KEEP =
            "UPDATE CLEC_ADDS_KEEP SET DICE = :DICE, NAME = :NAME, TYPE = :TYPE, PANEL = :PANEL, DEALER = :DEALER, START_DATE = :START_DATE, CYCLE = :CYCLE, BRANCH = :BRANCH, AMOUNT = :AMOUNT, REP = :REP, SERVICE = :SERVICE, TECH = :TECH, BAN = :BAN, RATE = :RATE, ENTERED_DATE = :ENTERED_DATE, ENTERED_ID = :ENTERED_ID WHERE CLEC_ADDS_ID = :CLEC_ADDS_ID";
        public const string DELETE_CLEC_ADDS_KEEP = 
            "DELETE FROM CLEC_ADDS_KEEP WHERE CLEC_ADDS_ID = :CLEC_ADDS_ID";
        #endregion
    }
}