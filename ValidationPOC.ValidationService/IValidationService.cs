using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ValidationPOC.ValidationService
{
    public interface IValidationService
    {
        public ValidationResponse Validate<T>(T item) where T : class;
    }
}
