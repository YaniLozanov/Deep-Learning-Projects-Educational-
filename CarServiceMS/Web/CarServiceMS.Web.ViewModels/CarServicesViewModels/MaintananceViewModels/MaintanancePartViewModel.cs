using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarServiceMS.Web.ViewModels.CarServicesViewModels.MaintananceViewModels
{
    public class MaintanancePartViewModel
    {

        public int Id { get; set; }
        public int PartNumber { get; set; }

        public int Quantity { get; set; }
        public string PartDescription { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice => this.UnitPrice * Quantity;
        public DateTime PurchaseDate { get; set; }
    }
}
