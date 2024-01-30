using Business.Requests.CorporateCustomer;
using Business.Requests.Model;
using Business.Responses.CorporateCustomer;
using Business.Responses.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICorporateCustomerService
    {


        public GetCorporateCustomerByIdResponse GetById(GetCorporateCustomerByIdRequest request);

        public AddCorporateCustomerResponse Add(AddCorporateCustomerRequest request);

        public UpdateCorporateCustomerResponse Update(UpdateCorporateCustomerRequest request);

        public DeleteCorporateCustomerResponse Delete(DeleteCorporateCustomerRequest request);
    }
}
