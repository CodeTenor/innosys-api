using innosys_domain;
using Newtonsoft.Json;
using System;

namespace innosys_application.Models.Response
{
    public record ResponseModel<T> where T: Domain
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }

        [JsonProperty("modifiedDate")]
        public DateTime ModifiedDate { get; set; }

        public ResponseModel(T t)
        {
            Id = t.Id;
            CreatedDate = t.CreatedDate;
            ModifiedDate = t.ModifiedDate;
        }
    }
}
