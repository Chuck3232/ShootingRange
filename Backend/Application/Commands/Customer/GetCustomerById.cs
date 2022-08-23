using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Commands.Customer
{
    public class GetCustomerById
    {
        [JsonIgnore]
        public Guid CustomerId;
    }
}
