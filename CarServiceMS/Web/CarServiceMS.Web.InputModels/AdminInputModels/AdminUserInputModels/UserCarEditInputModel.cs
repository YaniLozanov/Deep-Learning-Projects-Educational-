using System;
using System.ComponentModel.DataAnnotations;

namespace CarServiceMS.Web.InputModels.AdminInputModels.AdminUserInputModels
{
    public class UserCarEditInputModel
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression("^[А-ЯA-Z]{1,2}[А-ЯA-Z0-9]{2,6}$", ErrorMessage = "Invalid Number!")]
        public string Number { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public DateTime YearFrom { get; set; }
    }
}
