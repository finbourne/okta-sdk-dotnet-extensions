using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Applications
{
    public interface IOidcApplicationCredentialsOAuthClient : IResource
    {
        string ClientId { get; set; }
        bool? AutoKeyRotation { get; set; }
        string TokenEndpointAuthMethod { get; set; }
    }
}