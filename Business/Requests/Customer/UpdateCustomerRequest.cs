using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Requests.Customer
{
    public class UpdateCustomerRequest
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
    }
}
