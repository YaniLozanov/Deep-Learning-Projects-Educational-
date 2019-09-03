using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceMS.Models.BindingModels
{
    public class UsersListingModel
    {
        public IEnumerable<UserBindingModel> Users { get; set; }
    }
}
