using CarServiceMS.Models.CarModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceMS.Models.BindingModels
{
    public class CarListingModel
    {
        public IEnumerable<CarBindingModel> Cars { get; set; }
    }
}
