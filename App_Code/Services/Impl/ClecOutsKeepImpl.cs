using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Agile.Domain;
using Agile.DAO;
using Agile.Services.Interface;

namespace Agile.Services.Impl {
    public class ClecOutsKeepImpl : ClecOutsKeepService {
        public ClecOutsKeepImpl() {

    }

        #region ClecOutsKeepService Members

        public ClecOutsKeep Select(string p) {
            ClecOutsKeepDAO q = new ClecOutsKeepDAO();
            return q.Select(p);
        }

        public void Update(ClecOutsKeep p) {
            ClecOutsKeepDAO q = new ClecOutsKeepDAO();
            q.Update(p);
        }

        public void Insert(ClecOutsKeep p) {
            ClecOutsKeepDAO q = new ClecOutsKeepDAO();
            q.Insert(p);
        }

        public void Delete(string p) {
            ClecOutsKeepDAO q = new ClecOutsKeepDAO();
            q.Delete(p);
        }

        #endregion
    }
}
