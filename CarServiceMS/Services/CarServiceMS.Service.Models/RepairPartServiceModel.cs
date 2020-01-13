using System;
using System.Collections.Generic;
using System.Text;

namespace CarServiceMS.Service.Models
{
    public class RepairPartServiceModel
    {
        public int Id { get; set; }

        public int Quantity { get; set; }
        public string PartNumber { get; set; }

        public string PartDescription { get; set; }

        public decimal UnitPrice { get; set; }
        public decimal TotalPrice => this.UnitPrice * Quantity;

        public DateTime PurchaseDate { get; set; }

        public RepairServiceModel Repair { get; set; }
    }
}
