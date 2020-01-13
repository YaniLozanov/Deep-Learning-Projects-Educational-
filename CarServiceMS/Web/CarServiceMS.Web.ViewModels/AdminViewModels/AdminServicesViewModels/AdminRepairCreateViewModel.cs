using CarServiceMS.Web.ViewModels.CarServicesViewModels.RepairViewModels;
using CarServiceMS.Web.ViewModels.CarViewModels;
using System;
using System.Collections.Generic;

namespace CarServiceMS.Web.ViewModels.AdminViewModels.AdminServicesViewModels
{
    public class AdminRepairCreateViewModel
    {

        public int Id { get; set; }
        public int JobNum => this.Id;
        public int CurrentKilometers { get; set; }

        public decimal PartsTotalPrice { get; set; }
        public decimal ActionsTotalPrice { get; set; }
        public decimal Total => this.PartsTotalPrice + this.ActionsTotalPrice;

        public DateTime Date { get; set; }
        public DateTime DateIn { get; set; }
        public DateTime DateOut { get; set; }
        public DateTime JobDate { get; set; }
        public DateTime YearFrom { get; set; }

        public string Model { get; set; }
        public string Brand { get; set; }
        public string PlusDescription { get; set; }
        public string CarRegistrationNumber { get; set; }

        public CarViewModel Car { get; set; }
        public IEnumerable<AdminCompletedActionViewModel> CompletedActions { get; set; }
        public IEnumerable<AdminReportedDefectViewModel> ReportedDefects { get; set; }
        public IEnumerable<RepairPartViewModel> Parts { get; set; }
    }
}
