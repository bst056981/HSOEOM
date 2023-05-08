using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Agile.Domain;

namespace Agile.Services.Interface {
    public interface CustomerService {
        Customer Select(string p);
        void Update(Customer p);
        void Insert(Customer p);
        void Delete(string p);
    }
}
