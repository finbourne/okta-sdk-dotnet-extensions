using System;
using System.Threading;
using System.Threading.Tasks;
using Finbourne.Extensions.Okta.Sdk.Clients;
using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Settings
{
    /// <inheritdoc />
    public class OrganisationSettingsClient : IOrganisationSettingsClient
    {
        private readonly IOktaClient _client;

        /// <summary>
        /// Create an client for interacting with Okta organisation settings.
        /// </summary>
        public OrganisationSettingsClient(IOktaClient client)
        {
            _client = client;
        }

        /// <inheritdoc />
        public async Task<ILocaleSettings> GetLocaleSettings(
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestUrl = _client.Configuration.BuildUrl($"/api/internal/org/settings/locale");
            return await _client.GetAsync<LocaleSettings>(requestUrl.AbsoluteUri, cancellationToken);
        }

        public async Task<ISignOutSettings> GetSignOutSettings(
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestUrl = new Uri(new Uri(_client.Configuration.OktaDomain),
                $"/api/internal/org/settings/signout-page");
            return await _client.GetAsync<SignOutSettings>(requestUrl.AbsoluteUri, cancellationToken);
        }

        public async Task<IBrowserPluginSettings> GetBrowserPluginSettings(
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestUrl = new Uri(new Uri(_client.Configuration.OktaDomain),
                $"/api/internal/org/settings/browserplugin");
            return await _client.GetAsync<BrowserPluginSettings>(requestUrl.AbsoluteUri, cancellationToken);
        }

        public async Task<ISignInPageSettings> GetSignInSettings(
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestUrl = new Uri(new Uri(_client.Configuration.OktaDomain),
                $"/api/internal/org/settings/signin-page");
            return await _client.GetAsync<SignInPageSettings>(requestUrl.AbsoluteUri, cancellationToken);
        }

        public async Task<IInterstitialPageSettings> GetInterstitialSettings(
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestUrl = new Uri(new Uri(_client.Configuration.OktaDomain),
                $"/api/internal/v1/oktaInterstitial/settings");
            return await _client.GetAsync<InterstitialPageSettings>(requestUrl.AbsoluteUri, cancellationToken);
        }

        public async Task<IDefaultApplicationSettings> GetDefaultApplicationSettings(
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestUrl = new Uri(new Uri(_client.Configuration.OktaDomain),
                $"/api/internal/org/settings/default-application");
            return await _client.GetAsync<DefaultApplicationSettings>(requestUrl.AbsoluteUri, cancellationToken);
        }

        public async Task<ICustomDomainSettings> GetCustomDomainSettings(
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestUrl = _client.Configuration.BuildUrl($"/api/internal/v1/custom-url-domain");
            return await _client.GetAsync<CustomDomainSettings>(requestUrl.AbsoluteUri, cancellationToken);
        }

        public async Task<ICustomDomainCertificateSettings> GetCustomDomainCertificateSettings(
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestUrl = new Uri(new Uri(_client.Configuration.OktaDomain),
                $"/api/internal/v1/custom-url-domain/certificate");
            return await _client.GetAsync<CustomDomainCertificateSettings>(requestUrl.AbsoluteUri, cancellationToken);
        }
    }
}