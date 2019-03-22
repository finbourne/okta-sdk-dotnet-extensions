using System;
using System.Collections.Generic;
using Finbourne.Extensions.Okta.Sdk.Utils;
using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.IdentityProviders
{
    public class IdentityProviderCredentialKey : Resource, IIdentityProviderCredentialKey 
    {
        public string Kty  
        {
            get => GetStringProperty("kty");
            set => this["kty"] = value;
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
        public IList<string> X5C  
        {
            get => GetArrayProperty<string>("x5c");
            set => this["x5c"] = value;
        }
        public string Kid  
        {
            get => GetStringProperty("kid");
            set => this["kid"] = value;
        }
        public string Use  
        {
            get => GetStringProperty("use");
            set => this["use"] = value;
        }
        public string E  
        {
            get => GetStringProperty("e");
            set => this["e"] = value;
        }
        public string N  
        {
            get => GetStringProperty("n");
            set => this["n"] = value;
        }
        public string X5tS256Hash  
        {
            get => GetStringProperty("x5t#S256");
            set => this["x5t#S256"] = value;
        }
    }
}