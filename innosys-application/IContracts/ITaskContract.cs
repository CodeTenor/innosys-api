using innosys_application.Models.Response;
using System;

namespace innosys_application.IContracts
{
    public interface ITaskContract
    {
        TaskResponseModel CompleteTask(Guid taskId);
    }
}
