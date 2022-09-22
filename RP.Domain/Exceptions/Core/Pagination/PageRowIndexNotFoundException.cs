using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RP.Domain.Exceptions.Core.Pagination
{
    public class PageRowIndexNotFoundException : Exception
    {
        public object ValueInfo { get; set; }
        public PageRowIndexNotFoundException() : base() { }
        public PageRowIndexNotFoundException(object valueInfo) : base($"The page number '{valueInfo}' does not exist within the data collection per page.") { ValueInfo = valueInfo; }
        public PageRowIndexNotFoundException(string message) : base(message) { }
        public PageRowIndexNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}
