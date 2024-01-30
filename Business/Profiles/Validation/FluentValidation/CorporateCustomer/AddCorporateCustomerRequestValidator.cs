using Business.Requests.CorporateCustomer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles.Validation.FluentValidation.CorporateCustomer
{
    public class AddCorporateCustomerRequestValidator : AbstractValidator<AddCorporateCustomerRequest>
    {
        public AddCorporateCustomerRequestValidator()
        {
            RuleFor(x=>x.CompanyName.Length).NotEmpty().GreaterThan(0);
            RuleFor(x=>x.TaxNo).NotEmpty().Must(x => x.ToString().Length == 10);
        }
    }
}
