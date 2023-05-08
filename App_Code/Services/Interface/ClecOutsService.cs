using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Agile.Domain;

namespace Agile.Services.Interface {
    public interface ClecOutsService {
        ClecOuts Select(string p);
        void Update(ClecOuts p);
        void Insert(ClecOuts p);
        void Delete(string p);
    }
}
