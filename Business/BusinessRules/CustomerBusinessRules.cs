using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Abstract;
using DataAccess.Abstract.Person;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Person;
using Entities.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessRules
{
    public class CustomerBusinessRules
    {
        private readonly ICustomerDal _customerDal;

        public CustomerBusinessRules(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public void CheckIfCustomerExists(Customers? customers)
        {
            if (customers is null)
                throw new NotFoundException("Customer not found.");
        }


    }
}
