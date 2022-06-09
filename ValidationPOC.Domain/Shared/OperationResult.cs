using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationPOC.ValidationService;

namespace ValidationPOC.Domain.Shared
{
    public class OperationResult
    {
        public bool Success { get; set; }
        public ValidationResponse ValidationResult { get; set; }

    }
}
