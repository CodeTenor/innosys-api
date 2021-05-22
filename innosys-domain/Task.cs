using System;

namespace innosys_domain
{
    public class Task: Domain
    {
        public virtual Activity Activity { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public DateTime? CompletedDate { get; set; }

        public Task() { }

        public Task(Activity activity, string description)
        {
            Activity = activity;
            Description = description;
            Status = false;
        }

        public void CompleteTask()
        {
            Status = true;
            CompletedDate = DateTime.UtcNow;
        }
    }
}
