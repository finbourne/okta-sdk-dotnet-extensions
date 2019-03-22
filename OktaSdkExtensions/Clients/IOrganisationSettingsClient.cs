using System.Threading;
using System.Threading.Tasks;
using Finbourne.Extensions.Okta.Sdk.Resources.Settings;

namespace Finbourne.Extensions.Okta.Sdk.Clients
{
    /// <summary>A client that works with Okta organisation settings.</summary>
    public interface IOrganisationSettingsClient 
    {
        Task<ILocaleSettings> GetLocaleSettings(CancellationToken cancellationToken = default(CancellationToken));
        
        Task<ISignOutSettings> GetSignOutSettings(CancellationToken cancellationToken = default(CancellationToken));
        
        Task<IBrowserPluginSettings> GetBrowserPluginSettings(CancellationToken cancellationToken = default(CancellationToken));
        
        Task<ISignInPageSettings> GetSignInSettings(CancellationToken cancellationToken = default(CancellationToken));
        
        Task<IInterstitialPageSettings> GetInterstitialSettings(CancellationToken cancellationToken = default(CancellationToken));
        Task<IDefaultApplicationSettings> GetDefaultApplicationSettings(CancellationToken cancellationToken = default(CancellationToken));
        
        Task<ICustomDomainSettings> GetCustomDomainSettings(CancellationToken cancellationToken = default(CancellationToken));
        Task<ICustomDomainCertificateSettings> GetCustomDomainCertificateSettings(CancellationToken cancellationToken = default(CancellationToken));
    }
}