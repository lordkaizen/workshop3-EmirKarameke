using Core.DataAccess;
using DataAccess.Concrete.EntityFramework.Person;
using Entities.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract.Person
{
    public interface ICustomerDal : IEntityRepository<Customers, int>
    {
    }
}
