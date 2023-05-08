using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Agile.Domain;
using Agile.DAO;
using Agile.Services.Interface;

namespace Agile.Services.Impl {
    public class ClecAddsImpl : ClecAddsService {
        public ClecAddsImpl() {

    }

        #region ClecAddsService Members

        public ClecAdds Select(string p) {
            ClecAddsDAO q = new ClecAddsDAO();
            return q.Select(p);
        }

        public void Update(ClecAdds p) {
            ClecAddsDAO q = new ClecAddsDAO();
            q.Update(p);
        }

        public void Insert(ClecAdds p) {
            ClecAddsDAO q = new ClecAddsDAO();
            q.Insert(p);
        }

        public void Delete(string p) {
            ClecAddsDAO q = new ClecAddsDAO();
            q.Delete(p);
        }

        #endregion
    }
}
