using System.Collections.Generic;
using Finbourne.Extensions.Okta.Sdk.Utils;
using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.TrustedOrigins
{
    public class CreateTrustedOriginOptions : Resource
    {
        
        public string Name 
        { 
            get => GetStringProperty("name");
            set => this["name"] = value;
        }
        
        public string Origin 
        { 
            get => GetStringProperty("origin");
            set => this["origin"] = value;
        }
        
        public IList<ITrustedOriginScope> Scopes
        {
            get => GetArrayProperty<TrustedOriginScope>("scopes")
                .CastToList<TrustedOriginScope, ITrustedOriginScope>();
            set => this["scopes"] = value;
        }
    }
}