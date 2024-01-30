using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Abstract;
using DataAccess.Abstract.Person;
using DataAccess.Concrete.EntityFramework.Person;
using Entities.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessRules
{
    public class CorporateCustomerBusinessRules
    {
        private readonly ICorporateCustomerDal _corporateCustomerDal;

        public CorporateCustomerBusinessRules(ICorporateCustomerDal corporateCustomerDal)
        {
            _corporateCustomerDal = corporateCustomerDal;
        }

        public void CheckIfCompanyNameExists(string name)
        {
            bool isNameExists = _corporateCustomerDal.Get(c => c.CompanyName == name) != null;
            if (isNameExists)
                throw new BusinessException("Company name already exists.");
        }

        public void CheckIfCompanyExists(CorporateCustomers? corporateCustomer)
        {
            if (corporateCustomer is null)
                throw new NotFoundException("Corporate Customer not found.");
        }
    }
}
