using CarServiceMS.Data.Attributes;
using CarServiceMS.Data.Models;
using CarServiceMS.Service.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarServiceMS.Web.InputModels.AdminInputModels.AdminUserInputModels
{
    public class UserCarCreateInputModel
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression("^[А-ЯA-Z]{1,2}[А-ЯA-Z0-9]{2,6}$", ErrorMessage = "Invalid Number!")]
        [CarNumberUnique]
        public string Number { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public DateTime YearFrom { get; set; }
        [Required]
        public DateTime RegistredOn { get; set; } = DateTime.Now;

        public ApplicationUserServiceModel Owner { get; set; }

       // public virtual IEnumerable<Manipulation> Manipulations { get; set; }
    }
}
