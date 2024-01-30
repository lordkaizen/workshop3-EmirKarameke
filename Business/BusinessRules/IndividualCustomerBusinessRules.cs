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

namespace Business.BusinessRules;

public class IndividualCustomerBusinessRules
{
    private readonly IIndividualCustomerDal _individualCustomerDal;

    public IndividualCustomerBusinessRules(IIndividualCustomerDal individualCustomerDal)
    {
        _individualCustomerDal = individualCustomerDal;
    }

    public void CheckIfIndividualCustomerFirstNameExists(string name)
    {
        bool isNameExists = _individualCustomerDal.Get(m => m.FirstName == name) != null;
        if (isNameExists)
            throw new BusinessException("Individual Customer name already exists.");
    }

    public void CheckIfIndividualCustomerExists(IndividualCustomers? individualCustomer)
    {
        if (individualCustomer is null)
            throw new NotFoundException("Individual Customer not found.");
    }

}
