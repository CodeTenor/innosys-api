using innosys_application.IContracts;
using innosys_application.Models.Request;
using innosys_application.Models.Response;
using System;
using System.Collections.Generic;

namespace innosys_application.Contracts
{
    public class ActivityContract : IActivityContract
    {
        public List<ActivityResponseModel> AddActivites(List<ActivityRequestModel> requestModels)
        {
            throw new NotImplementedException();
        }

        public ActivityResponseModel GetActivityById(Guid activityId)
        {
            throw new NotImplementedException();
        }

        public List<ActivityResponseModel> GetAllActivities()
        {
            throw new NotImplementedException();
        }
    }
}
