using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Homework6.Models
{
    public class Customer : IValidatableObject
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Name))
            {
                yield return new ValidationResult("Name of company is null or empty", new string[] { nameof(Name) });
            }
            else if (Name.Length < 3 || Name.Length > 30)
            {
                yield return new ValidationResult("Invalid length of customer name", new string[] { nameof(Name) });
            }
        }
    }
}
