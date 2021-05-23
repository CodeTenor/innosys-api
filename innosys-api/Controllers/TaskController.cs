using innosys_application.IContracts;
using innosys_application.Models.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace innosys_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : Controller
    {
        private readonly ITaskContract _taskContract;

        public TaskController(ITaskContract taskContract)
        {
            _taskContract = taskContract;
        }

        [Route("{id}")]
        [HttpPost]
        public IActionResult CompleteTask(Guid id)
        {
            TaskResponseModel response = _taskContract.CompleteTask(id);

            return Ok(response);
        }
    }
}
