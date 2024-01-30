using AutoMapper;
using Business.Dtos.Customer;
using Business.Requests.Customer;
using Business.Responses.Customer;
using Entities.Persons;

namespace Business.Profiles.Mapping.AutoMapper
{
    public class CustomerMapperProfile : Profile
    {
        public CustomerMapperProfile()
        {
            CreateMap<AddCustomerRequest, Customers>();
            CreateMap<Customers, AddCustomerResponse>();

            CreateMap<Customers, CustomerListItemDto>();


            CreateMap<Customers, DeleteCustomerResponse>();

            CreateMap<Customers, GetCustomerByIdResponse>();

            CreateMap<UpdateCustomerRequest, Customers>();
            CreateMap<Customers, UpdateCustomerResponse>();
        }
    }
}
