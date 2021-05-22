using CsvHelper;
using innosys_application.IContracts;
using innosys_application.Models.Request;
using innosys_application.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace innosys_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : Controller
    {
        private readonly IActivityContract _activityContract;

        public ActivityController(IActivityContract activityContract)
        {
            _activityContract = activityContract;
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetActivityById(Guid id)
        {
            ActivityResponseModel response = _activityContract.GetActivityById(id);

            return Ok(response);
        }

        [Route("")]
        [HttpGet]
        public IActionResult GetAllActivities()
        {
            List<ActivityResponseModel> response = _activityContract.GetAllActivities();

            return Ok(response);
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> AddActivityByCSVFileAsync(IFormFile filename)
        {
            var filePath = Path.GetTempFileName();

            using (var stream = System.IO.File.Create(filePath))
            {
                await filename.CopyToAsync(stream);
            }

            List<ActivityRequestModel> request;

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                request = csv.GetRecords<ActivityRequestModel>().ToList();
            }

            List<ActivityResponseModel> response = _activityContract.AddActivites(request);

            return Ok(response);
        }
    }
}
