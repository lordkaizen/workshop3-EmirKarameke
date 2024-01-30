using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Persons;

public class Customers : Entity<int>
{
    public int UserId { get; set; }
    
    public Customers() { }
    public Customers(int userId)
    {
        UserId = userId;
    }

    public Users? Users { get; set; }
}
