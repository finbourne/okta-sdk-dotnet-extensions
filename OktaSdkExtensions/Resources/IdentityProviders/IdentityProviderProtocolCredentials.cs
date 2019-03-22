using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.IdentityProviders
{
    public class IdentityProviderProtocolCredentials : Resource, IIdentityProviderProtocolCredentials 
    {
        public IIdentityProviderProtocolCredentialsTrust Trust 
        {
            get => GetResourceProperty<IdentityProviderProtocolCredentialsTrust>("trust");
            set => this["trust"] = value;
        }
        public IIdentityProviderProtocolCredentialsSigning Signing 
        {
            get => GetResourceProperty<IdentityProviderProtocolCredentialsSigning>("signing");
            set => this["signing"] = value;
        }
    }
}