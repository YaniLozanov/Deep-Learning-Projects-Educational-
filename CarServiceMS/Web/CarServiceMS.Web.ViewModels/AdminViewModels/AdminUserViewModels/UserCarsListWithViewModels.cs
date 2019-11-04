using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarServiceMS.Web.ViewModels.AdminViewModels.AdminUserViewModels
{
    public class UserCarsListWithViewModels
    {
        public IEnumerable<UserCarsListingViewModel> Cars { get; set; }

        public string Username { get; set; }

        public string UserId { get; set; }


        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [RegularExpression(@"(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$", ErrorMessage = "Invalid Password Format!")]
        public string Password { get; set; }
    }
}
