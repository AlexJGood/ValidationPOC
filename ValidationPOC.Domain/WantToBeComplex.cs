using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationPOC.Domain
{
    public class WantToBeComplex : IValidatableObject
    {
        public int Field1 { get; set; }
        public string Field2 { get; set; }
        public int Field3 { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Field1 > 4 )
            {
                yield return new ValidationResult("Field1 cannot be greater than 4");
            }

            if (string.IsNullOrWhiteSpace(Field2))
            {
                yield return new ValidationResult("Field2 cannot empty");
            }

            if (Field3 < 20)
            {
                yield return new ValidationResult("Field3 cannot be less than 20");
            }
        }
    }
}
