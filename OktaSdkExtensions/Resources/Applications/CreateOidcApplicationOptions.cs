using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Applications
{
    public class CreateOidcApplicationOptions : Resource
    {
        public string Name 
        {
            get => GetStringProperty("name");
            set => this["name"] = value;
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

        public IOidcApplicationCredentials Credentials
        {
            get => GetResourceProperty<OidcApplicationCredentials>("credentials");
            set => this["credentials"] = value;
        }
        
        public IOidcApplicationSettings Settings
        {
            get => GetResourceProperty<OidcApplicationSettings>("settings");
            set => this["settings"] = value;
        }

        public IApplicationAccessibility Accessibility
        {
            get => GetResourceProperty<ApplicationAccessibility>("accessibility");
            set => this["accessibility"] = value;
        }

        public IApplicationVisibility Visibility
        {
            get => GetResourceProperty<ApplicationVisibility>("visibility");
            set => this["visibility"] = value;
        }
    }
}