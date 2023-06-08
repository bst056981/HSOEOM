using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Agile.Domain;
using Agile.DAO;
using Agile.Services.Interface;

namespace Agile.Services.Impl {
    public class ClecAddsKeepImpl : ClecAddsKeepService {
        public ClecAddsKeepImpl() {

    }

        #region ClecAddsKeepService Members

        public ClecAddsKeep Select(string p) {
            ClecAddsKeepDAO q = new ClecAddsKeepDAO();
            return q.Select(p);
        }

        public void Update(ClecAddsKeep p) {
            ClecAddsKeepDAO q = new ClecAddsKeepDAO();
            q.Update(p);
        }

        public void Insert(ClecAddsKeep p) {
            ClecAddsKeepDAO q = new ClecAddsKeepDAO();
            q.Insert(p);
        }

        public void Delete(string p) {
            ClecAddsKeepDAO q = new ClecAddsKeepDAO();
            q.Delete(p);
        }

        #endregion
    }
}
