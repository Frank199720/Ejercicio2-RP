using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RP.Domain.Features
{
    public static class RegexExtensions
    {
        public static bool VerifyValue(object value, string pattern) => Regex.IsMatch(value.ToString(), pattern);
        public static bool VerifyStringIsNullOrEmpty(string value) =>
          (Regex.IsMatch(value, @"^\s*$") | string.IsNullOrEmpty(value) | value.Length == 0 | value == "null" | value == "NULL");
    }
}
