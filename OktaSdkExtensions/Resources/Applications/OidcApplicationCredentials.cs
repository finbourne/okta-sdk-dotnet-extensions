using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Applications
{
    public class OidcApplicationCredentials : Resource, IOidcApplicationCredentials
    {
        public IOidcApplicationCredentialsOAuthClient OAuthClient
        {
            get => GetResourceProperty<OidcApplicationCredentialsOAuthClient>("oauthClient");
            set => this["oauthClient"] = value;
        }
    }
}