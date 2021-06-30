using innosys_domain;
using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace innosys_application.Models.Response
{
    public record ResponseModel<T> where T: Domain
    {
        [JsonProperty("id", Order = -2)]
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
