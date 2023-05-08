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
        private string _endDate;

        public Customer() {

        }

        public string CustId { get { return _custId; } set { _custId = value; } }
        public string Dice { get { return _dice; } set { _dice = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public string Dealer { get { return _dealer; } set { _dealer = value; } }
        public string StartDate { get { return _startDate; } set { _startDate = value; } }
        public string EndDate { get { return _endDate; } set { _endDate = value; } }

        #region SQL
        public const string SELECT_CUSTOMER =
            "SELECT CUST_ID, DICE, NAME, DEALER, START_DATE, END_DATE FROM CUSTOMER WHERE CUST_ID = :CUST_ID";
        public const string INSERT_CUSTOMER =
            "INSERT INTO CUSTOMER(CUST_ID, DICE, NAME, DEALER, START_DATE, END_DATE) VALUES (:CUST_ID, :DICE, :NAME, :DEALER, :START_DATE, :END_DATE)";
        public const string UPDATE_CUSTOMER =
            "UPDATE CUSTOMER SET DICE = :DICE, NAME = :NAME, DEALER = :DEALER, START_DATE = :START_DATE, END_DATE = :END_DATE WHERE CUST_ID = :CUST_ID";
        public const string DELETE_CUSTOMER = 
            "DELETE FROM CUSTOMER WHERE CUST_ID = :CUST_ID";
        #endregion
    }
}
