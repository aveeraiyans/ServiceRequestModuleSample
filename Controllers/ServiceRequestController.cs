using ServiceRequestModule.Model;
using ServiceRequestModule.services;
using Microsoft.AspNetCore.Mvc;

namespace ServiceRequestModule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceRequestController : ControllerBase
    {
        private readonly IRequestService _requestService;

        public ServiceRequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var requests = _requestService.GetAllRequests();

            if (requests == null)
            {
                return NotFound();
            }
            return Ok(requests);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(Guid id)
        {
            var request = _requestService.GetRequestsByID(id);
            if (request == null)
            {
                return NotFound();
            }
            return Ok(request);
        }

        [HttpPost]
        public IActionResult Post(AddUpdateServiceRequest requestObject)
        {
            var request = _requestService.AddRequest(requestObject);

            if (request == null)
            {
                return BadRequest();
            }

            return Ok(new
            {
                message = "Request Created Successfully!!!",
                id = request!.id
            });
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put([FromRoute] Guid id, [FromBody] AddUpdateServiceRequest requestObject)
        {
            var request = _requestService.UpdateRequestByID(id, requestObject);
            if (request == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                message = "Request Updated Successfully!!!",
                id = request!.id
            });
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            if (!_requestService.DeleteRequestsByID(id))
            {
                return NotFound();
            }

            return Ok(new
            {
                message = "Request Deleted Successfully!!!",
                id = id
            });
        }
    }
}
