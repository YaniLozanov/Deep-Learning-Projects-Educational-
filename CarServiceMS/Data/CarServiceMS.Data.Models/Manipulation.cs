﻿using System;
using System.ComponentModel.DataAnnotations;

namespace CarServiceMS.Data.Models
{
    public class Manipulation
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public Car car { get; set; }
    }
}
