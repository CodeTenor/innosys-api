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
            Duration = duration;
            DueDate = CalculateDueDate();
        }

        private DateTime CalculateDueDate()
        {
            double durationInMinutes = this.Duration * 60;
            this.DueDate = this.StartDate;

            while (durationInMinutes >= 0)
            {
                DateTime endOfDayDateTime = this.DueDate.Date + new TimeSpan(16, 0, 0);
                var differenceInMintues = endOfDayDateTime.Subtract(this.DueDate).TotalMinutes;

                if (differenceInMintues < durationInMinutes)
                {
                    this.DueDate =  this.DueDate.AddDays(1);

                    while(this.DueDate.DayOfWeek == DayOfWeek.Saturday || this.DueDate.DayOfWeek == DayOfWeek.Sunday)
                    {
                        this.DueDate = this.DueDate.AddDays(1);
                    }

                    this.DueDate = this.DueDate.Date + new TimeSpan(8, 30, 0);
                }
                else
                {
                    int minutesToHours = Convert.ToInt32(durationInMinutes / 60);

                    this.DueDate = this.DueDate.AddHours(minutesToHours);
                }

                durationInMinutes = durationInMinutes - differenceInMintues;
            }
            // this is where ill have the business rules for calulating due date
            // this is where ill have the business rules for calulating due date
            // business hours 08:30 -16:00
            // Monday to friday
            // using a random date 
            return this.DueDate;
        }
    }
}
