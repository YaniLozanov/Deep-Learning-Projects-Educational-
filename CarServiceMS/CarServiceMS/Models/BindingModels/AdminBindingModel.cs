using System.ComponentModel.DataAnnotations;

namespace CarServiceMS.Models.BindingModels
{
    public class AdminBindingModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string SecretPassword { get; set; }
    }
}
