using System.Collections.Generic;
using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.IdentityProviders
{
    public class CreateIdentityProviderCredentialKeyOptions : Resource
    {
        public IList<string> X5C  
        {
            get => GetArrayProperty<string>("x5c");
            set => this["x5c"] = value;
        }
    }
}