using RP.Domain.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RP.Domain.Interfaces.Managment
{
    public interface IUriService
    {
        Uri GetPageUri(RequestParameter filter, string route);
    }
}
