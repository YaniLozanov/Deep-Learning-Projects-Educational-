using Microsoft.AspNetCore.Http;
using Stopify.Web.ViewModels;
using System;
using System.ComponentModel.DataAnnotations;

namespace Stopify.Web.InputModels
{
    public class ProductCreateInputModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateTime ManufacturedOn { get; set; }

        [Required]
        public IFormFile Picture { get; set; }

        [Required]
        public string ProductType { get; set; }
    }
}
