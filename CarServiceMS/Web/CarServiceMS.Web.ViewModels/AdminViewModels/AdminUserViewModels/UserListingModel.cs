using CarServiceMS.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarServiceMS.Web.ViewModels.AdminViewModels.AdminUserViewModels
{
    public class UserListingViewModel
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime MemberSince { get; set; }
        public string Role { get; set; }
        public IEnumerable<CarServiceModel> Cars { get; set; }
    }
}
