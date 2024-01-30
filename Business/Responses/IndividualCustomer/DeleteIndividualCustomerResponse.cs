using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses.IndividualCustomer
{
    public class DeleteIndividualCustomerResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}
