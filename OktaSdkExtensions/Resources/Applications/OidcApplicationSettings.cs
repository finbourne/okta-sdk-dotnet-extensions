using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Applications
{
    public class OidcApplicationSettings : Resource, IOidcApplicationSettings
    {
        public IOidcApplicationSettingsOAuthClient OAuthClient
        {
            get => GetResourceProperty<OidcApplicationSettingsOAuthClient>("oauthClient");
            set => this["oauthClient"] = value;
        }
    }
}