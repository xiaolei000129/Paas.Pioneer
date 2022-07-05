using System;
using System.Net.Http;

namespace Paas.Pioneer.User.HttpApi.Client
{
    public class UsersServicesHttpApiClientOptions
    {
        public string RemoteServiceName { get; set; } = "Users";
        public string RemoteSectionUrl
        {
            get
            {
                return $"RemoteServices:{RemoteServiceName}:BaseUrl";
            }
        }

        public Func<DelegatingHandler> DelegatingHandlerFunc { get; set; }

        public UsersServicesHttpApiClientOptions()
        {

        }
    }
}
