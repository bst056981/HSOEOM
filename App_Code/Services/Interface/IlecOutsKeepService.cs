using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Agile.Domain;

namespace Agile.Services.Interface {
    public interface IlecOutsKeepService {
        IlecOutsKeep Select(string p);
        void Update(IlecOutsKeep p);
        void Insert(IlecOutsKeep p);
        void Delete(string p);
    }
}
