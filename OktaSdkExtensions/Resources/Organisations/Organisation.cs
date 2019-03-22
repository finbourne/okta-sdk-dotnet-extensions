using System;
using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Organisations
{
    public class Organisation : Resource, IOrganisation
    {
        public string Id 
        { 
            get => GetStringProperty("id");
            set => this["id"] = value;
        }
        
        public string SubDomain 
        { 
            get => GetStringProperty("subdomain");
            set => this["subdomain"] = value;
        }
        
        public string Name 
        { 
            get => GetStringProperty("name");
            set => this["name"] = value;
        }
        
        public string Website 
        { 
            get => GetStringProperty("website");
            set => this["website"] = value;
        }
        
        public string Status 
        { 
            get => GetStringProperty("status");
            set => this["status"] = value;
        }
        
        public string Edition 
        { 
            get => GetStringProperty("edition");
            set => this["edition"] = value;
        }
        
        public DateTimeOffset? ExpiresAt 
        { 
            get => GetDateTimeProperty("expiresAt");
            set => this["expiresAt"] = value;
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

        public IOrganisationLicensing Licensing
        {
            get => GetResourceProperty<OrganisationLicensing>("licensing");
            set => this["licensing"] = value;
        }
        
        public IOrganisationSettings Settings
        {
            get => GetResourceProperty<OrganisationSettings>("settings");
            set => this["settings"] = value;
        }
    }
}