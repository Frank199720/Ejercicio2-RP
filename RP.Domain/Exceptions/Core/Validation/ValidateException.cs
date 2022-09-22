using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RP.Domain.Exceptions.Core.Validation
{
    public class ValidateException : Exception
    {
        public IReadOnlyDictionary<string, string[]> ErrorsDictionary { get; }
        public ValidateException(IReadOnlyDictionary<string, string[]> errorDictionary) :
          base("One or more validation errors occurred") => ErrorsDictionary = errorDictionary;
    }
}
