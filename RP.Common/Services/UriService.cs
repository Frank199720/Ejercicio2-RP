using Microsoft.AspNetCore.WebUtilities;
using RP.Domain.Interfaces.Managment;
using RP.Domain.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RP.Common.Services
{
    public class UriService : IUriService
    {
        private readonly string _baseUri;
        public UriService(string baseUri) => _baseUri = baseUri;
        public Uri GetPageUri(RequestParameter filter, string route)
        {
            var _enpointUri = new Uri(string.Concat(_baseUri, route));
            var _modifiedUri = QueryHelpers.AddQueryString(_enpointUri.ToString(), "PageNumber", filter.PageNumber.ToString());
            _modifiedUri = QueryHelpers.AddQueryString(_modifiedUri, "PageSize", filter.PageSize.ToString());           

            return new Uri(_modifiedUri);
        }
    }
}
