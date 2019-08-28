using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarServiceMS.Data.Models
{
    public class Car
    {
        [Required]
        public int Id { get; set; }

        [Required]       
        public string Number { get; set; }
        [Required]
        public string Brand { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public DateTime YearFrom { get; set; }

        [Required]
        public DateTime RegistredOn { get; set; }

        [Required]
        public ApplicationUser Owner { get; set; }

        public virtual IEnumerable<Manipulation> Manipulations { get; set; }


    }
}
