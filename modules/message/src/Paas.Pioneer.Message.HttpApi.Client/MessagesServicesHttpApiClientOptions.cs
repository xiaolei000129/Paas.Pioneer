using System;
using System.Net.Http;

namespace Paas.Pioneer.Admin.Core.HttpApi.Client
{
    public class MessagesServicesHttpApiClientOptions
    {
        public string RemoteServiceName { get; set; } = "Messages";
        public string RemoteSectionUrl
        {
            get
            {
                return $"RemoteServices:{RemoteServiceName}:BaseUrl";
            }
        }

        public Func<DelegatingHandler> DelegatingHandlerFunc { get; set; }

        public MessagesServicesHttpApiClientOptions()
        {

        }
    }
}
