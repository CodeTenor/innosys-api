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

        public Activity(int id, string description, string client, DateTime startDate, int duration): base()
        {
            ActivityId = id;
            Description = description;
            Client = client;
            StartDate = startDate;
            DueDate = CalculateDueDate();
            Duration = duration;
        }

        private DateTime CalculateDueDate()
        {
            // this is where ill have the business rules for calulating due date
            // business hours 08:30 -16:00
            // Monday to friday
            // using a random date 
            return DateTime.UtcNow;
        }
    }
}
