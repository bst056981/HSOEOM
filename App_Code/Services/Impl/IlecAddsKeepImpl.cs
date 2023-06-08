using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Agile.Domain;
using Agile.DAO;
using Agile.Services.Interface;

namespace Agile.Services.Impl {
    public class IlecAddsKeepImpl : IlecAddsKeepService {
        public IlecAddsKeepImpl() {

    }

        #region IlecAddsKeepService Members

        public IlecAddsKeep Select(string p) {
            IlecAddsKeepDAO q = new IlecAddsKeepDAO();
            return q.Select(p);
        }

        public void Update(IlecAddsKeep p) {
            IlecAddsKeepDAO q = new IlecAddsKeepDAO();
            q.Update(p);
        }

        public void Insert(IlecAddsKeep p) {
            IlecAddsKeepDAO q = new IlecAddsKeepDAO();
            q.Insert(p);
        }

        public void Delete(string p) {
            IlecAddsKeepDAO q = new IlecAddsKeepDAO();
            q.Delete(p);
        }

        #endregion
    }
}
