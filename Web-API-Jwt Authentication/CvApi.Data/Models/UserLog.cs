using System;
using System.ComponentModel.DataAnnotations;

namespace CvApi.Data.Models
{
    public class UserLog
    {
        [Key]
        public int Id { get; set; }

        public AppliactionUser User { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;
    }
}
