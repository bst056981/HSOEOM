using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Agile.Domain;

namespace Agile.Services.Interface {
    public interface IlecOutsService {
        IlecOuts Select(string p);
        void Update(IlecOuts p);
        void Insert(IlecOuts p);
        void Delete(string p);
    }
}
