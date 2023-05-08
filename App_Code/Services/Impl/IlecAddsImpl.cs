using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Agile.Domain;
using Agile.DAO;
using Agile.Services.Interface;

namespace Agile.Services.Impl {
    public class IlecAddsImpl : IlecAddsService {
        public IlecAddsImpl() {

    }

        #region IlecAddsService Members

        public IlecAdds Select(string p) {
            IlecAddsDAO q = new IlecAddsDAO();
            return q.Select(p);
        }

        public void Update(IlecAdds p) {
            IlecAddsDAO q = new IlecAddsDAO();
            q.Update(p);
        }

        public void Insert(IlecAdds p) {
            IlecAddsDAO q = new IlecAddsDAO();
            q.Insert(p);
        }

        public void Delete(string p) {
            IlecAddsDAO q = new IlecAddsDAO();
            q.Delete(p);
        }

        #endregion
    }
}
