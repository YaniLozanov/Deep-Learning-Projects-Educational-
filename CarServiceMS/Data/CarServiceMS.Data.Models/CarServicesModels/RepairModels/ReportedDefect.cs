using System.ComponentModel.DataAnnotations;

namespace CarServiceMS.Data.Models.CarServicesModels
{
    public class ReportedDefect
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
