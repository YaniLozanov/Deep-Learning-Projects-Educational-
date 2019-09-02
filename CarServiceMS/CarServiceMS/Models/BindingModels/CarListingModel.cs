using CarServiceMS.Models.CarModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarServiceMS.Models.BindingModels
{
    public class CarListingModel
    {
        public IEnumerable<CarBindingModel> Cars { get; set; }

        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [RegularExpression(@"(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$", ErrorMessage = "Invalid Password Format!")]
        public string Password { get; set; }
    }
}

