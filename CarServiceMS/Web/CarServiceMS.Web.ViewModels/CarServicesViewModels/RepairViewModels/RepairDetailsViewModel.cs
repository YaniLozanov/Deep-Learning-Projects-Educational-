using CarServiceMS.Web.ViewModels.CarViewModels;
using System;
using System.Collections.Generic;


namespace CarServiceMS.Web.ViewModels.CarServicesViewModels.RepairViewModels
{
    public class RepairDetailsViewModel
    {
        public int Id { get; set; }
        public int JobNum { get; set; }
        public int CurrentKilometers { get; set; }

        public decimal PartsTotalPrice { get; set; }
        public decimal ActionsTotalPrice { get; set; }
        public decimal Total => this.PartsTotalPrice + this.ActionsTotalPrice;

        public DateTime Date { get; set; }
        public DateTime DateIn { get; set; }
        public DateTime DateOut { get; set; }
        public DateTime JobDate { get; set; }

        public string PlusDescription { get; set; }

        public CarViewModel Car { get; set; }
        public IEnumerable<CompletedActionViewModel> CompletedActions { get; set; }

        public IEnumerable<RepairPartViewModel> Parts { get; set; }

        public IEnumerable<ReportedDefectViewModel> ReportedDefects { get; set; }
    }
}
