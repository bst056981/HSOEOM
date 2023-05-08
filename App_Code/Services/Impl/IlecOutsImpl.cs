using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Agile.Domain;
using Agile.DAO;
using Agile.Services.Interface;

namespace Agile.Services.Impl {
    public class IlecOutsImpl : IlecOutsService {
        public IlecOutsImpl() {

    }

        #region IlecOutsService Members

        public IlecOuts Select(string p) {
            IlecOutsDAO q = new IlecOutsDAO();
            return q.Select(p);
        }

        public void Update(IlecOuts p) {
            IlecOutsDAO q = new IlecOutsDAO();
            q.Update(p);
        }

        public void Insert(IlecOuts p) {
            IlecOutsDAO q = new IlecOutsDAO();
            q.Insert(p);
        }

        public void Delete(string p) {
            IlecOutsDAO q = new IlecOutsDAO();
            q.Delete(p);
        }

        #endregion
    }
}
