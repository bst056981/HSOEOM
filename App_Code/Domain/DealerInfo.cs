using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace Agile.Domain
{
    public class DealerInfo {

        private string _dealerId;
        private string _dealer;
        private string _dealerReport;

        public DealerInfo() {

        }

        public string DealerId { get { return _dealerId; } set { _dealerId = value; } }
        public string Dealer { get { return _dealer; } set { _dealer = value; } }
        public string DealerReport { get { return _dealerReport; } set { _dealerReport = value; } }

        #region SQL
        public const string SELECT_DEALER_INFO =
            "SELECT DEALER_ID, DEALER, DEALER_REPORT FROM DEALER_INFO WHERE DEALER_ID = :DEALER_ID";
        public const string INSERT_DEALER_INFO =
            "INSERT INTO DEALER_INFO(DEALER_ID, DEALER, DEALER_REPORT) VALUES (:DEALER_ID, :DEALER, :DEALER_REPORT)";
        public const string UPDATE_DEALER_INFO =
            "UPDATE DEALER_INFO SET DEALER = :DEALER, DEALER_REPORT = :DEALER_REPORT WHERE DEALER_ID = :DEALER_ID";
        public const string DELETE_DEALER_INFO = 
            "DELETE FROM DEALER_INFO WHERE DEALER_ID = :DEALER_ID";
        #endregion
    }
}
