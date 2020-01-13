using System;
using System.ComponentModel.DataAnnotations;

namespace CarServiceMS.Data.Models
{
    public class RepairPart
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Quantity { get; set; }
        public string PartNumber { get; set; }


        [Required]
        public string PartDescription { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice => this.UnitPrice * Quantity;

        public DateTime PurchaseDate { get; set; }

        public Repair Repair { get; set; }
    }
}
