using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Threading;
using System.Threading.Tasks;
using Finbourne.Extensions.Okta.Sdk.Clients;
using Finbourne.Extensions.Okta.Sdk.Resources.AuthorisationServers;
using Finbourne.Extensions.Okta.Sdk.Resources.Schemas;
using Finbourne.Extensions.Okta.Sdk.Utils;
using Moq;
using NUnit.Framework;
using Okta.Sdk;
using Okta.Sdk.Configuration;

namespace Finbourne.Extensions.Okta.Sdk.Tests
{
    [Category("Unit")]
    public class SchemaTests
    {
        private const string ExampleOktaDomain = "https://example.okta.com";
        
        [Test]
        public void WillGetAnSchemaClientFromOrgsExtensionTest()
        {
            //GIVEN A standard okta client

            var mockClient = new Mock<IOktaClient>();
            var client = mockClient.Object;
            
            //WHEN An attempt is made to get the Schemas client

            var result = client.Schemas();
            
            //THEN The client is returned and correctly populated with the client

            Assert.That(result, Is.InstanceOf<ISchemasClient>(), "The correct client should be returned");
            mockClient.VerifyAll();
        }


        [Test]
        public async Task  CanGetTheDefaultUserProfileTest()
        {
            //GIVEN A known organisation identifier
            
            string expectedUrl = $"{ExampleOktaDomain}/api/v1/meta/schemas/user/default";
            var mockClient = new Mock<IOktaClient>(MockBehavior.Strict);
            var client = mockClient.Object;
            
            mockClient.Setup(x=>x.Configuration)
                .Returns(new OktaClientConfiguration()
                {
                    OktaDomain = ExampleOktaDomain
                });
            
            mockClient.Setup(x => x.GetAsync<Schema>(expectedUrl, It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new Schema() { Id = "TestId" }));
            
            //WHEN A request is made to get an authorisation server's policies
            
            var results = await client.Schemas().GetUserSchema();
            
            //THEN The correct url should be called and all the contents should be suitably de-serialised

            Assert.That(results.Id, Is.EqualTo("TestId"), "Mocked result should be returned");
            
            mockClient.VerifyAll();   
        }
        
        
        [Test]
        public async Task CanGetAnAppUserProfileTest()
        {
            //GIVEN A known organisation identifier
            string appId = "TestAppId1234";
            string expectedUrl = $"{ExampleOktaDomain}/api/v1/meta/schemas/apps/${appId}/default";
            var mockClient = new Mock<IOktaClient>(MockBehavior.Strict);
            var client = mockClient.Object;
            
            mockClient.Setup(x=>x.Configuration)
                .Returns(new OktaClientConfiguration()
                {
                    OktaDomain = ExampleOktaDomain
                });
            
            mockClient.Setup(x => x.GetAsync<ApplicationSchema>(expectedUrl, It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new ApplicationSchema() { Id = "TestId" }));
            
            //WHEN A request is made to get an authorisation server's policies
            
            var results = await client.Schemas().GetApplicationUserSchema(appId);
            
            //THEN The correct url should be called and all the contents should be suitably de-serialised

            Assert.That(results.Id, Is.EqualTo("TestId"), "Mocked result should be returned");
            
            mockClient.VerifyAll();   
        }
        
        
        

        [Test]
        public async Task CanCreateAUserProperty()
        {
            //GIVEN A valid specifcation for an user property
            const string userPropertyName = "testUserPropertyName";
            var mockClient = new Mock<IOktaClient>();
            var client = mockClient.Object;

            mockClient.Setup(x=>x.Configuration)
                .Returns(new OktaClientConfiguration()
                {
                    OktaDomain = ExampleOktaDomain
                });


            var createOptions = new SchemaDefinitionProperty()
            {
                Title = "TestTitle"
            };

            mockClient.Setup(x => x.PostAsync<Schema>($"{ExampleOktaDomain}/api/v1/meta/schemas/user/default", 
                    
                    Match.Create<CreateUserPropertyOptions>(
                        opt => opt.Definitions.Custom.GetProperties()[userPropertyName].Title == "TestTitle"),
                    
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new Schema()
                {
                    Id = "Updated schema"
                }));
            
            //WHEN A request is made to create a user property

            var result = await client.Schemas().CreateUserProperty(userPropertyName, createOptions, CancellationToken.None);
            
            //THEN The okta client is invoked with the correct parameters

            Assert.That(result.Id, Is.EqualTo("Updated schema"),
                "The returned object should be the mock expectation");
            
            mockClient.VerifyAll();
        }
    }
}