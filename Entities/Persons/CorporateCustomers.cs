using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Persons;

public class CorporateCustomers : Entity<int>
{
    public string CompanyName { get; set; }
    public int TaxNo { get; set; }

    public CorporateCustomers() { }
    public CorporateCustomers(string companyName, int taxNo, Users users, Customers customers)
    {
        CompanyName = companyName;
        TaxNo = taxNo;
        Users = users;
        Customers = customers;
    }

    public Users? Users { get; set; }
    public Customers? Customers { get; set; }

}
