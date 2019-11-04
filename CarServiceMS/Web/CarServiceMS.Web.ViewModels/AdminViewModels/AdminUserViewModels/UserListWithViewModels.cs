using System.Collections.Generic;

namespace CarServiceMS.Web.ViewModels.AdminViewModels.AdminUserViewModels
{
    public class UserListWithViewModels
    {
        public IEnumerable<UserListingViewModel> Users { get; set; }
    }
}
