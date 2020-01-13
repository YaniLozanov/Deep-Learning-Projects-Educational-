using CarServiceMS.Web.ViewModels.AdminViewModels.AdminUserViewModels;
using System;

namespace CarServiceMS.Web.ViewModels.CarViewModels
{
    public class CarViewModel
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime YearFrom { get; set; }
        public DateTime RegistredOn { get; set; }

        public UserListingViewModel Owner { get; set; }
    }
}
