using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Agile.Domain;

namespace Agile.Services.Interface {
    public interface ClecAddsService {
        ClecAdds Select(string p);
        void Update(ClecAdds p);
        void Insert(ClecAdds p);
        void Delete(string p);
    }
}
