using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.User;
using Business.Responses.Model;
using Business.Responses.User;
using DataAccess.Abstract;
using DataAccess.Abstract.Person;
using DataAccess.Concrete.EntityFramework;
using Entities.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly UserBusinessRules _userBusinessRules;
        private readonly IMapper _mapper;

        public UserManager(IUserDal userDal, UserBusinessRules userBusinessRules, IMapper mapper)
        {
            _userDal = userDal;
            _userBusinessRules = userBusinessRules;
            _mapper = mapper;
        }
        public AddUserResponse Add(AddUserRequest request)
        {

            var userToAdd = _mapper.Map<Users>(request);

            // data operations
            Users addedUser = _userDal.Add(userToAdd);

            // mapping & response
            var response = _mapper.Map<AddUserResponse>(addedUser);
            return response;
        }

        public DeleteUserResponse Delete(DeleteUserRequest request)
        {
            Users? userToDelete = _userDal.Get(predicate: user => user.Id == request.Id); // 0x123123
            _userBusinessRules.CheckIfUserExists(userToDelete); // 0x123123

            Users deletedUser = _userDal.Delete(userToDelete!); // 0x123123

            var response = _mapper.Map<DeleteUserResponse>(
                deletedUser // 0x123123
            );
            return response;
        }

        public GetUserByIdResponse GetById(GetUserByIdRequest request)
        {
            Users? user = _userDal.Get(predicate: user => user.Id == request.Id);
            _userBusinessRules.CheckIfUserExists(user);

            var response = _mapper.Map<GetUserByIdResponse>(user);
            return response;
        }

        public UpdateUserResponse Update(UpdateUserRequest request)
        {
            Users? userToUpdate = _userDal.Get(predicate: user => user.Id == request.Id); // 0x123123
            _userBusinessRules.CheckIfUserExists(userToUpdate);
            userToUpdate = _mapper.Map(request, userToUpdate); 
            Users updatedUser = _userDal.Update(userToUpdate!); 

            var response = _mapper.Map<UpdateUserResponse>(
                updatedUser 
            );
            return response;
        }
    }
}
