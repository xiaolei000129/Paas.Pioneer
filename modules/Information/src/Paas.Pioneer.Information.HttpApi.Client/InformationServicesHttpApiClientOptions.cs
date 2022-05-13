using System;
using System.Net.Http;

namespace Paas.Pioneer.Information.HttpApi.Client
{
    public class InformationServicesHttpApiClientOptions
    {
        public string RemoteServiceName { get; set; } = "Information";
        public string RemoteSectionUrl
        {
            get
            {
                return $"RemoteServices:{RemoteServiceName}:BaseUrl";
            }
        }

        public Func<DelegatingHandler> DelegatingHandlerFunc { get; set; }

        public InformationServicesHttpApiClientOptions()
        {

        }
    }
}
