﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Requests.CorporateCustomer
{
    public class AddCorporateCustomerRequest
    {
        public string CompanyName { get; set; }
        public int TaxNo { get; set; }
    }
}
