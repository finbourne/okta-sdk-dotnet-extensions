using System;
using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.AuthorisationServers
{
    public class AuthorisationServerPolicy : Resource, IAuthorisationServerPolicy
    {
        public string Id 
        { 
            get => GetStringProperty("id");
            set => this["id"] = value;
        }
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
        public bool? System 
        { 
            get => GetBooleanProperty("system");
            set => this["system"] = value;
        }
        
        public DateTimeOffset? Created 
        { 
            get => GetDateTimeProperty("created");
            set => this["created"] = value;
        }
        
        public DateTimeOffset? LastUpdated 
        { 
            get => GetDateTimeProperty("lastUpdated");
            set => this["lastUpdated"] = value;
        }
        
        public IAuthorisationServerPolicyCondition Conditions
        {
            get => GetResourceProperty<AuthorisationServerPolicyCondition>("conditions");
            set => this["conditions"] = value;
        }
    }
}