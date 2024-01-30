using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses.Customer
{
    public class AddCustomerResponse
    {
        public int Id { get; set; }
        public int UsertId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
