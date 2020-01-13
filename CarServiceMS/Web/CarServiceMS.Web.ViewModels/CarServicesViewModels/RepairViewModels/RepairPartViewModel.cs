using CarServiceMS.Web.ViewModels.CarViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarServiceMS.Web.ViewModels.CarServicesViewModels.RepairViewModels
{
    public class RepairPartViewModel
    {
        public int Id { get; set; }

        public int Quantity { get; set; }
        public string PartNumber { get; set; }

        public string PartDescription { get; set; }

        public decimal UnitPrice { get; set; }
        public decimal TotalPrice => this.UnitPrice * Quantity;

        public DateTime PurchaseDate { get; set; }

    }
}
