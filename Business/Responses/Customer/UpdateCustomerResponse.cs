﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses.Customer;

public class UpdateCustomerResponse
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public DateTime CreatedAt { get; set; }
}
