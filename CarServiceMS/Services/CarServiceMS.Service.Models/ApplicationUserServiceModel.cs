using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarServiceMS.Service.Models
{
    public class ApplicationUserServiceModel : IdentityUser
    {
        [Required]
        public DateTime MemberSince { get; set; } = DateTime.Now;
        public int ClubPoints { get; set; }
        public string PersonalityDesctription { get; set; }

        [Required]
        public string Role { get; set; }
        public IEnumerable<CarServiceModel> Cars { get; set; }
    }
}
