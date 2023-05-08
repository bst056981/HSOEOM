using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Agile.Domain;
using Agile.DAO;
using Agile.Services.Interface;

namespace Agile.Services.Impl {
    public class CustomerCountImpl : CustomerCountService {
        public CustomerCountImpl() {

    }

        #region CustomerCountService Members

        public CustomerCount Select(string p) {
            CustomerCountDAO q = new CustomerCountDAO();
            return q.Select(p);
        }

        public void Update(CustomerCount p) {
            CustomerCountDAO q = new CustomerCountDAO();
            q.Update(p);
        }

        public void Insert(CustomerCount p) {
            CustomerCountDAO q = new CustomerCountDAO();
            q.Insert(p);
        }

        public void Delete(string p) {
            CustomerCountDAO q = new CustomerCountDAO();
            q.Delete(p);
        }

        #endregion
    }
}
