using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace Agile.Domain
{
    public class CustomerCount {

        private string _recId;
        private string _custCntRecId;
        private string _custCntDate;
        private string _custCnt;

        public CustomerCount() {

        }

        public string RecId { get { return _recId; } set { _recId = value; } }
        public string CustCntRecId { get { return _custCntRecId; } set { _custCntRecId = value; } }
        public string CustCntDate { get { return _custCntDate; } set { _custCntDate = value; } }
        public string CustCnt { get { return _custCnt; } set { _custCnt = value; } }

        #region SQL
        public const string SELECT_CUSTOMER_COUNT =
            "SELECT REC_ID, CUST_CNT_REC_ID, CUST_CNT_DATE, CUST_CNT FROM CUSTOMER_COUNT WHERE REC_ID = :REC_ID";
        public const string INSERT_CUSTOMER_COUNT =
            "INSERT INTO CUSTOMER_COUNT(REC_ID, CUST_CNT_REC_ID, CUST_CNT_DATE, CUST_CNT) VALUES (:REC_ID, :CUST_CNT_REC_ID, :CUST_CNT_DATE, :CUST_CNT)";
        public const string UPDATE_CUSTOMER_COUNT =
            "UPDATE CUSTOMER_COUNT SET CUST_CNT_REC_ID = :CUST_CNT_REC_ID, CUST_CNT_DATE = :CUST_CNT_DATE, CUST_CNT = :CUST_CNT WHERE REC_ID = :REC_ID";
        public const string DELETE_CUSTOMER_COUNT = 
            "DELETE FROM CUSTOMER_COUNT WHERE REC_ID = :REC_ID";
        #endregion
    }
}
