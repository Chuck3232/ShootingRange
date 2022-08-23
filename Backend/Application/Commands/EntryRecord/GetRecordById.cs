using System;
using System.Text.Json.Serialization;

namespace Application.Commands.EntryRecord
{
    public class GetRecordById
    {
        [JsonIgnore]
        public Guid Id { get; set; }
    }
}
