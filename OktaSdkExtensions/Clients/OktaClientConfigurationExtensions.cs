using System;
using Okta.Sdk.Configuration;

namespace Finbourne.Extensions.Okta.Sdk.Clients
{
    internal static class OktaClientConfigurationExtensions
    {
        /// <summary>
        /// Build a uri by using the base url from the okta client configuration and appending the supplied path
        /// </summary>
        /// <param name="client">The configured okta client configuration</param>
        /// <param name="path">The post domain suffix to be appended to the url</param>
        /// <returns>The absolute url</returns>
        internal static Uri BuildUrl(this OktaClientConfiguration client, string path)
        {
            return new Uri(new Uri(client.OktaDomain), path);
        }
    }
}