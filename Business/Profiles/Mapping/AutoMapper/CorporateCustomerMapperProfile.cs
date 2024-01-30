using AutoMapper;
using Business.Dtos.CorporateCustomer;
using Business.Requests.CorporateCustomer;
using Business.Requests.Model;
using Business.Responses.CorporateCustomer;
using Business.Responses.Model;
using Entities.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles.Mapping.AutoMapper
{
    public class CorporateCustomerMapperProfile : Profile 
    {

        public CorporateCustomerMapperProfile()
        {
            CreateMap<AddCorporateCustomerRequest, CorporateCustomers>();
            CreateMap<CorporateCustomers, AddCorporateCustomerResponse>();

            CreateMap<CorporateCustomers, CorporateCustomerListItemDto>();
            

            CreateMap<CorporateCustomers, DeleteCorporateCustomerResponse>();

            CreateMap<CorporateCustomers, GetCorporateCustomerByIdResponse>();

            CreateMap<UpdateCorporateCustomerRequest, CorporateCustomers>();
            CreateMap<CorporateCustomers, UpdateCorporateCustomerResponse>();
        }
    }
}
