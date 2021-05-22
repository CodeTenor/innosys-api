using System;

namespace innosys_application.Models.Request
{
    public class ActivityRequestModel
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string Client { get; set; }
        public string StartDate { get; set; }
        public string Duration { get; set; }
        public string Task1 { get; set; }
        public string Task2 { get; set; }
        public string Task3 { get; set; }
        public string Task4 { get; set; }
        public string Task5 { get; set; }
    }
}
