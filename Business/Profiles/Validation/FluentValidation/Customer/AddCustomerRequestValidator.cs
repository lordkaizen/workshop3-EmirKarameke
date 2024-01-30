using Business.Requests.Customer;
using Business.Requests.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles.Validation.FluentValidation.Customer
{
    public class AddCustomerRequestValidator : AbstractValidator<AddCustomerRequest>
    {
       public AddCustomerRequestValidator() 
        {
            RuleFor(x => x.CustomerId).NotEmpty();
        }
    }
}
