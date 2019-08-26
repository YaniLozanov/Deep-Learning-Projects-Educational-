﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarServiceMS.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public DateTime MemberSince { get; set; }

        public int ClubPoints { get; set; }

        public string PersonalityDesctription { get; set; }

        public IEnumerable<Car> Cars { get; set; }
    }
}
