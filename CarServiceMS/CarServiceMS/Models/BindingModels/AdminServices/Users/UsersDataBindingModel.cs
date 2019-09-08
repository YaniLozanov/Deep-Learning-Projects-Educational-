using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceMS.Models.BindingModels.AdminServices
{
    public class UsersDataBindingModel
    {
        public int Count { get; set; }

        public int OrdinaryCount { get; set; }
        public int AdminsCount { get; set; }
        public int BannedCount { get; set; }
    }
}
