using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.AuthorisationServers
{
    public class AuthorisationServerCredentials : Resource, IAuthorisationServerCredentials
    {
        public IAuthorisationServerCredentialSigning Signing
        {
            get => GetResourceProperty<AuthorisationServerCredentialSigning>("signing");
            set => this["signing"] = value;
        }
    }
}