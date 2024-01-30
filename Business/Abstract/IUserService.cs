using Business.Requests.Model;
using Business.Requests.User;
using Business.Responses.Model;
using Business.Responses.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        public GetUserByIdResponse GetById(GetUserByIdRequest request);

        public AddUserResponse Add(AddUserRequest request);

        public UpdateUserResponse Update(UpdateUserRequest request);

        public DeleteUserResponse Delete(DeleteUserRequest request);
    }
}
