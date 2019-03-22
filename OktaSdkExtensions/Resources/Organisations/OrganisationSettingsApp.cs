using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Organisations
{
    public class OrganisationSettingsApp : Resource, IOrganisationSettingsApp
    {
        public string ErrorRedirectUrl 
        { 
            get => GetStringProperty("errorRedirectUrl");
            set => this["errorRedirectUrl"] = value;
        }
        
        public string InterstitialUrl 
        { 
            get => GetStringProperty("interstitialUrl");
            set => this["interstitialUrl"] = value;
        }
        
        public int? InterstitialMinWaitTime 
        { 
            get => GetIntegerProperty("interstitialMinWaitTime");
            set => this["interstitialMinWaitTime"] = value;
        }
    }
}