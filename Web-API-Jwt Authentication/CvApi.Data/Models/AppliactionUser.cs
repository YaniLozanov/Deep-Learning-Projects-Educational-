using CvApi.Data.Models;
using Microsoft.Web.Mvc.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CvApi.Data
{
    public class AppliactionUser
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public IEnumerable<UserLog> UserLogs { get; set; }
    }
}
