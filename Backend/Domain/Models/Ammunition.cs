using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Ammunition
    {
        public Guid Id { get; set; }
        public string Caliber { get; set; }
        public string Producer { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public int QuantityInStock { get; set; }

        public Ammunition(string caliber, string producer, float price, int quantity, int quantityInStock)
        {
            Id = Guid.NewGuid();
            SetCaliber(caliber);
            SetProducer(producer);
            Price = price;
            Quantity = quantity;
            QuantityInStock = quantityInStock;
        }
        public Ammunition()
        {
        }
        public void SetCaliber(string caliber)
        {
            if (string.IsNullOrWhiteSpace(caliber))
            {
                throw new Exception("Caliber cannot be empty.");
            }
            Caliber = caliber;
        }
        public void SetProducer(string producer)
        {
            if (string.IsNullOrWhiteSpace(producer))
            {
                throw new Exception("Producer cannot be empty.");
            }
            Producer = producer;
        }
    }
}
