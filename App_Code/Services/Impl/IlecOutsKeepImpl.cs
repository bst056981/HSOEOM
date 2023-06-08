using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Agile.Domain;
using Agile.DAO;
using Agile.Services.Interface;

namespace Agile.Services.Impl {
    public class IlecOutsKeepImpl : IlecOutsKeepService {
        public IlecOutsKeepImpl() {

    }

        #region IlecOutsKeepService Members

        public IlecOutsKeep Select(string p) {
            IlecOutsKeepDAO q = new IlecOutsKeepDAO();
            return q.Select(p);
        }

        public void Update(IlecOutsKeep p) {
            IlecOutsKeepDAO q = new IlecOutsKeepDAO();
            q.Update(p);
        }

        public void Insert(IlecOutsKeep p) {
            IlecOutsKeepDAO q = new IlecOutsKeepDAO();
            q.Insert(p);
        }

        public void Delete(string p) {
            IlecOutsKeepDAO q = new IlecOutsKeepDAO();
            q.Delete(p);
        }

        #endregion
    }
}
