using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Settings
{
    public interface IBrowserPluginSettings : IResource
    {
        bool? AdminManaged { get; set; }
        string EnabledGroup { get; set; }
        bool? PreventBrowserPasswordSave { get; set; }
        bool? PreventBrowserOktaPasswordSave { get; set; }
        bool? AntiPhishingEnabled { get; set; }
        bool? AntiPhishingWhiteListedUrls { get; set; }
        bool? WarningState { get; set; }
    }
}