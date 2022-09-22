using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RP.Domain.Custom
{
    public class NavLinks
    {
        public Uri SelfPage { get; set; }
        public Uri FirstPage { get; set; }
        public Uri LastPage { get; set; }
        public Uri NextPage { get; set; }
        public Uri PreviousPage { get; set; }
        public NavLinks(Uri selfPage, Uri firstPage, Uri lastPage, Uri nextPage, Uri previousPage)
        {
            SelfPage = selfPage; FirstPage = firstPage; LastPage = lastPage; NextPage = nextPage; PreviousPage = previousPage;
        }
    }
}
