using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;

namespace CarServiceMS.Models.BindingModels
{
    [Authorize(Roles = "Admin")]
    public class AdminBindingModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string SecretPassword { get; set; }
    }
}
