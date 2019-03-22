using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.AuthorisationServers
{
    public class AuthorisationServerActions : Resource, IAuthorisationServerActions
    {
        public IAuthorisationServerActionsToken Token
        {
            get => GetResourceProperty<AuthorisationServerActionsToken>("token");
            set => this["token"] = value;
        }
    }
}