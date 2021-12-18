using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Commands.User
{
    public class DeleteUser
    {
        [JsonIgnore]
        public Guid UserId { get; set; }
    }
}
