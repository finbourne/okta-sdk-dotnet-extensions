using System;
using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Tokens
{
    public class TokenInfo : Resource, ITokenInfo
    {
        public string Id 
        { 
            get => GetStringProperty("id");
            set => this["id"] = value;
        }
        public string TokenType 
        { 
            get => GetStringProperty("tokenType");
            set => this["tokenType"] = value;
        }
        
        public string ClientName 
        { 
            get => GetStringProperty("clientName");
            set => this["clientName"] = value;
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

        public DateTimeOffset? ExpiresAt 
        { 
            get => GetDateTimeProperty("expiresAt");
            set => this["expiresAt"] = value;
        }
        
        public ITokenEmbedded Embedded
        {
            get => GetResourceProperty<TokenEmbedded>("_embedded");
            set => this["_embedded"] = value;
        }
    }
}