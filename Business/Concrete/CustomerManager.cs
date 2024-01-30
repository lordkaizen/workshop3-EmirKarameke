using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Profiles.Validation.FluentValidation.Customer;
using Business.Profiles.Validation.FluentValidation.Model;
using Business.Requests.Customer;
using Business.Responses.Customer;
using Business.Responses.Model;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
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

namespace Business.Concrete;

public class CustomerManager : ICustomerService
{
    private readonly ICustomerDal _customerDal;
    private readonly CustomerBusinessRules _customerBusinessRules;
    private readonly IMapper _mapper;

    public CustomerManager(ICustomerDal customerDal, CustomerBusinessRules customerBusinessRules, IMapper mapper)
    {
        _customerDal = customerDal;
        _customerBusinessRules = customerBusinessRules;
        _mapper = mapper;
    }
    public AddCustomerResponse Add(AddCustomerRequest request)
    {
        ValidationTool.Validate(new AddCustomerRequestValidator(), request);


        


        // mapping
        var customerToAdd = _mapper.Map<Customers>(request);

        // data operations
        Customers addedCustomer = _customerDal.Add(customerToAdd);

        // mapping & response
        var response = _mapper.Map<AddCustomerResponse>(addedCustomer);
        return response;
    }

    public DeleteCustomerResponse Delete(DeleteCustomerRequest request)
    {
        Customers? customerToDelete = _customerDal.Get(predicate: customer => customer.UserId == request.Id); // 0x123123
        _customerBusinessRules.CheckIfCustomerExists(customerToDelete); // 0x123123

        Customers deletedCustomer = _customerDal.Delete(customerToDelete!); // 0x123123

        var response = _mapper.Map<DeleteCustomerResponse>(
            deletedCustomer // 0x123123
        );
        return response;
    }

    public GetCustomerByIdResponse GetById(GetCustomerByIdRequest request)
    {
        Customers? customer = _customerDal.Get(predicate: customer => customer.Id == request.Id);
        _customerBusinessRules.CheckIfCustomerExists(customer);

        var response = _mapper.Map<GetCustomerByIdResponse>(customer);
        return response;
    }

    public UpdateCustomerResponse Update(UpdateCustomerRequest request)
    {
        Customers? customer = _customerDal.Get(predicate: model => model.Id == request.Id); // 0x123123
        _customerBusinessRules.CheckIfCustomerExists(customer);

        customer = _mapper.Map(request, customer); // 0x123123
        Customers updatedModel = _customerDal.Update(customer!); // 0x123123

        var response = _mapper.Map<UpdateCustomerResponse>(
            updatedModel // 0x123123
        );
        return response;
    }
}
