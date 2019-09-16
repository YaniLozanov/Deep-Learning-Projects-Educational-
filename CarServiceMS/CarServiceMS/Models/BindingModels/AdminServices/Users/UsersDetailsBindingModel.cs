using System;
using System.ComponentModel.DataAnnotations;

namespace CarServiceMS.Models.BindingModels.AdminServices.Users
{
    public class UsersDetailsBindingModel
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public DateTime MemberSince { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        [MaxLength(500, ErrorMessage = "Max text length 500 symbols!")]
        [RegularExpression("^[A-Za-z0-9 _,!.]*$", ErrorMessage = "Not allowed symbol!")]
        public string PersonalityDesctription { get; set; }
        public string Role { get; set; }

    }
}
