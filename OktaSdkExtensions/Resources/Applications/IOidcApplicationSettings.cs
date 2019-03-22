using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Applications
{
    public interface IOidcApplicationSettings : IResource
    {
        IOidcApplicationSettingsOAuthClient OAuthClient { get; set; }
    }
}