using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Agile.Domain;
using Agile.DAO;
using Agile.Services.Interface;

namespace Agile.Services.Impl {
    public class CustomerCountHeadingsImpl : CustomerCountHeadingsService {
        public CustomerCountHeadingsImpl() {

    }

        #region CustomerCountHeadingsService Members

        public CustomerCountHeadings Select(string p) {
            CustomerCountHeadingsDAO q = new CustomerCountHeadingsDAO();
            return q.Select(p);
        }

        public void Update(CustomerCountHeadings p) {
            CustomerCountHeadingsDAO q = new CustomerCountHeadingsDAO();
            q.Update(p);
        }

        public void Insert(CustomerCountHeadings p) {
            CustomerCountHeadingsDAO q = new CustomerCountHeadingsDAO();
            q.Insert(p);
        }

        public void Delete(string p) {
            CustomerCountHeadingsDAO q = new CustomerCountHeadingsDAO();
            q.Delete(p);
        }

        #endregion
    }
}
