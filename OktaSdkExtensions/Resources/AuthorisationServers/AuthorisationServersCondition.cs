using System.Collections.Generic;
using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.AuthorisationServers
{
    public class AuthorisationServersCondition : Resource, IAuthorisationServersCondition
    {
        public IList<string> Include
        {
            get => GetArrayProperty<string>("include");
            set => this["include"] = value;
        }
        
        public IList<string> Exclude
        {
            get => GetArrayProperty<string>("exclude");
            set => this["exclude"] = value;
        }
    }
}