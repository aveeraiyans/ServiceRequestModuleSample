using ServiceRequestModule.Model;
using System.Collections.Generic;

namespace ServiceRequestModule.services
{
    public class RequestService : IRequestService
    {
        private readonly List<ServiceRequest> _requestsList;
        public RequestService()
        {
            _requestsList = new List<ServiceRequest>()
            {
                new ServiceRequest(){
                id = Guid.NewGuid(),
                buildingCode = "COH",
                description = "Please turn up the AC in suite 1200D. It is too hot here.",
                currentStatus = _currentStatus.Created,
                createdBy = "Ashvin Ravishankar",
                createdDate = DateTime.Now,
                lastModifiedBy = "Jane Doe",
                lastModifiedDate = DateTime.Now
                }
            };
        }

        public List<ServiceRequest> GetAllRequests()
        {
            return _requestsList.ToList();
        }

        public ServiceRequest? GetRequestsByID(Guid id)
        {
            return _requestsList.FirstOrDefault(request => request.id == id);
        }

        public ServiceRequest AddRequest(AddUpdateServiceRequest obj)
        {
            var AddUpdateServiceRequest = new ServiceRequest()
            {
                id = obj.Id,
                buildingCode = obj.BuildingCode,
                description = obj.Description,
                currentStatus = obj.currentStatus,
                createdBy = obj.CreatedBy,
                createdDate = obj.CreatedDate,
                lastModifiedBy = obj.LastModifiedBy,
                lastModifiedDate = obj.LastModifiedDate
            };

            _requestsList.Add(AddUpdateServiceRequest);

            return AddUpdateServiceRequest;
        }

        public ServiceRequest? UpdateRequestByID(Guid id, AddUpdateServiceRequest obj)
        {
            
            if (obj.Id is not null)
            {
                var requestToUpdate = _requestsList.Find(request => request.id == id);

                _requestsList.Remove(requestToUpdate);

                requestToUpdate.buildingCode = obj.BuildingCode;
                requestToUpdate.description = obj.Description;
                requestToUpdate.currentStatus = obj.currentStatus;
                requestToUpdate.createdBy = obj.CreatedBy;
                requestToUpdate.createdDate = obj.CreatedDate;
                requestToUpdate.lastModifiedBy = obj.LastModifiedBy;
                requestToUpdate.lastModifiedDate = obj.LastModifiedDate;

                _requestsList.Add(requestToUpdate);
                return requestToUpdate;
            }
            else
            {
                return null;
            }
        }
        public bool DeleteRequestsByID(Guid id)
        {
            var requestToDelete = _requestsList.Find(request => request.id == id);

            _requestsList.Remove(requestToDelete);

            return true;
        }
    }
}
