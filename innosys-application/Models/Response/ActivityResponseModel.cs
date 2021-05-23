using innosys_domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace innosys_application.Models.Response
{
    public class ActivityResponseModel
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("activityId")]
        public int ActivityId { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("client")]
        public string Client { get; set; }

        [JsonProperty("startDate")]
        public DateTime StartDate { get; set; }

        [JsonProperty("dueDate")]
        public DateTime DueDate { get; set; }

        [JsonProperty("duration")]
        public int Duration { get; set; }

        [JsonProperty("tasks")]
        public List<TaskResponseModel> Tasks { get; set; }

        [JsonProperty("createdDate")]
        public DateTime CreatedDaste { get; set; }

        [JsonProperty("modifiedDate")]
        public DateTime ModifiedDate { get; set; }

        public ActivityResponseModel(Activity activity)
        {
            Id = activity.Id;
            ActivityId = activity.ActivityId;
            Description = activity.Description;
            Client = activity.Client;
            StartDate = activity.StartDate;
            DueDate = activity.DueDate;
            Duration = activity.Duration;
            CreatedDaste = activity.CreatedDate;
            ModifiedDate = activity.ModifiedDate;
            Tasks = activity.Tasks == null ? null : activity.Tasks.Select(x => new TaskResponseModel(x)).ToList();
        }
    }
}
