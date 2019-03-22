using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Applications
{
    public class Org2OrgApplicationSettingsSignOn : Resource, IOrg2OrgApplicationSettingsSignOn
    {
        public string DefaultRelayState 
        {
            get => GetStringProperty("defaultRelayState");
            set => this["defaultRelayState"] = value;
        }
        public string SsoAcsUrlOverride 
        {
            get => GetStringProperty("ssoAcsUrlOverride");
            set => this["ssoAcsUrlOverride"] = value;
        }
        public string AudienceOverride 
        {
            get => GetStringProperty("audienceOverride");
            set => this["audienceOverride"] = value;
        }
        public string RecipientOverride 
        {
            get => GetStringProperty("recipientOverride");
            set => this["recipientOverride"] = value;
        }
        public string DestinationOverride 
        {
            get => GetStringProperty("destinationOverride");
            set => this["destinationOverride"] = value;
        }
    }
}