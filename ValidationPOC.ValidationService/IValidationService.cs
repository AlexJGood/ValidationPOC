using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ValidationPOC.ValidationService
{
    public interface IValidationService
    {
        public IDictionary<string, string[]> Validate<T>(T item) where T : class;
    }
}
