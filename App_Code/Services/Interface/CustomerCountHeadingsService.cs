using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Agile.Domain;

namespace Agile.Services.Interface {
    public interface CustomerCountHeadingsService {
        CustomerCountHeadings Select(string p);
        void Update(CustomerCountHeadings p);
        void Insert(CustomerCountHeadings p);
        void Delete(string p);
    }
}
