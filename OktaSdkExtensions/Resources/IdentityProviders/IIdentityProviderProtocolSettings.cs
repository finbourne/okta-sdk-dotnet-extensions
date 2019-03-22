using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.IdentityProviders
{
    public interface IIdentityProviderProtocolSettings : IResource
    {
        string NameFormat { get; set; }
    }
}