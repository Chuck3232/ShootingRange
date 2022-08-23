using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class OrderDto
    {
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
        public string LastName { get; set; }
        public string SpotDistance { get; set; }
        public IEnumerable<WeaponInOrder> Weapons { get; set; }
        public IEnumerable<AmmoOrderDto> AmmoOrders { get; set; }
        public string Status { get; set; }
        public int TrainigHours { get; set; }
        public bool IsInstructor { get; set; }
        public float Price { get; set; }
        public DateTime Date { get; set; }
    }
}
