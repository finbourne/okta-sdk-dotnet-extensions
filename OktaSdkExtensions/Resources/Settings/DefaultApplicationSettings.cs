using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Settings
{
    public class DefaultApplicationSettings : Resource, IDefaultApplicationSettings
    {

        public bool? DefaultApplicationSpecified {
            get => GetBooleanProperty("defaultApplicationSpecified");
            set => this["defaultApplicationSpecified"] = value;
        }
        public string DefaultApplicationURI { 
            get => GetStringProperty("defaultApplicationURI");
            set => this["defaultApplicationURI"] = value;
        }
    }
}