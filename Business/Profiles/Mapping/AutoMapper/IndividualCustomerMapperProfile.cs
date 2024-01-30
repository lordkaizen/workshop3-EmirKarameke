using AutoMapper;
using Business.Dtos.IndividualCustomer;
using Business.Requests.IndividualCustomer;
using Business.Requests.Model;
using Business.Responses.IndividualCustomer;
using Business.Responses.Model;
using Entities.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles.Mapping.AutoMapper;

public class IndividualCustomerMapperProfile: Profile
{
    public IndividualCustomerMapperProfile() 
    {
        CreateMap<AddIndividualCustomerRequest, IndividualCustomers>();
        CreateMap<IndividualCustomers, AddIndividualCustomerResponse>();

        CreateMap<IndividualCustomers, IndividualCustomerListItemDto>();

        CreateMap<IndividualCustomers, DeleteIndividualCustomerResponse>();

        CreateMap<IndividualCustomers, GetIndividualCustomerByIdResponse>();

        CreateMap<UpdateIndividualCustomerRequest, IndividualCustomers>();
        CreateMap<IndividualCustomers, UpdateIndividualCustomerResponse>();
    }
}
