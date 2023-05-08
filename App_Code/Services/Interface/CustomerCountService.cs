using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Agile.Domain;

namespace Agile.Services.Interface {
    public interface CustomerCountService {
        CustomerCount Select(string p);
        void Update(CustomerCount p);
        void Insert(CustomerCount p);
        void Delete(string p);
    }
}
