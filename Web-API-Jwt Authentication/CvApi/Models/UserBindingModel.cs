using System.ComponentModel.DataAnnotations;

namespace CvApi.Models
{
    public class UserBindingModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public string Email { get; set; }

    }
}
