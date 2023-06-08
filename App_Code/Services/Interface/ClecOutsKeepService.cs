using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Agile.Domain;

namespace Agile.Services.Interface {
    public interface ClecOutsKeepService {
        ClecOutsKeep Select(string p);
        void Update(ClecOutsKeep p);
        void Insert(ClecOutsKeep p);
        void Delete(string p);
    }
}
