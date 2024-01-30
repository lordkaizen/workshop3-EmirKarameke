using Core.DataAccess;
using Entities.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract.Person;

public interface ICorporateCustomerDal : IEntityRepository<CorporateCustomers,int>
{
}
