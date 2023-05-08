using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace Agile.Domain
{
    public class IlecAdds {

        private string _ilecAddsId;
        private string _dice;
        private string _name;
        private string _type;
        private string _panel;
        private string _dealer;
        private string _startDate;
        private string _map;
        private string _branch;
        private string _amount;
        private string _rep;
        private string _service;
        private string _tech;
        private string _ban;
        private string _rate;

        public IlecAdds() {

        }

        public string IlecAddsId { get { return _ilecAddsId; } set { _ilecAddsId = value; } }
        public string Dice { get { return _dice; } set { _dice = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public string Type { get { return _type; } set { _type = value; } }
        public string Panel { get { return _panel; } set { _panel = value; } }
        public string Dealer { get { return _dealer; } set { _dealer = value; } }
        public string StartDate { get { return _startDate; } set { _startDate = value; } }
        public string Map { get { return _map; } set { _map = value; } }
        public string Branch { get { return _branch; } set { _branch = value; } }
        public string Amount { get { return _amount; } set { _amount = value; } }
        public string Rep { get { return _rep; } set { _rep = value; } }
        public string Service { get { return _service; } set { _service = value; } }
        public string Tech { get { return _tech; } set { _tech = value; } }
        public string Ban { get { return _ban; } set { _ban = value; } }
        public string Rate { get { return _rate; } set { _rate = value; } }

        #region SQL
        public const string SELECT_ILEC_ADDS =
            "SELECT ILEC_ADDS_ID, DICE, NAME, TYPE, PANEL, DEALER, START_DATE, MAP, BRANCH, AMOUNT, REP, SERVICE, TECH, BAN, RATE FROM ILEC_ADDS WHERE ILEC_ADDS_ID = :ILEC_ADDS_ID";
        public const string INSERT_ILEC_ADDS =
            "INSERT INTO ILEC_ADDS(ILEC_ADDS_ID, DICE, NAME, TYPE, PANEL, DEALER, START_DATE, MAP, BRANCH, AMOUNT, REP, SERVICE, TECH, BAN, RATE) VALUES (:ILEC_ADDS_ID, :DICE, :NAME, :TYPE, :PANEL, :DEALER, :START_DATE, :MAP, :BRANCH, :AMOUNT, :REP, :SERVICE, :TECH, :BAN, :RATE)";
        public const string UPDATE_ILEC_ADDS =
            "UPDATE ILEC_ADDS SET DICE = :DICE, NAME = :NAME, TYPE = :TYPE, PANEL = :PANEL, DEALER = :DEALER, START_DATE = :START_DATE, MAP = :MAP, BRANCH = :BRANCH, AMOUNT = :AMOUNT, REP = :REP, SERVICE = :SERVICE, TECH = :TECH, BAN = :BAN, RATE = :RATE WHERE ILEC_ADDS_ID = :ILEC_ADDS_ID";
        public const string DELETE_ILEC_ADDS = 
            "DELETE FROM ILEC_ADDS WHERE ILEC_ADDS_ID = :ILEC_ADDS_ID";
        #endregion
    }
}
