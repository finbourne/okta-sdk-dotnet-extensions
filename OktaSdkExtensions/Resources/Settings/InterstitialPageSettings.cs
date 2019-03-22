using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Settings
{
    public class InterstitialPageSettings : Resource, IInterstitialPageSettings
    {
        public bool? OktaInterstitialEnabled 
        {
            get => GetBooleanProperty("oktaInterstitialEnabled");
            set => this["oktaInterstitialEnabled"] = value;
        }
    }
}