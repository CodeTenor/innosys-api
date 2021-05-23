using innosys_domain;
using Newtonsoft.Json;
using System;
using System.Text.Json.Serialization;

namespace innosys_application.Models.Response
{
    public class TaskResponseModel
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("completedDate")]
        [System.Text.Json.Serialization.JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? CompletedDate { get; set; }

        public TaskResponseModel(Task task)
        {
            Id = task.Id;
            Description = task.Description;
            Status = task.Status;
            CompletedDate = task.CompletedDate;
        }
    }
}
