using AutoMapper;
using Business.Dtos.User;
using Business.Requests.User;
using Business.Responses.User;
using Entities.Persons;

namespace Business.Profiles.Mapping.AutoMapper
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            CreateMap<AddUserRequest, Users>();
            CreateMap<Users, AddUserResponse>();

            CreateMap<Users, UserListItemDto>();


            CreateMap<Users, DeleteUserResponse>();

            CreateMap<Users, GetUserByIdResponse>();

            CreateMap<UpdateUserRequest, Users>();
            CreateMap<Users, UpdateUserResponse>();
        }
    }
}
