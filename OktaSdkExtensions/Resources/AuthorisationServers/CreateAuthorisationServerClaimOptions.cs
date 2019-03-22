using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.AuthorisationServers
{
    public class CreateAuthorisationServerClaimOptions : Resource
    {
        public string Name 
        {
            get => GetStringProperty("name");
            set => this["name"] = value;
        }
        
        public string ClaimType 
        {
            get => GetStringProperty("claimType");
            set => this["claimType"] = value;
        }
        public string ValueType 
        {
            get => GetStringProperty("valueType");
            set => this["valueType"] = value;
        }
        public string Value 
        {
            get => GetStringProperty("value");
            set => this["value"] = value;
        }

        public string GroupFilterType 
        {
            get => GetStringProperty("group_filter_type");
            set => this["group_filter_type"] = value;
        }
        
        public bool? AlwaysIncludeInToken 
        {
            get => GetBooleanProperty("alwaysIncludeInToken");
            set => this["alwaysIncludeInToken"] = value;
        }
        
        public string Status 
        {
            get => GetStringProperty("status");
            set => this["status"] = value;
        }
        
        public IAuthorisationServerClaimCondition Conditions 
        {
            get => GetResourceProperty<AuthorisationServerClaimCondition>("conditions");
            set => this["conditions"] = value;
        }
    }
}