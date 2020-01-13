using System;
using System.ComponentModel.DataAnnotations;

namespace CarServiceMS.Data.Models.CarServicesModels.MaintenanceModels
{
    public class MaintenancePart
    {
        [Key]
        public int Id { get; set; }
        public int PartNumber { get; set; }
        [Required]
        public int Quantity { get; set; }

        [Required]
        public string PartDescription { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice => this.UnitPrice * Quantity;

        public DateTime PurchaseDate { get; set; }

        public Maintenance Maintenance { get; set; }
    }
}
