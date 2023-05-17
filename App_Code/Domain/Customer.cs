using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace Agile.Domain
{
    public class Customer {

        private string _custId;
        private string _dice;
        private string _name;
        private string _dealer;
        private string _startDate;
        private string _inactiveDate;
        private string _enteredDate;
        private string _enteredId;
        private string _type;
        private string _panel;
        private string _cycle;
        private string _branch;
        private string _amount;
        private string _rep;
        private string _service;
        private string _tech;
        private string _ban;
        private string _rate;
        private string _reason;

        public Customer() {

        }

        public string CustId { get { return _custId; } set { _custId = value; } }
        public string Dice { get { return _dice; } set { _dice = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public string Dealer { get { return _dealer; } set { _dealer = value; } }
        public string StartDate { get { return _startDate; } set { _startDate = value; } }
        public string InactiveDate { get { return _inactiveDate; } set { _inactiveDate = value; } }
        public string EnteredDate { get { return _enteredDate; } set { _enteredDate = value; } }
        public string EnteredId { get { return _enteredId; } set { _enteredId = value; } }
        public string Type { get { return _type; } set { _type = value; } }
        public string Panel { get { return _panel; } set { _panel = value; } }
        public string Cycle { get { return _cycle; } set { _cycle = value; } }
        public string Branch { get { return _branch; } set { _branch = value; } }
        public string Amount { get { return _amount; } set { _amount = value; } }
        public string Rep { get { return _rep; } set { _rep = value; } }
        public string Service { get { return _service; } set { _service = value; } }
        public string Tech { get { return _tech; } set { _tech = value; } }
        public string Ban { get { return _ban; } set { _ban = value; } }
        public string Rate { get { return _rate; } set { _rate = value; } }
        public string Reason { get { return _reason; } set { _reason = value; } }

        #region SQL
        public const string SELECT_CUSTOMER =
            "SELECT CUST_ID, DICE, NAME, DEALER, START_DATE, INACTIVE_DATE, ENTERED_DATE, ENTERED_ID, TYPE, PANEL, CYCLE, BRANCH, AMOUNT, REP, SERVICE, TECH, BAN, RATE, REASON FROM CUSTOMER WHERE CUST_ID = :CUST_ID";
        public const string INSERT_CUSTOMER =
            "INSERT INTO CUSTOMER(CUST_ID, DICE, NAME, DEALER, START_DATE, INACTIVE_DATE, ENTERED_DATE, ENTERED_ID, TYPE, PANEL, CYCLE, BRANCH, AMOUNT, REP, SERVICE, TECH, BAN, RATE, REASON) VALUES (:CUST_ID, :DICE, :NAME, :DEALER, :START_DATE, :INACTIVE_DATE, :ENTERED_DATE, :ENTERED_ID, :TYPE, :PANEL, :CYCLE, :BRANCH, :AMOUNT, :REP, :SERVICE, :TECH, :BAN, :RATE, :REASON)";
        public const string UPDATE_CUSTOMER =
            "UPDATE CUSTOMER SET DICE = :DICE, NAME = :NAME, DEALER = :DEALER, START_DATE = :START_DATE, INACTIVE_DATE = :INACTIVE_DATE, ENTERED_DATE = :ENTERED_DATE, ENTERED_ID = :ENTERED_ID, TYPE = :TYPE, PANEL = :PANEL, CYCLE = :CYCLE, BRANCH = :BRANCH, AMOUNT = :AMOUNT, REP = :REP, SERVICE = :SERVICE, TECH = :TECH, BAN = :BAN, RATE = :RATE, REASON = :REASON WHERE CUST_ID = :CUST_ID";
        public const string DELETE_CUSTOMER = 
            "DELETE FROM CUSTOMER WHERE CUST_ID = :CUST_ID";
        public const string GET_CUST_ID =
          "SELECT CUST_ID_SEQ.NEXTVAL FROM DUAL";
        #endregion
    }
}
