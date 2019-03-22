using System;
using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.IdentityProviders
{
    public class IdentityProvider : Resource, IIdentityProvider 
    {
        public string Id   
        {
            get => GetStringProperty("id");
            set => this["id"] = value;
        }
        public string Type   
        {
            get => GetStringProperty("type");
            set => this["type"] = value;
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
        public IIdentityProviderProtocol Protocol    
        {
            get => GetResourceProperty<IdentityProviderProtocol>("protocol");
            set => this["protocol"] = value;
        }
        public IIdentityProviderPolicy Policy     
        {
            get => GetResourceProperty<IdentityProviderPolicy>("policy");
            set => this["policy"] = value;
        }
    }
}