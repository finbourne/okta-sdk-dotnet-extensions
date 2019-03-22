using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Applications
{
    public interface IOidcApplicationCredentials : IResource
    {
        IOidcApplicationCredentialsOAuthClient OAuthClient { get; set; }
    }
}