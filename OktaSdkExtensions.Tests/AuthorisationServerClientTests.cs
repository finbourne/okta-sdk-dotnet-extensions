using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Finbourne.Extensions.Okta.Sdk.Clients;
using Finbourne.Extensions.Okta.Sdk.Resources.AuthorisationServers;
using Finbourne.Extensions.Okta.Sdk.Resources.Organisations;
using Finbourne.Extensions.Okta.Sdk.Utils;
using Moq;
using NUnit.Framework;
using Okta.Sdk;
using Okta.Sdk.Configuration;

namespace Finbourne.Extensions.Okta.Sdk.Tests
{
    [Category("Unit")]
    public class AuthorisationServerClientTests
    {
        private const string ExampleAuthServerId = "exampleAuthServerId";
        private const string ExamplePolicyId = "examplePolicyId";
        private const string ExampleOktaDomain = "https://example.okta.com";
        
        [Test]
        public void WillGetAnAuthClientFromOrgsExtensionTest()
        {
            //GIVEN A standard okta client

            var mockClient = new Mock<IOktaClient>();
            var client = mockClient.Object;
            
            //WHEN An attempt is made to get the Authorisation servers client

            var result = client.AuthorisationServers();
            
            //THEN The client is returned and correctly populated with the client

            Assert.That(result, Is.InstanceOf<IAuthorisationServersClient>(), "The correct client should be returned");
        }


        [Test]
        public async Task CanGetAnAuthorisationServerTest()
        {
            //GIVEN A known organisation identifier
            
            string expectedUrl = $"{ExampleOktaDomain}/api/v1/authorizationServers/{ExampleAuthServerId}";
            
            var mockClient = new Mock<IOktaClient>(MockBehavior.Strict);
            var client = mockClient.Object;
            
            mockClient.Setup(x=>x.Configuration)
                .Returns(new OktaClientConfiguration()
                {
                    OktaDomain = ExampleOktaDomain
                });
            
            mockClient.Setup(x => x.GetAsync<AuthorisationServer>(expectedUrl, It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new AuthorisationServer() { Id = ExampleAuthServerId }));
            
            //WHEN A request is made to get an authorisation server
            
            var result = await client.AuthorisationServers().GetAuthorisationServer(ExampleAuthServerId, CancellationToken.None);
            
            //THEN The correct url should be called and all the contents should be suitably de-serialised

            Assert.That(result.Id, Is.EqualTo(ExampleAuthServerId), "Mocked result should be returned");
            
            mockClient.VerifyAll();    
        }
        
        [Test]
        public async Task CanGetAnAuthorisationServerPoliciesTest()
        {
            //GIVEN A known organisation identifier
            
            string expectedUrl = $"{ExampleOktaDomain}/api/v1/authorizationServers/{ExampleAuthServerId}/policies";

            var testItems = new[] { new AuthorisationServerPolicy {Id = "TestId"} };
            
            
            var mockClient = new Mock<IOktaClient>(MockBehavior.Strict);
            var client = mockClient.Object;
            
            mockClient.Setup(x=>x.Configuration)
                .Returns(new OktaClientConfiguration()
                {
                    OktaDomain = ExampleOktaDomain
                });


            var mockCollection = TestHelpers.CreateCollectionClient<AuthorisationServerPolicy>(testItems);
            
            
            mockClient.Setup(x => x.GetCollection<AuthorisationServerPolicy>(expectedUrl))
                .Returns(mockCollection);
            
            //WHEN A request is made to get an authorisation server's policies
            
            var results = await client.AuthorisationServers()
                .ListAuthorisationServerPolicies(ExampleAuthServerId)
                .ToListAsync(CancellationToken.None);
            
            //THEN The correct url should be called and all the contents should be suitably de-serialised

            var result = results.Single();
            
            Assert.That(result.Id, Is.EqualTo("TestId"), "Mocked result should be returned");
            
            mockClient.VerifyAll();   
        }
        
        [Test]
        public async Task CanGetAnAuthorisationServerPolicyRulesTest()
        {
            //GIVEN A known organisation identifier
            
            string expectedUrl = $"{ExampleOktaDomain}/api/v1/authorizationServers/{ExampleAuthServerId}/policies/{ExamplePolicyId}/rules";

            var testItems = new[] { new AuthorisationServerPolicyRule() {Id = "TestId"} };
            
            var mockClient = new Mock<IOktaClient>(MockBehavior.Strict);
            var client = mockClient.Object;
            
            mockClient.Setup(x=>x.Configuration)
                .Returns(new OktaClientConfiguration()
                {
                    OktaDomain = ExampleOktaDomain
                });

            var mockCollection = TestHelpers.CreateCollectionClient<AuthorisationServerPolicyRule>(testItems);
            
            mockClient.Setup(x => x.GetCollection<AuthorisationServerPolicyRule>(expectedUrl))
                .Returns(mockCollection);
            
            //WHEN A request is made to get an authorisation server's policies
            
            var results = await client.AuthorisationServers()
                .ListAuthorisationServerPolicyRules(ExampleAuthServerId, ExamplePolicyId)
                .ToListAsync(CancellationToken.None);
            
            //THEN The correct url should be called and all the contents should be suitably de-serialised

            var result = results.Single();
            
            Assert.That(result.Id, Is.EqualTo("TestId"), "Mocked result should be returned");
            
            mockClient.VerifyAll();   
        }
    }
}