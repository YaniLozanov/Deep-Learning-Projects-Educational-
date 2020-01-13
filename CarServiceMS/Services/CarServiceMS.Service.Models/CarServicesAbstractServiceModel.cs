using System;
using System.Collections.Generic;

namespace CarServiceMS.Service.Models
{
    public class CarServicesAbstractServiceModel
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

        public CarServiceModel Car { get; set; }
        public IEnumerable<CompletedActionServiceModel> CompletedActions { get; set; }

    }
}
