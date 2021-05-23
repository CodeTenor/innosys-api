using System;
using System.Collections.Generic;

namespace innosys_domain
{
    public class Activity: Domain
    {
        public int ActivityId { get; set; }
        public string Description { get; set; }
        public string Client { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public int Duration { get; set; }
        public virtual List<Task> Tasks { get; set; }

        public Activity() { }

        public Activity(int id, string description, string client, DateTime startDate, DateTime dueDate, int duration): base()
        {
            ActivityId = id;
            Description = description;
            Client = client;
            StartDate = startDate;
            Duration = duration;
            DueDate = dueDate;
        }
    }
}
