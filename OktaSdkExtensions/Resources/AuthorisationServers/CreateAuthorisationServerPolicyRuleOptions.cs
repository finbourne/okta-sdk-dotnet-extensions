using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.AuthorisationServers
{
    public class CreateAuthorisationServerPolicyRuleOptions : Resource
    {
        public string Name 
        { 
            get => GetStringProperty("name");
            set => this["name"] = value;
        }
   
        public string Status 
        { 
            get => GetStringProperty("status");
            set => this["status"] = value;
        }
   
        public string Type 
        { 
            get => GetStringProperty("type");
            set => this["type"] = value;
        }
        
        public int? Priority 
        { 
            get => GetIntegerProperty("priority");
            set => this["priority"] = value;
        }
        
        public IAuthorisationServerPolicyRuleConditionSet Conditions
        {
            get => GetResourceProperty<AuthorisationServerPolicyRuleConditionSet>("conditions");
            set => this["conditions"] = value;
        }
        
        public IAuthorisationServerActions Actions
        {
            get => GetResourceProperty<AuthorisationServerActions>("actions");
            set => this["actions"] = value;
        }
    }
}