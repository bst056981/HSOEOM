using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace Agile.Domain
{
    public class CustomerCountHeadings {

        private string _custCntHdrRecId;
        private string _heading1;
        private string _heading2;

        public CustomerCountHeadings() {

        }

        public string CustCntHdrRecId { get { return _custCntHdrRecId; } set { _custCntHdrRecId = value; } }
        public string Heading1 { get { return _heading1; } set { _heading1 = value; } }
        public string Heading2 { get { return _heading2; } set { _heading2 = value; } }

        #region SQL
        public const string SELECT_CUSTOMER_COUNT_HEADINGS =
            "SELECT CUST_CNT_HDR_REC_ID, HEADING1, HEADING2 FROM CUSTOMER_COUNT_HEADINGS WHERE CUST_CNT_HDR_REC_ID = :CUST_CNT_HDR_REC_ID";
        public const string INSERT_CUSTOMER_COUNT_HEADINGS =
            "INSERT INTO CUSTOMER_COUNT_HEADINGS(CUST_CNT_HDR_REC_ID, HEADING1, HEADING2) VALUES (:CUST_CNT_HDR_REC_ID, :HEADING1, :HEADING2)";
        public const string UPDATE_CUSTOMER_COUNT_HEADINGS =
            "UPDATE CUSTOMER_COUNT_HEADINGS SET HEADING1 = :HEADING1, HEADING2 = :HEADING2 WHERE CUST_CNT_HDR_REC_ID = :CUST_CNT_HDR_REC_ID";
        public const string DELETE_CUSTOMER_COUNT_HEADINGS = 
            "DELETE FROM CUSTOMER_COUNT_HEADINGS WHERE CUST_CNT_HDR_REC_ID = :CUST_CNT_HDR_REC_ID";
        #endregion
    }
}
