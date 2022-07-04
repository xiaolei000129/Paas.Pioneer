using System;
using System.Net.Http;

namespace Paas.Pioneer.Admin.Core.HttpApi.Client
{
    public class WeChatsServicesHttpApiClientOptions
    {
        public string RemoteServiceName { get; set; } = "WeChats";
        public string RemoteSectionUrl
        {
            get
            {
                return $"RemoteServices:{RemoteServiceName}:BaseUrl";
            }
        }

        public Func<DelegatingHandler> DelegatingHandlerFunc { get; set; }

        public WeChatsServicesHttpApiClientOptions()
        {

        }
    }
}
