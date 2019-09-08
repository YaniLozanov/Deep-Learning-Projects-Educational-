using CarServiceMS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceMS.Models.BindingModels
{
    public class UserBindingModel
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime MemberSince { get; set; }
        public string Role { get; set; }
        public IEnumerable<Car> Cars { get; set; }
    }
}
