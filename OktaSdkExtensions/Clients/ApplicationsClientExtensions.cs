using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Finbourne.Extensions.Okta.Sdk.Resources.Applications;
using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Clients
{
    public static class ApplicationsClientExtensions
    {
        /// <summary>
        /// Create an OIDC Application
        /// </summary>
        public static async Task<IOpenIdConnectApplication> CreateOidcApplicationAsync(
            this IOktaClient client, 
            CreateOidcApplicationOptions options, 
            CancellationToken cancellationToken)
        {
            var requestUrl = client.Configuration.BuildUrl("/api/v1/apps");
            return await client.PostAsync<OpenIdConnectApplication>(requestUrl.AbsoluteUri, options, cancellationToken);           
        }
        
        /// <summary>
        /// Create an OIDC Application
        /// </summary>
        public static async Task<IOpenIdConnectApplication> UpdateOidcApplicationAsync(
            this IOktaClient client, 
            string appId,
            UpdateOidcApplicationOptions options, 
            CancellationToken cancellationToken)
        {
            var requestUrl = client.Configuration.BuildUrl($"/api/v1/apps/{appId}");
            return await client.PutAsync<OpenIdConnectApplication>(requestUrl.AbsoluteUri, options, cancellationToken);           
        }


        /// <summary>
        /// Create an Org2Org Application
        /// </summary>
        public static async Task<IOrg2OrgApplication> CreateOrg2OrgApplicationAsync(
            this IOktaClient spokeClient, 
            CreateOrg2OrgApplicationOptions options, 
            CancellationToken cancellationToken)
        {
            var requestUrl = spokeClient.Configuration.BuildUrl("/api/v1/apps");
            return await spokeClient.PostAsync<Org2OrgApplication>(requestUrl.AbsoluteUri, options, cancellationToken);           
        }
        
        

        /// <summary>
        /// Get the InitiateLoginUri field from an OpenIdConnect application's settings
        /// </summary>
        /// <remarks>
        /// Get a field that is not on the sdk but is on the API
        /// </remarks>
        public static string GetInitiateLoginUri(this IOpenIdConnectApplicationSettingsClient client)
        {
            return client.GetProperty<string>("initiate_login_uri");
        }
        
        /// <summary>
        /// Get the InitiateLoginUri field from an OpenIdConnect application's settings
        /// </summary>
        /// <remarks>
        /// Get a field that is not on the sdk but is on the API
        /// </remarks>
        public static IList<string> GetPostLogOutRedirectUris(this IOpenIdConnectApplicationSettingsClient client)
        {
            return client.GetArrayProperty<string>("post_logout_redirect_uris");
        }
    }
}