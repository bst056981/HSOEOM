using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Agile.Domain;

namespace Agile.Services.Interface {
    public interface IlecAddsService {
        IlecAdds Select(string p);
        void Update(IlecAdds p);
        void Insert(IlecAdds p);
        void Delete(string p);
    }
}
