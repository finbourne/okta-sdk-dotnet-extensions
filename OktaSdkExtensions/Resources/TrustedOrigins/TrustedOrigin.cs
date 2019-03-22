using System;
using System.Collections.Generic;
using Finbourne.Extensions.Okta.Sdk.Utils;
using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.TrustedOrigins
{
    public class TrustedOrigin : Resource, ITrustedOrigin
    {
        public string Id 
        { 
            get => GetStringProperty("id");
            set => this["id"] = value;
        }
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
        
        public string Status 
        { 
            get => GetStringProperty("status");
            set => this["status"] = value;
        }
        
        public DateTimeOffset? Created 
        { 
            get => GetDateTimeProperty("created");
            set => this["created"] = value;
        }
        
        public string CreatedBy 
        { 
            get => GetStringProperty("createdBy");
            set => this["createdBy"] = value;
        }
        
        public DateTimeOffset? LastUpdated 
        { 
            get => GetDateTimeProperty("lastUpdated");
            set => this["lastUpdated"] = value;
        }

        public string LastUpdatedBy 
        { 
            get => GetStringProperty("lastUpdatedBy");
            set => this["lastUpdatedBy"] = value;
        }
       
        
        public IList<ITrustedOriginScope> Scopes
        {
            get => GetArrayProperty<TrustedOriginScope>("scopes")
                .CastToList<TrustedOriginScope, ITrustedOriginScope>();
            set => this["scopes"] = value;
        }
    }
}