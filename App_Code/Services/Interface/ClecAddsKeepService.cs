using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Agile.Domain;

namespace Agile.Services.Interface {
    public interface ClecAddsKeepService {
        ClecAddsKeep Select(string p);
        void Update(ClecAddsKeep p);
        void Insert(ClecAddsKeep p);
        void Delete(string p);
    }
}
