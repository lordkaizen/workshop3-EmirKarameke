using Business.Abstract;
using Business.Requests.CorporateCustomer;
using Business.Requests.IndividualCustomer;
using Business.Responses.CorporateCustomer;
using Business.Responses.IndividualCustomer;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndividualCustomerController : Controller
    {
        private readonly IIndividualCustomerService _individualcustomerService;

        public IndividualCustomerController(IIndividualCustomerService individualcustomerService)
        {
            _individualcustomerService = individualcustomerService;
        }

        [HttpGet] // GET http://localhost:5245/api/Customer


        [HttpGet("{Id}")] // GET http://localhost:5245/api/Customer/1
        public GetIndividualCustomerByIdResponse GetById([FromRoute] GetIndividualCustomerByIdRequest request)
        {
            GetIndividualCustomerByIdResponse response = _individualcustomerService.GetById(request);
            return response;
        }

        [HttpPost] // POST http://localhost:5245/api/Customer
        public ActionResult<AddIndividualCustomerResponse> Add(AddIndividualCustomerRequest request)
        {
            AddIndividualCustomerResponse response = _individualcustomerService.Add(request);
            return CreatedAtAction( // 201 Created
                actionName: nameof(GetById),
                routeValues: new { Id = response.Id },
                value: response // Response Body: JSON
            );
        }

        [HttpPut("{Id}")] // PUT http://localhost:5245/api/Customer/1
        public ActionResult<UpdateIndividualCustomerResponse> Update(
            [FromRoute] int Id,
            [FromBody] UpdateIndividualCustomerRequest request
        )
        {
            if (Id != request.Id)
                return BadRequest();

            UpdateIndividualCustomerResponse response = _individualcustomerService.Update(request);
            return Ok(response);
        }

        [HttpDelete("{Id}")] // DELETE http://localhost:5245/api/models/1
        public DeleteIndividualCustomerResponse Delete([FromRoute] DeleteIndividualCustomerRequest request)
        {
            DeleteIndividualCustomerResponse response = _individualcustomerService.Delete(request);
            return response;
        }
    }
}
