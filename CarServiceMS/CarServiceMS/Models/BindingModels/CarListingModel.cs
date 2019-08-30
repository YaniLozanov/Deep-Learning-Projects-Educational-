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

        public string Password { get; set; }
    }
}
