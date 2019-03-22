using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.IdentityProviders
{
    public class IdentityProviderProtocolAlgorithms : Resource, IIdentityProviderProtocolAlgorithms 
    {
        public IIdentityProviderProtocolAlgorithmsScopedAlgorithm Request 
        {
            get => GetResourceProperty<IdentityProviderProtocolAlgorithmsScopedAlgorithm>("request");
            set => this["request"] = value;
        }
        public IIdentityProviderProtocolAlgorithmsScopedAlgorithm Response 
        {
            get => GetResourceProperty<IdentityProviderProtocolAlgorithmsScopedAlgorithm>("response");
            set => this["response"] = value;
        }
    }
}