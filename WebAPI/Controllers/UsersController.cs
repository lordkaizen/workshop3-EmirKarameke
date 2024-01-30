using Business.Abstract;
using Business.Requests.Model;
using Business.Responses.Model;
using Business;
using Microsoft.AspNetCore.Mvc;
using Business.Requests.User;
using Business.Responses.User;

namespace WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]

public class UsersController : Controller
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{Id}")] // GET http://localhost:5245/api/models/1
    public GetUserByIdResponse GetById([FromRoute] GetUserByIdRequest request)
    {
        GetUserByIdResponse response = _userService.GetById(request);
        return response;
    }

    [HttpPost] // POST http://localhost:5245/api/models
    public ActionResult<AddUserResponse> Add(AddUserRequest request)
    {
        AddUserResponse response = _userService.Add(request);
        return CreatedAtAction( // 201 Created
            actionName: nameof(GetById),
            routeValues: new { Id = response.Id }, // Anonymous object
                                                   // Response Header: Location=http://localhost:5245/api/models/1

            value: response // Response Body: JSON
        );
    }

    [HttpPut("{Id}")] // PUT http://localhost:5245/api/models/1
    public ActionResult<UpdateUserResponse> Update(
        [FromRoute] int Id,
        [FromBody] UpdateUserRequest request
    )
    {
        if (Id != request.Id)
            return BadRequest();

        UpdateUserResponse response = _userService.Update(request);
        return Ok(response);
    }

    [HttpDelete("{Id}")] // DELETE http://localhost:5245/api/models/1
    public DeleteUserResponse Delete([FromRoute] DeleteUserRequest request)
    {
        DeleteUserResponse response = _userService.Delete(request);
        return response;
    }
}
