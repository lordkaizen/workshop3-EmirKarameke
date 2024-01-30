using Business.Abstract;
using Business.Requests.CorporateCustomer;
using Business.Requests.Customer;
using Business.Responses.CorporateCustomer;
using Business.Responses.Customer;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorporateCustomerController : Controller
    {
        private readonly ICorporateCustomerService _corporatecustomerService;

        public CorporateCustomerController(ICorporateCustomerService corporatecustomerService)
        {
            _corporatecustomerService = corporatecustomerService;
        }

        [HttpGet] // GET http://localhost:5245/api/Customer


        [HttpGet("{Id}")] // GET http://localhost:5245/api/Customer/1
        public GetCorporateCustomerByIdResponse GetById([FromRoute] GetCorporateCustomerByIdRequest request)
        {
            GetCorporateCustomerByIdResponse response = _corporatecustomerService.GetById(request);
            return response;
        }

        [HttpPost] // POST http://localhost:5245/api/Customer
        public ActionResult<AddCorporateCustomerResponse> Add(AddCorporateCustomerRequest request)
        {
            AddCorporateCustomerResponse response = _corporatecustomerService.Add(request);
            return CreatedAtAction( // 201 Created
                actionName: nameof(GetById),
                routeValues: new { Id = response.Id },
                value: response // Response Body: JSON
            );
        }

        [HttpPut("{Id}")] // PUT http://localhost:5245/api/Customer/1
        public ActionResult<UpdateCorporateCustomerResponse> Update(
            [FromRoute] int Id,
            [FromBody] UpdateCorporateCustomerRequest request
        )
        {
            if (Id != request.Id)
                return BadRequest();

            UpdateCorporateCustomerResponse response = _corporatecustomerService.Update(request);
            return Ok(response);
        }

        [HttpDelete("{Id}")] // DELETE http://localhost:5245/api/models/1
        public DeleteCorporateCustomerResponse Delete([FromRoute] DeleteCorporateCustomerRequest request)
        {
            DeleteCorporateCustomerResponse response = _corporatecustomerService.Delete(request);
            return response;
        }
    }
}
