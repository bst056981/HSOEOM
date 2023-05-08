using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Agile.Domain;
using Agile.DAO;
using Agile.Services.Interface;

namespace Agile.Services.Impl {
    public class CustomerImpl : CustomerService {
        public CustomerImpl() {

    }

        #region CustomerService Members

        public Customer Select(string p) {
            CustomerDAO q = new CustomerDAO();
            return q.Select(p);
        }

        public void Update(Customer p) {
            CustomerDAO q = new CustomerDAO();
            q.Update(p);
        }

        public void Insert(Customer p) {
            CustomerDAO q = new CustomerDAO();
            q.Insert(p);
        }

        public void Delete(string p) {
            CustomerDAO q = new CustomerDAO();
            q.Delete(p);
        }

        #endregion
    }
}
