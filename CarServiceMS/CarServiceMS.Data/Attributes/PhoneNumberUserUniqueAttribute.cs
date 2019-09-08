using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CarServiceMS.Data.Attributes
{
    public class PhoneNumberUserUniqueAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(
           object value, ValidationContext validationContext)
        {
            var _context = (ApplicationDbContext)validationContext.GetService(typeof(ApplicationDbContext));
            var entity = _context.Users.SingleOrDefault(e => e.PhoneNumber == value.ToString());

            if (entity != null)
            {
                return new ValidationResult(GetErrorMessage(value.ToString()));
            }
            return ValidationResult.Success;
        }

        public string GetErrorMessage(string phoneNumber)
        {
            return $"Invalid Phone Number";
        }
    }
}

