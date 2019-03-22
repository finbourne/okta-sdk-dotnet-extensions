using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Settings
{
    public interface IInterstitialPageSettings : IResource
    {
        bool? OktaInterstitialEnabled { get; set; }
    }
}