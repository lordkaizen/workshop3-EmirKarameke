using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses.IndividualCustomer
{
    public class UpdateIndividualCustomerResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int NationIdentity { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
