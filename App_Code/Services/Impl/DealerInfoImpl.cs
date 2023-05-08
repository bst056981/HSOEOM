using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Agile.Domain;
using Agile.DAO;
using Agile.Services.Interface;

namespace Agile.Services.Impl {
    public class DealerInfoImpl : DealerInfoService {
        public DealerInfoImpl() {

    }

        #region DealerInfoService Members

        public DealerInfo Select(string p) {
            DealerInfoDAO q = new DealerInfoDAO();
            return q.Select(p);
        }

        public void Update(DealerInfo p) {
            DealerInfoDAO q = new DealerInfoDAO();
            q.Update(p);
        }

        public void Insert(DealerInfo p) {
            DealerInfoDAO q = new DealerInfoDAO();
            q.Insert(p);
        }

        public void Delete(string p) {
            DealerInfoDAO q = new DealerInfoDAO();
            q.Delete(p);
        }

        #endregion
    }
}
