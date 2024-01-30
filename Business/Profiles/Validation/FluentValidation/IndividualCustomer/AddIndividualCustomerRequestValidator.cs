using Business.Requests.IndividualCustomer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles.Validation.FluentValidation.IndividualCustomer;

    public class AddIndividualCustomerRequestValidator : AbstractValidator<AddIndividualCustomerRequest>
{
    public AddIndividualCustomerRequestValidator()
    {


        RuleFor(x => x.FirstName).NotEmpty().MinimumLength(2).MaximumLength(50);
        RuleFor(x => x.LastName).NotEmpty().MinimumLength(2).MaximumLength(50);
        RuleFor(x => x.NationIdentity).NotEmpty().Must(x => x.ToString().Length == 11);


        
    }
}
