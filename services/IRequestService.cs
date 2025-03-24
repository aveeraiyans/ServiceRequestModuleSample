using ServiceRequestModule.Model;

namespace ServiceRequestModule.services
{
    public interface IRequestService
    {
        List<ServiceRequest> GetAllRequests();

        ServiceRequest? GetRequestsByID(Guid id);

        ServiceRequest AddRequest(AddUpdateServiceRequest obj);

        ServiceRequest? UpdateRequestByID(Guid id, AddUpdateServiceRequest obj);

        bool DeleteRequestsByID(Guid id);
    }
}
