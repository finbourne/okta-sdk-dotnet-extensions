using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.IdentityProviders
{
    public class IdentityProviderProtocolCredentialsSigning : Resource, IIdentityProviderProtocolCredentialsSigning 
    {
        public string Kid {
            get => GetStringProperty("kid");
            set => this["kid"] = value;
        }
    }
}