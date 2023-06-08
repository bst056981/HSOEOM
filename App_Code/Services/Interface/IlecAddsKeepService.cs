using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Agile.Domain;

namespace Agile.Services.Interface {
    public interface IlecAddsKeepService {
        IlecAddsKeep Select(string p);
        void Update(IlecAddsKeep p);
        void Insert(IlecAddsKeep p);
        void Delete(string p);
    }
}
