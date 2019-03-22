using System;
using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Applications
{
    public class CreateOrg2OrgApplicationOptions : Resource
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
        
        public string Label 
        {
            get => GetStringProperty("label");
            set => this["label"] = value;
        }
        
        public string SignOnMode 
        {
            get => GetStringProperty("signOnMode");
            set => this["signOnMode"] = value;
        }

        public IOrg2OrgApplicationSettings Settings
        {
            get => GetResourceProperty<Org2OrgApplicationSettings>("settings");
            set => this["settings"] = value;
        }

    }
}
    