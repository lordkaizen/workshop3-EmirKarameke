﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Requests.IndividualCustomer;

public class AddIndividualCustomerRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Int64 NationIdentity { get; set; }
}
