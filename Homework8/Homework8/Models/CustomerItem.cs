using Serilog;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Homework8.Models
{
    public class CustomerItem : IValidatableObject
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Name))
            {
                Log.Warning("Name of company is null or empty");
                yield return new ValidationResult("Name of company is null or empty", new string[] { nameof(Name) });
            }
            else if (Name.Length < 3 || Name.Length > 30)
            {
                Log.Warning("Invalid length of customer name");
                yield return new ValidationResult("Invalid length of customer name", new string[] { nameof(Name) });
            }
        }
    }
}
