using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Finbourne.Extensions.Okta.Sdk.Clients;
using Finbourne.Extensions.Okta.Sdk.Resources.AuthorisationServers;
using Finbourne.Extensions.Okta.Sdk.Resources.Tokens;
using Finbourne.Extensions.Okta.Sdk.Utils;
using Moq;
using NUnit.Framework;
using Okta.Sdk;
using Okta.Sdk.Configuration;

namespace Finbourne.Extensions.Okta.Sdk.Tests
{
    [Category("Unit")]
    public class TokensClientTests
    {
        private const string ExampleTokenId = "exampleTokenId";
        private const string ExampleOktaDomain = "https://example.okta.com";
        
        [Test]
        public void WillGetATokensClientFromOrgsExtensionTest()
        {
            //GIVEN A standard okta client

            var mockClient = new Mock<IOktaClient>();
            var client = mockClient.Object;
            
            //WHEN An attempt is made to get the Tokens client

            var result = client.Tokens();
            
            //THEN The client is returned and correctly populated with the client

            Assert.That(result, Is.InstanceOf<ITokensClient>(), "The correct client should be returned");
            mockClient.VerifyAll();
        }


        [Test]
        public async Task CanCreateATokenTest()
        {
            //GIVEN A valid specifcation for an Okta token
            var mockClient = new Mock<IOktaClient>();
            var client = mockClient.Object;

            mockClient.Setup(x=>x.Configuration)
                .Returns(new OktaClientConfiguration()
                {
                    OktaDomain = ExampleOktaDomain
                });


            var createOptions = new CreateTokenOptions()
            {
                Name = "testTokenName"
            };

            mockClient.Setup(x => x.PostAsync<PopulatedToken>($"{ExampleOktaDomain}/api/internal/tokens?expand=user", It.IsAny<object>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new PopulatedToken()
                {
                    Token = "Example Returned token"
                }));
            
            //WHEN A request is made to create a token

            var result = await client.Tokens().CreateToken(createOptions, CancellationToken.None);
            
            //THEN The okta client is invoked with the correct parameters

            Assert.That(result.Token, Is.EqualTo("Example Returned token"),
                "The returned object should be the mock expectation");
            
            mockClient.VerifyAll();
        }
        
        [Test]
        public async Task CanListTokensTest()
        {
            //GIVEN An org that has more than one token in it
            
            string expectedUrl = $"{ExampleOktaDomain}/api/internal/tokens?expand=user";

            var testItems = new[]
            {
                new TokenInfo() {Id = "Id1"},
                new TokenInfo() {Id = "Id2"},
            };
            
            
            var mockClient = new Mock<IOktaClient>(MockBehavior.Strict);
            var client = mockClient.Object;
            
            mockClient.Setup(x=>x.Configuration)
                .Returns(new OktaClientConfiguration()
                {
                    OktaDomain = ExampleOktaDomain
                });

            mockClient.Setup(x => x.GetCollection<TokenInfo>(expectedUrl))
                .Returns(TestHelpers.CreateCollectionClient<TokenInfo>(testItems));
            
            //WHEN A request is made to get an authorisation server's policies
            
            var results = await client.Tokens()
                .ListTokens()
                .ToListAsync(CancellationToken.None);
            
            //THEN The correct url should be called and all the contents should be suitably de-serialised

            Assert.That(results.Count, Is.EqualTo(2), "Unexpected number of items returned");
            
            Assert.That(results.ElementAt(0).Id, Is.EqualTo("Id1"), "Unexpected value for item");
            Assert.That(results.ElementAt(1).Id, Is.EqualTo("Id2"), "Unexpected value for item");
            
            mockClient.VerifyAll();   
        }
    }
}