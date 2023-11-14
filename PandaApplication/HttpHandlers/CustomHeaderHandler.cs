using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaApplication.HttpHandlers
{
    public class CustomHeaderHandler : DelegatingHandler
    {
        public CustomHeaderHandler() : base(new HttpClientHandler()) { }
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add("Custom-Header", "My Custom Header Value");
            return base.SendAsync(request, cancellationToken);
        }
    }
}
