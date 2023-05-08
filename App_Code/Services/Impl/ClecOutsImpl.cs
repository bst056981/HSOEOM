using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Agile.Domain;
using Agile.DAO;
using Agile.Services.Interface;

namespace Agile.Services.Impl {
    public class ClecOutsImpl : ClecOutsService {
        public ClecOutsImpl() {

    }

        #region ClecOutsService Members

        public ClecOuts Select(string p) {
            ClecOutsDAO q = new ClecOutsDAO();
            return q.Select(p);
        }

        public void Update(ClecOuts p) {
            ClecOutsDAO q = new ClecOutsDAO();
            q.Update(p);
        }

        public void Insert(ClecOuts p) {
            ClecOutsDAO q = new ClecOutsDAO();
            q.Insert(p);
        }

        public void Delete(string p) {
            ClecOutsDAO q = new ClecOutsDAO();
            q.Delete(p);
        }

        #endregion
    }
}
