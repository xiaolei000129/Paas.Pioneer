using System;
using System.Net.Http;

namespace Paas.Pioneer.Admin.Core.HttpApi.Client
{
    public class TemplatesServicesHttpApiClientOptions
    {
        public string RemoteServiceName { get; set; } = "Templates";
        public string RemoteSectionUrl
        {
            get
            {
                return $"RemoteServices:{RemoteServiceName}:BaseUrl";
            }
        }

        public Func<DelegatingHandler> DelegatingHandlerFunc { get; set; }

        public TemplatesServicesHttpApiClientOptions()
        {

        }
    }
}
