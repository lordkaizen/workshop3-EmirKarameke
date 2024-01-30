using Business.Abstract;
using Business.Requests.Model;
using Business.Responses.Model;
using Business;
using Microsoft.AspNetCore.Mvc;
using Business.Responses.Customer;
using Business.Requests.Customer;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet] // GET http://localhost:5245/api/Customer


        [HttpGet("{Id}")] // GET http://localhost:5245/api/Customer/1
        public GetCustomerByIdResponse GetById([FromRoute] GetCustomerByIdRequest request)
        {
            GetCustomerByIdResponse response = _customerService.GetById(request);
            return response;
        }

        [HttpPost] // POST http://localhost:5245/api/Customer
        public ActionResult<AddCustomerResponse> Add(AddCustomerRequest request)
        {
            AddCustomerResponse response = _customerService.Add(request);
            return CreatedAtAction( // 201 Created
                actionName: nameof(GetById),
                routeValues: new { Id = response.Id }, 
                value: response // Response Body: JSON
            );
        }

        [HttpPut("{Id}")] // PUT http://localhost:5245/api/Customer/1
        public ActionResult<UpdateCustomerResponse> Update(
            [FromRoute] int Id,
            [FromBody] UpdateCustomerRequest request
        )
        {
            if (Id != request.Id)
                return BadRequest();

            UpdateCustomerResponse response = _customerService.Update(request);
            return Ok(response);
        }

        [HttpDelete("{Id}")] // DELETE http://localhost:5245/api/models/1
        public DeleteCustomerResponse Delete([FromRoute] DeleteCustomerRequest request)
        {
            DeleteCustomerResponse response = _customerService.Delete(request);
            return response;
        }
    }
}
