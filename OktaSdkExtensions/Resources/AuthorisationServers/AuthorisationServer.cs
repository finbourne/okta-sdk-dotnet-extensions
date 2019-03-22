using System;
using System.Collections.Generic;
using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.AuthorisationServers
{
    public class AuthorisationServer : Resource, IAuthorisationServer
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
        
        /// <inheritdoc />
        public IList<string> Audiences
        {
            get => GetArrayProperty<string>("audiences");
            set => this["audiences"] = value;
        }
        
        public string Issuer 
        { 
            get => GetStringProperty("issuer");
            set => this["issuer"] = value;
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

        public IAuthorisationServerCredentials Credentials
        {
            get => GetResourceProperty<AuthorisationServerCredentials>("credentials");
            set => this["credentials"] = value;
        }
    }
}