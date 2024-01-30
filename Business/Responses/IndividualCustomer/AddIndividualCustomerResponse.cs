using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses.IndividualCustomer;

public class AddIndividualCustomerResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Int64 NationIdentity { get; set; }
    public DateTime CreatedAt { get; set; }
}
