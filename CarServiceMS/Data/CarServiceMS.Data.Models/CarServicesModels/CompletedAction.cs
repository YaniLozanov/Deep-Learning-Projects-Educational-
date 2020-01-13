using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarServiceMS.Data.Models.CarServicesModels
{
    public class CompletedAction
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
