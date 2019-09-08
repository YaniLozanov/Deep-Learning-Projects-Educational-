using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceMS.Models.BindingModels.AdminServices
{
    public class CarsDataBindingModel
    {
        public int Count { get; set; }

        public int InPrcessCount { get; set; }
        public int ReadyCount { get; set; }
        public int WaitingCount { get; set; }

    }
}
