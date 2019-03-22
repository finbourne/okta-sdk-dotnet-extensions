using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.IdentityProviders
{
    public interface IIdentityProviderProtocol : IResource
    {
        string Type { get; set; }
        IIdentityProviderProtocolEndpoints Endpoints { get; set; }
        IIdentityProviderProtocolAlgorithms Algorithms { get; set; }
        IIdentityProviderProtocolSettings Settings { get; set; }
        IIdentityProviderProtocolCredentials Credentials { get; set; }
    }
}