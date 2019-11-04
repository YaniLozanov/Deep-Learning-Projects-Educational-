using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CarServiceMS.Data.Attributes
{
    public class CarNumberUniqueAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(
            object value, ValidationContext validationContext)
        {
            var _context = (ApplicationDbContext)validationContext.GetService(typeof(ApplicationDbContext));
            var entity = _context.Cars.SingleOrDefault(car => car.Number == value.ToString());

            if (entity != null)
            {
                return new ValidationResult(GetErrorMessage(value.ToString()));
            }
            return ValidationResult.Success;
        }

        public string GetErrorMessage(string email)
        {
            return $"Invalid Car Number";
        }
    }
}

