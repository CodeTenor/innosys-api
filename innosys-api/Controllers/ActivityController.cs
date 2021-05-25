using CsvHelper;
using CsvHelper.Configuration;
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
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, config))
            {
                request = csv.GetRecords<ActivityRequestModel>().ToList();
            }

            request.RemoveAt(0);

            List<ActivityResponseModel> response = _activityContract.AddActivites(request);

            return Ok(response);
        }

        [Route("export")]
        [HttpGet]
        public async Task<IActionResult> ExportActivitiesAsync()
        {
            string sqlScript = _activityContract.ExportSQLScript();

            string path = Directory.GetCurrentDirectory() + "sql-script.sql";

            using (StreamWriter writer = new StreamWriter(path, false))
            {
                writer.WriteLine(sqlScript);
            }

            var memory = new MemoryStream();

            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }

            memory.Position = 0;

            return File(memory, "application/sql", "sql-script.sql");
        }
    }
}