using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Responses.CorporateCustomer
{
    public class GetCorporateCustomerByIdResponse
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public int TaxNo { get; set; }
    }
}
