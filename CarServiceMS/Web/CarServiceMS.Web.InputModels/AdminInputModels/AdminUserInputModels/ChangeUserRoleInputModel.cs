using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;

namespace CarServiceMS.Web.InputModels.AdminInputModels.AdminUserInputModels
{
    [Authorize(Roles = "Admin")]
    public class ChangeUserRoleInputModel
    {
        public string RoleName { get; set; }
        public string UserId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string SecretPassword { get; set; }
    }
}
