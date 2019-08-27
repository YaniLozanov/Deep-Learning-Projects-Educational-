using CarServiceMS.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarServiceMS.Models.CarModels
{
    public class CarBindingModel
    {
   
        [Required]
        [RegularExpression("^[А-Я]{1,2}[0-9]{4}(([A-Я]{1,2})|([0-9]{1,2}))$", ErrorMessage = "Invalid Car Number!")]
        public string Number { get; set; }
        [Required]
        public string Brand { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public DateTime YearFrom { get; set; }
        [Required]
        public DateTime RegistredOn { get; set; }

        public ApplicationUser Owner { get; set; }

        public virtual IEnumerable<Manipulation> Manipulations { get; set; }
    }
}
