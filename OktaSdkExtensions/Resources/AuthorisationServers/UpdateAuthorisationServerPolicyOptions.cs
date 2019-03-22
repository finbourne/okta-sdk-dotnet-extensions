using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.AuthorisationServers
{
    public class UpdateAuthorisationServerPolicyOptions : Resource
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
        
        public string Type 
        { 
            get => GetStringProperty("type");
            set => this["type"] = value;
        }
        
        public string Status 
        { 
            get => GetStringProperty("status");
            set => this["status"] = value;
        }
        
        public int? Priority 
        { 
            get => GetIntegerProperty("priority");
            set => this["priority"] = value;
        }
        
        public IAuthorisationServerPolicyCondition Conditions
        {
            get => GetResourceProperty<AuthorisationServerPolicyCondition>("conditions");
            set => this["conditions"] = value;
        }
    }
}