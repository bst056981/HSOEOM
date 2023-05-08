using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Agile.Domain;

namespace Agile.Services.Interface {
    public interface DealerInfoService {
        DealerInfo Select(string p);
        void Update(DealerInfo p);
        void Insert(DealerInfo p);
        void Delete(string p);
    }
}
