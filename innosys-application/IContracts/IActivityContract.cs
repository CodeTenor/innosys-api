using innosys_application.Models.Request;
using innosys_application.Models.Response;
using System;
using System.Collections.Generic;

namespace innosys_application.IContracts
{
    public interface IActivityContract
    {
        ActivityResponseModel GetActivityById(Guid activityId);
        List<ActivityResponseModel> GetAllActivities();
        List<ActivityResponseModel> AddActivites(List<ActivityRequestModel> requestModels);
        string ExportSQLScript();
    }
}
