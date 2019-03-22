using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Finbourne.Extensions.Okta.Sdk.Clients;
using Finbourne.Extensions.Okta.Sdk.Resources.AuthorisationServers;
using Finbourne.Extensions.Okta.Sdk.Resources.Organisations;
using Finbourne.Extensions.Okta.Sdk.Resources.TrustedOrigins;
using Finbourne.Extensions.Okta.Sdk.Utils;
using Moq;
using NUnit.Framework;
using Okta.Sdk;
using Okta.Sdk.Configuration;

namespace Finbourne.Extensions.Okta.Sdk.Tests
{
    [Category("Unit")]
    public class TrustedOriginClientTests
    {
        private const string ExampleOktaDomain = "https://example.okta.com";
        
        [Test]
        public void WillGetATrustedOriginClientFromOrgsExtensionTest()
        {
            //GIVEN A standard okta client

            var mockClient = new Mock<IOktaClient>();
            var client = mockClient.Object;
            
            //WHEN An attempt is made to get the Trusted Origin client

            var result = client.TrustedOrigins();
            
            //THEN The client is returned and correctly populated with the client

            Assert.That(result, Is.InstanceOf<ITrustedOriginsClient>(), "The correct client should be returned");
            mockClient.VerifyAll();
        }

        [Test]
        public async Task CanListTrustedOriginsTest()
        {
            //GIVEN An okta tenant with one or more trusted origins
            
            string expectedUrl = $"{ExampleOktaDomain}/api/v1/trustedOrigins";

            var testItems = new[] { new TrustedOrigin {Id = "TestId"} };
            
            var mockClient = new Mock<IOktaClient>(MockBehavior.Strict);
            var client = mockClient.Object;
            
            mockClient.Setup(x=>x.Configuration)
                .Returns(new OktaClientConfiguration()
                {
                    OktaDomain = ExampleOktaDomain
                });
            
            mockClient.Setup(x => x.GetCollection<TrustedOrigin>(expectedUrl))
                .Returns(TestHelpers.CreateCollectionClient<TrustedOrigin>(testItems));
            
            //WHEN A request is made to get all the trusted origins
            
            var results = await client.TrustedOrigins()
                .ListTrustedOrigins()
                .ToListAsync(CancellationToken.None);
            
            //THEN The correct url should be called and all the contents should be suitably de-serialised

            var result = results.Single();
            
            Assert.That(result.Id, Is.EqualTo("TestId"), "Mocked result should be returned");
            
            mockClient.VerifyAll();   
        }
        
        
        [Test]
        public async Task CanCreatedATrustedOrigin()
        {
            //GIVEN A valid specifcation for a trusted origin
            var mockClient = new Mock<IOktaClient>();
            var client = mockClient.Object;

            mockClient.Setup(x=>x.Configuration)
                .Returns(new OktaClientConfiguration()
                {
                    OktaDomain = ExampleOktaDomain
                });


            var createOptions = new CreateTrustedOriginOptions()
            {
                Name = "Test origin",
                Origin = "https://mywebsite.trusted.com",
                Scopes = new List<ITrustedOriginScope>()
                {
                    new TrustedOriginScope(){ Type = "CORS"},
                    new TrustedOriginScope(){ Type = "REDIRECT"}
                }
            };

            mockClient.Setup(x => x.PostAsync<TrustedOrigin>($"{ExampleOktaDomain}/api/v1/trustedOrigins", It.IsAny<object>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new TrustedOrigin()
                {
                    Id = "Example response"
                }));
            
            //WHEN A request is made to create a trusted origin

            var result = await client.TrustedOrigins().CreateTrustedOrigin(createOptions, CancellationToken.None);
            
            //THEN The okta client is invoked with the correct parameters

            Assert.That(result.Id, Is.EqualTo("Example response"),
                "The returned object should be the mock expectation");
            
            mockClient.VerifyAll();
        }
    }
}