using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class EntryRecordDto
    {
        public Guid Id { get; set; }
        public string DateEntry { get; set; }
        public Guid CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        #nullable enable
        public string? FirearmsLicense { get; set; }
        #nullable enable
        public string? Adress { get; set; }
        #nullable enable
        public string? DateExit { get; set; }
    }
}
