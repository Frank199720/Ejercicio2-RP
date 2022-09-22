using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RP.Domain.Custom
{
    public class MetaData<T>
    {
        public Pagination Paging { get; set; }
        public IEnumerable<T> DataSet { get; set; }
        public NavLinks Links { get; set; }
    }
}
