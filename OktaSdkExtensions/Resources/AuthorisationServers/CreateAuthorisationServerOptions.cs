using System.Collections.Generic;
using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.AuthorisationServers
{
    public class CreateAuthorisationServerOptions : Resource
    {
        public string Description 
        { 
            get => GetStringProperty("description");
            set => this["description"] = value;
        }
        public string Name 
        { 
            get => GetStringProperty("name");
            set => this["name"] = value;
        }
        
        public IList<string> Audiences
        {
            get => GetArrayProperty<string>("audiences");
            set => this["audiences"] = value;
        }
        
        
    }
}