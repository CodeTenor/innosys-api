using innosys_domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace innosys_application.Models.Response
{
    public record ActivityResponseModel: ResponseModel<Activity>
    {
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

        public ActivityResponseModel(Activity activity): base(activity)
        {
            ActivityId = activity.ActivityId;
            Description = activity.Description;
            Client = activity.Client;
            StartDate = activity.StartDate;
            DueDate = activity.DueDate;
            Duration = activity.Duration;
            Tasks = activity.Tasks == null ? null : activity.Tasks.Select(x => new TaskResponseModel(x)).ToList();
        }
    }
}
