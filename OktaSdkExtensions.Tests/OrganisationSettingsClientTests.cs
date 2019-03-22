using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Finbourne.Extensions.Okta.Sdk.Clients;
using Finbourne.Extensions.Okta.Sdk.Resources.AuthorisationServers;
using Finbourne.Extensions.Okta.Sdk.Resources.Organisations;
using Finbourne.Extensions.Okta.Sdk.Resources.Settings;
using Finbourne.Extensions.Okta.Sdk.Utils;
using Moq;
using NUnit.Framework;
using Okta.Sdk;
using Okta.Sdk.Configuration;

namespace Finbourne.Extensions.Okta.Sdk.Tests
{
    [Category("Unit")]
    public class OrganisationSettingsClientTests
    {
        private const string ExampleValue = "exampleAuthServerId";
        private const string ExampleOktaDomain = "https://example.okta.com";
        
        [Test]
        public void WillGetAnOrgSettingsClientExtensionTest()
        {
            //GIVEN A standard okta client

            var mockClient = new Mock<IOktaClient>();
            var client = mockClient.Object;
            
            //WHEN An attempt is made to get the Organisation settings client

            var result = client.OrganisationSettings();
            
            //THEN The client is returned and correctly populated with the client

            Assert.That(result, Is.InstanceOf<IOrganisationSettingsClient>(), "The correct client should be returned");
        }


        [Test]
        public async Task CanGetLocaleSettingsTest()
        {
            //GIVEN An existing okta organisation
            
            string expectedUrl = $"{ExampleOktaDomain}/api/internal/org/settings/locale";
            
            var mockClient = new Mock<IOktaClient>(MockBehavior.Strict);
            var client = mockClient.Object;
            
            mockClient.Setup(x=>x.Configuration)
                .Returns(new OktaClientConfiguration()
                {
                    OktaDomain = ExampleOktaDomain
                });
            
            mockClient.Setup(x => x.GetAsync<LocaleSettings>(expectedUrl, It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new LocaleSettings() { LocaleString = ExampleValue }));
            
            //WHEN A request is made to get locale settings
            
            var result = await client.OrganisationSettings().GetLocaleSettings(CancellationToken.None);
            
            //THEN The correct url should be called and all the contents should be suitably de-serialised

            Assert.That(result.LocaleString, Is.EqualTo(ExampleValue), "Mocked result should be returned");
            
            mockClient.VerifyAll();    
        }
        
        
        [Test]
        public async Task GetSignOutSettingsTest()
        {
            //GIVEN An existing okta organisation
            
            string expectedUrl = $"{ExampleOktaDomain}/api/internal/org/settings/signout-page";
            
            var mockClient = new Mock<IOktaClient>(MockBehavior.Strict);
            var client = mockClient.Object;
            
            mockClient.Setup(x=>x.Configuration)
                .Returns(new OktaClientConfiguration()
                {
                    OktaDomain = ExampleOktaDomain
                });
            
            mockClient.Setup(x => x.GetAsync<SignOutSettings>(expectedUrl, It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new SignOutSettings() { SignOutPage = ExampleValue }));
            
            //WHEN A request is made to get sign out settings
            
            var result = await client.OrganisationSettings().GetSignOutSettings(CancellationToken.None);
            
            //THEN The correct url should be called and all the contents should be suitably de-serialised

            Assert.That(result.SignOutPage, Is.EqualTo(ExampleValue), "Mocked result should be returned");
            
            mockClient.VerifyAll();    
        }
        
        [Test]
        public async Task GetBrowserPluginSettingsTest()
        {
            //GIVEN An existing okta organisation
            
            string expectedUrl = $"{ExampleOktaDomain}/api/internal/org/settings/browserplugin";
            
            var mockClient = new Mock<IOktaClient>(MockBehavior.Strict);
            var client = mockClient.Object;
            
            mockClient.Setup(x=>x.Configuration)
                .Returns(new OktaClientConfiguration()
                {
                    OktaDomain = ExampleOktaDomain
                });
            
            mockClient.Setup(x => x.GetAsync<BrowserPluginSettings>(expectedUrl, It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new BrowserPluginSettings() { EnabledGroup = ExampleValue }));
            
            //WHEN A request is made to get browser plugin settings
            
            var result = await client.OrganisationSettings().GetBrowserPluginSettings(CancellationToken.None);
            
            //THEN The correct url should be called and all the contents should be suitably de-serialised

            Assert.That(result.EnabledGroup, Is.EqualTo(ExampleValue), "Mocked result should be returned");
            
            mockClient.VerifyAll();    
        }
        
        [Test]
        public async Task GetSignInSettingsTest()
        {
            //GIVEN An existing okta organisation
            
            string expectedUrl = $"{ExampleOktaDomain}/api/internal/org/settings/signin-page";
            
            var mockClient = new Mock<IOktaClient>(MockBehavior.Strict);
            var client = mockClient.Object;
            
            mockClient.Setup(x=>x.Configuration)
                .Returns(new OktaClientConfiguration()
                {
                    OktaDomain = ExampleOktaDomain
                });
            
            mockClient.Setup(x => x.GetAsync<SignInPageSettings>(expectedUrl, It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new SignInPageSettings() { SigninLabel = ExampleValue }));
            
            //WHEN A request is made to get sign in settings
            
            var result = await client.OrganisationSettings().GetSignInSettings(CancellationToken.None);
            
            //THEN The correct url should be called and all the contents should be suitably de-serialised

            Assert.That(result.SigninLabel, Is.EqualTo(ExampleValue), "Mocked result should be returned");
            
            mockClient.VerifyAll();    
        }
        
        [Test]
        public async Task GetInterstitialSettingsTest()
        {
            //GIVEN An existing okta organisation
            
            string expectedUrl = $"{ExampleOktaDomain}/api/internal/v1/oktaInterstitial/settings";
            
            var mockClient = new Mock<IOktaClient>(MockBehavior.Strict);
            var client = mockClient.Object;
            
            mockClient.Setup(x=>x.Configuration)
                .Returns(new OktaClientConfiguration()
                {
                    OktaDomain = ExampleOktaDomain
                });
            
            mockClient.Setup(x => x.GetAsync<InterstitialPageSettings>(expectedUrl, It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new InterstitialPageSettings() { OktaInterstitialEnabled = true }));
            
            //WHEN A request is made to get interstitial settings
            
            var result = await client.OrganisationSettings().GetInterstitialSettings(CancellationToken.None);
            
            //THEN The correct url should be called and all the contents should be suitably de-serialised

            Assert.That(result.OktaInterstitialEnabled, Is.EqualTo(true), "Mocked result should be returned");
            
            mockClient.VerifyAll();    
        }
        
        
        [Test]
        public async Task GetDefaultApplicationSettings()
        {
            //GIVEN An existing okta organisation
            
            string expectedUrl = $"{ExampleOktaDomain}/api/internal/org/settings/default-application";
            
            var mockClient = new Mock<IOktaClient>(MockBehavior.Strict);
            var client = mockClient.Object;
            
            mockClient.Setup(x=>x.Configuration)
                .Returns(new OktaClientConfiguration()
                {
                    OktaDomain = ExampleOktaDomain
                });
            
            mockClient.Setup(x => x.GetAsync<DefaultApplicationSettings>(expectedUrl, It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new DefaultApplicationSettings() { DefaultApplicationURI = ExampleValue }));
            
            //WHEN A request is made to get default application settings
            
            var result = await client.OrganisationSettings().GetDefaultApplicationSettings(CancellationToken.None);
            
            //THEN The correct url should be called and all the contents should be suitably de-serialised

            Assert.That(result.DefaultApplicationURI, Is.EqualTo(ExampleValue), "Mocked result should be returned");
            
            mockClient.VerifyAll();    
        }
        
        
        [Test]
        public async Task GetCustomDomainSettingsTest()
        {
            //GIVEN An existing okta organisation
            
            string expectedUrl = $"{ExampleOktaDomain}/api/internal/v1/custom-url-domain";
            
            var mockClient = new Mock<IOktaClient>(MockBehavior.Strict);
            var client = mockClient.Object;
            
            mockClient.Setup(x=>x.Configuration)
                .Returns(new OktaClientConfiguration()
                {
                    OktaDomain = ExampleOktaDomain
                });
            
            mockClient.Setup(x => x.GetAsync<CustomDomainSettings>(expectedUrl, It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new CustomDomainSettings() { CustomDomain = ExampleValue }));
            
            //WHEN A request is made to get custom domain settings
            
            var result = await client.OrganisationSettings().GetCustomDomainSettings(CancellationToken.None);
            
            //THEN The correct url should be called and all the contents should be suitably de-serialised

            Assert.That(result.CustomDomain, Is.EqualTo(ExampleValue), "Mocked result should be returned");
            
            mockClient.VerifyAll();    
        }
        
        [Test]
        public async Task GetCustomDomainCertificateSettingsTest()
        {
            //GIVEN An existing okta organisation
            
            string expectedUrl = $"{ExampleOktaDomain}/api/internal/v1/custom-url-domain/certificate";
            
            var mockClient = new Mock<IOktaClient>(MockBehavior.Strict);
            var client = mockClient.Object;
            
            mockClient.Setup(x=>x.Configuration)
                .Returns(new OktaClientConfiguration()
                {
                    OktaDomain = ExampleOktaDomain
                });
            
            mockClient.Setup(x => x.GetAsync<CustomDomainCertificateSettings>(expectedUrl, It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new CustomDomainCertificateSettings() { CustomDomain = ExampleValue }));
            
            //WHEN A request is made to get custom domain settings
            
            var result = await client.OrganisationSettings().GetCustomDomainCertificateSettings(CancellationToken.None);
            
            //THEN The correct url should be called and all the contents should be suitably de-serialised

            Assert.That(result.CustomDomain, Is.EqualTo(ExampleValue), "Mocked result should be returned");
            
            mockClient.VerifyAll();    
        }
    }
}