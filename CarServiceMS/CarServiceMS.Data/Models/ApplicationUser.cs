using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarServiceMS.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public DateTime MemberSince { get; set; } = DateTime.Now;
        public int ClubPoints { get; set; }
        public string PersonalityDesctription { get; set; }

        [Required]
        public string Role { get; set; }
        public IEnumerable<Car> Cars { get; set; }
    }
}
