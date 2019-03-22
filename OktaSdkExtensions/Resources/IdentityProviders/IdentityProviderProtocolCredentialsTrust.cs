using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.IdentityProviders
{
    public class IdentityProviderProtocolCredentialsTrust : Resource, IIdentityProviderProtocolCredentialsTrust 
    {
        public string Issuer {
            get => GetStringProperty("issuer");
            set => this["issuer"] = value;
        }
        public string Audience {
            get => GetStringProperty("audience");
            set => this["audience"] = value;
        }
        public string Kid {
            get => GetStringProperty("kid");
            set => this["kid"] = value;
        }
        public string Revocation {
            get => GetStringProperty("revocation");
            set => this["revocation"] = value;
        }
        public int? RevocationCacheLifetime {
            get => GetIntegerProperty("revocationCacheLifetime");
            set => this["revocationCacheLifetime"] = value;
        }
    }
}