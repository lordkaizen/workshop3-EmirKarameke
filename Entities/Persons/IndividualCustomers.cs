using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Persons;

public class IndividualCustomers : Entity<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Int64 NationIdentity { get; set; }

    public IndividualCustomers() { }
    public IndividualCustomers(string firstName, string lastName, int nationIdentity, Users users, Customers customers)
    {
        FirstName = firstName;
        LastName = lastName;
        NationIdentity = nationIdentity;
        Users = users;
        Customers = customers;
    }

    public Users? Users { get; set; }
    public Customers? Customers { get; set; }
}
