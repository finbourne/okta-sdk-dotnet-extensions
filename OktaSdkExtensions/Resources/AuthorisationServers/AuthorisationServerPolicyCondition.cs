using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.AuthorisationServers
{
    public class AuthorisationServerPolicyCondition : Resource, IAuthorisationServerPolicyCondition
    {
        public IAuthorisationServersCondition Clients
        {
            get => GetResourceProperty<AuthorisationServersCondition>("clients");
            set => this["clients"] = value;
        }
    }
}