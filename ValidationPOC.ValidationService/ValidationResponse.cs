using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationPOC.ValidationService
{
    public class ValidationResponse
    {
        public bool IsValid { get; set; }
        public IDictionary<string, string[]> ValidationResults { get; set; }

    }
}
