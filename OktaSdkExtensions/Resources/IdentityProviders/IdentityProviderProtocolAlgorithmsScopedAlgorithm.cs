using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.IdentityProviders
{
    public class IdentityProviderProtocolAlgorithmsScopedAlgorithm : Resource, IIdentityProviderProtocolAlgorithmsScopedAlgorithm 
    {
        public IIdentityProviderProtocolAlgorithmsSignature Signature 
        {
            get => GetResourceProperty<IdentityProviderProtocolAlgorithmsSignature>("signature");
            set => this["signature"] = value;
        }
    }
}