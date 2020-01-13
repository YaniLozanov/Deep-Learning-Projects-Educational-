using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarServiceMS.Data.Models.CarServicesModels
{
    public abstract class CarServiceAbstractModel
    {
        [Key]
        public int Id { get; set; }
        public int JobNum => this.Id;
        public int CurrentKilometers { get; set; }

        public decimal PartsTotalPrice { get; set; }
        public decimal ActionsTotalPrice { get; set; }
        public decimal Total => this.PartsTotalPrice + this.ActionsTotalPrice;

        public DateTime Date => DateTime.Now;
        public DateTime DateIn { get; set; }
        public DateTime DateOut { get; set; }
        public DateTime JobDate { get; set; }

        public string PlusDescription { get; set; }

        public Car Car { get; set; }
        public IEnumerable<CompletedAction> CompletedActions { get; set; }


    }
}
