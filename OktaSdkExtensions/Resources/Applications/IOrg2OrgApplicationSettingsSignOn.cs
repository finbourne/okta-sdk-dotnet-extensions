using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Applications
{
    public interface IOrg2OrgApplicationSettingsSignOn : IResource
    {
        string DefaultRelayState { get; set; }
        string SsoAcsUrlOverride { get; set; }
        string AudienceOverride { get; set; }
        string RecipientOverride { get; set; }
        string DestinationOverride { get; set; }
    }
}