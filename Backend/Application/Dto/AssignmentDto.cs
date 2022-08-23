using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class AssignmentDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public bool InstuctorInSpot { get; set; }
        #nullable enable
        public string? CustomerLicense { get; set; }
        public Guid? WeaponId { get; set; }
        public string? WeaponName { get; set; }
        public bool? WeaponStatus { get; set; }
        public Guid? WeaponInSpotId { get; set; }
        public string? WeaponInSpot { get; set; }      
        public Guid? AmmoId { get; set; }
        public string? AmmoName { get; set; }
        public int? AmmoQuant { get; set; }
        public Guid? AmmoInSpotId { get; set; }
        public string? AmmoInSpot { get; set; }
        public bool? Instuctor { get; set; }
        

    }
}
