using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Finbourne.Extensions.Okta.Sdk.Clients;
using Moq;
using NUnit.Framework;
using Okta.Sdk;
using Finbourne.Extensions.Okta.Sdk.Resources;
using Finbourne.Extensions.Okta.Sdk.Resources.Organisations;
using Finbourne.Extensions.Okta.Sdk.Utils;
using Okta.Sdk.Configuration;

namespace Finbourne.Extensions.Okta.Sdk.Tests
{
    [Category("Unit")]
    public class OrganisationsClientTests
    {
        private const string ExampleOktaOrgName = "example";
        private const string ExampleOktaDomain = "https://example.okta.com";
        private const string ExampleOktaToken = "ExampleOktaToken";
        
        [Test]
        public void WillGetAnOrganisationsClientFromOrgsExtensionTest()
        {
            //GIVEN A standard okta client

            var mockClient = new Mock<IOktaClient>();
            var client = mockClient.Object;
            
            //WHEN An attempt is made to get the Organisations client

            var result = client.Organisations();
            
            //THEN The organisations client is returned and correctly populated with the client

            Assert.That(result, Is.InstanceOf<IOrganisationsClient>(), "An orgs client should be returned");
            mockClient.VerifyAll();
        }

        [Test]
        public async Task CanCreateAnOrgTest()
        {
            //GIVEN A valid specifcation for an Okta organisation
            var mockClient = new Mock<IOktaClient>();
            var client = mockClient.Object;

            mockClient.Setup(x=>x.Configuration)
                .Returns(new OktaClientConfiguration()
                {
                    OktaDomain = ExampleOktaDomain
                });
            
            var createOrgOptions = new CreateOrganisationOptions(
                subDomain: "testSubDomain",
                name: "Test New Organisation",
                website: "https://test.org.new.okta.com",
                edition: "EXAMPLE EDITION",
                licensing: new OrganisationLicensing()
                {
                    Apps = new[]{ "example_app" }
                },
                admin: new User
                {
                    Profile = new UserProfile()
                    {
                        Email = "admin@okta.com",
                        FirstName = "TestFirstName",
                        LastName = "TestLastName",
                        Login = "test.login@okta.com",
                        MobilePhone = "012345678",
                        SecondEmail = "second.email@okta.com"
                    },
                    Credentials = new UserCredentials()
                    {
                        RecoveryQuestion = new RecoveryQuestionCredential()
                        {
                            Question = "Recovery question",
                            Answer = "Recovery answer"
                        },
                        Password = new PasswordCredential()
                        {
                            Value = "Secret password value"
                        }
                    }
                });

            mockClient.Setup(x => x.PostAsync<CreatedOrganisation>($"{ExampleOktaDomain}/api/v1/orgs", It.IsAny<object>(),
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new CreatedOrganisation()
                {
                    Token = "Returned token"
                }));
            
            //WHEN A request is made to create an org

            ICreatedOrganisation result = await client.Organisations().CreateOrganisation(createOrgOptions, CancellationToken.None);
            
            //THEN The okta client is invoked with the correct parameters

            Assert.That(result.Token, Is.EqualTo("Returned token"),
                "The returned object should be the mock expectation");
            
            mockClient.VerifyAll();
        }

        [Test]
        public void WillValidateCreateOrgParametersTest()
        {
            //GIVEN Various permutations of incorrectly configured org creation options
            //WHEN They are specified
            //THEN Validation exceptions should be thrown

            Assert.That(() => CreateOptions(), Throws.Nothing, "Base case should pass");
            Assert.That(() => CreateOptions(subDomain:""), Throws.ArgumentException, "Subdomain should be validated");
            Assert.That(() => CreateOptions(subDomain:null), Throws.ArgumentException, "Subdomain should be validated");
            
            Assert.That(() => CreateOptions(name:""), Throws.ArgumentException, "name should be validated");
            Assert.That(() => CreateOptions(name:null), Throws.ArgumentException, "name should be validated");
            
            Assert.That(() => CreateOptions(website:""), Throws.ArgumentException, "website should be validated");
            Assert.That(() => CreateOptions(website:null), Throws.ArgumentException, "website should be validated");
            
            Assert.That(() => CreateOptions(edition:""), Throws.ArgumentException, "edition should be validated");
            Assert.That(() => CreateOptions(edition:null), Throws.ArgumentException, "edition should be validated");
            
            Assert.That(() => CreateOptions(email:""), Throws.ArgumentException, "email should be validated");
            Assert.That(() => CreateOptions(email:null), Throws.ArgumentException, "email should be validated");
            
            Assert.That(() => CreateOptions(firstName:""), Throws.ArgumentException, "firstName should be validated");
            Assert.That(() => CreateOptions(firstName:null), Throws.ArgumentException, "firstName should be validated");
            
            Assert.That(() => CreateOptions(lastName:""), Throws.ArgumentException, "lastName should be validated");
            Assert.That(() => CreateOptions(lastName:null), Throws.ArgumentException, "lastName should be validated");
            
            Assert.That(() => CreateOptions(login:""), Throws.ArgumentException, "login should be validated");
            Assert.That(() => CreateOptions(login:null), Throws.ArgumentException, "login should be validated");
            
            Assert.That(() => CreateOptions(secondEmail:""), Throws.Nothing, "secondEmail should not be validated as is optional");
            Assert.That(() => CreateOptions(secondEmail:null), Throws.Nothing, "secondEmail should not be validated as is optional");
            
            Assert.That(() => CreateOptions(mobilePhone:""), Throws.Nothing, "mobilePhone should not be validated as is optional");
            Assert.That(() => CreateOptions(mobilePhone:null), Throws.Nothing, "mobilePhone should not be validated as is optional");
            
            Assert.That(() => CreateOptions(recoveryQuestion:""), Throws.ArgumentException, "recoveryQuestion should be validated");
            Assert.That(() => CreateOptions(recoveryQuestion:null), Throws.ArgumentException, "recoveryQuestion should be validated");
            
            Assert.That(() => CreateOptions(recoveryAnswer:""), Throws.ArgumentException, "recoveryAnswer should be validated");
            Assert.That(() => CreateOptions(recoveryAnswer:null), Throws.ArgumentException, "recoveryAnswer should be validated");
            
            Assert.That(() => CreateOptions(password:""), Throws.ArgumentException, "password should be validated");
            Assert.That(() => CreateOptions(password:null), Throws.ArgumentException, "password should be validated");
            Assert.That(() => CreateOptions(password:null), Throws.ArgumentException, "password should be validated");

            CreateOrganisationOptions CreateOptions(
                string subDomain = "SomeSubDomain",
                string name = "SomeName",
                string website = "SomeWebsite",
                string edition = "SomeEdition",
                string email = "SomeEmail",
                string firstName = "SomeFirstName",
                string lastName = "SomeLastName",
                string login = "SomeLogin",
                string mobilePhone = "SomeMobilePhone",
                string secondEmail = "SomeSecondEmail",
                string recoveryQuestion = "SomeRecoveryQuestion",
                string recoveryAnswer = "SomeRecoveryAnswer",
                string password = "SomePassword"
            )
            {
                return new CreateOrganisationOptions(
                    subDomain: subDomain,
                    name: name,
                    website: website,
                    edition: edition,
                    licensing: new OrganisationLicensing()
                    {
                        Apps = new[] {"example_app"}
                    },
                    admin: new User
                    {
                        Profile = new UserProfile()
                        {
                            Email = email,
                            FirstName = firstName,
                            LastName = lastName,
                            Login = login,
                            MobilePhone = mobilePhone,
                            SecondEmail = secondEmail
                        },
                        Credentials = new UserCredentials()
                        {
                            RecoveryQuestion = new RecoveryQuestionCredential()
                            {
                                Question = recoveryQuestion,
                                Answer = recoveryAnswer
                            },
                            Password = new PasswordCredential()
                            {
                                Value = password
                            }
                        }
                    });
            }
        }

        [Test]
        public async Task CanGetAnOrganisationTest()
        {
            //GIVEN A known organisation identifier

            string expectedUrl = $"{ExampleOktaDomain}/api/v1/orgs/{ExampleOktaOrgName}";
            
            var mockClient = new Mock<IOktaClient>(MockBehavior.Strict);
            var client = mockClient.Object;
            
            mockClient.Setup(x=>x.Configuration)
                .Returns(new OktaClientConfiguration()
                {
                    OktaDomain = ExampleOktaDomain
                });
            
            mockClient.Setup(x => x.GetAsync<Organisation>(expectedUrl, It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new Organisation { Name = "TestOrg" }));
            
            
            //WHEN A request is made to get an organisation
            
            IOrganisation result = await client.Organisations().GetOrganisation(ExampleOktaOrgName, CancellationToken.None);
            
            //THEN The correct url should be called and all the contents should be suitably deserialised

            Assert.That(result.Name, Is.EqualTo("TestOrg"), "Mocked org should be returned");
            
            mockClient.VerifyAll();
            
        }
        
        [Test]
        public async Task CanGetOrganisationContactsTest()
        {
            //GIVEN A known organisation identifier

            string expectedUrl = $"{ExampleOktaDomain}/api/v1/orgs/{ExampleOktaOrgName}/contacts";
            
            var mockClient = new Mock<IOktaClient>(MockBehavior.Strict);
            var client = mockClient.Object;
            
            mockClient.Setup(x=>x.Configuration)
                .Returns(new OktaClientConfiguration()
                {
                    OktaDomain = ExampleOktaDomain
                });
            
            mockClient.Setup(x => x.GetAsync<OrganisationContacts>(expectedUrl, It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new OrganisationContacts { Support = new EndUserSupport(){PhoneNumber = "1234"}}));
            
            
            //WHEN A request is made to get an organisation's contacts
            
            IOrganisationContacts result = await client.Organisations().GetOrganisationContacts(ExampleOktaOrgName, CancellationToken.None);
            
            //THEN The correct url should be called and all the contents should be suitably deserialised

            Assert.That(result.Support.PhoneNumber, Is.EqualTo("1234"), "Mocked org should be returned");
            
            mockClient.VerifyAll();
            
        }
        
        [Test]
        public async Task CanGetOrganisationPolicyTest()
        {
            //GIVEN A known organisation identifier

            string expectedUrl = $"{ExampleOktaDomain}/api/v1/orgs/{ExampleOktaOrgName}/policy";
            
            var mockClient = new Mock<IOktaClient>(MockBehavior.Strict);
            var client = mockClient.Object;
            
            mockClient.Setup(x=>x.Configuration)
                .Returns(new OktaClientConfiguration()
                {
                    OktaDomain = ExampleOktaDomain
                });
            
            mockClient.Setup(x => x.GetAsync<OrganisationPolicy>(expectedUrl, It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new OrganisationPolicy() {AccountRecovery = new OrganisationAccountRecovery(){SmsPasswordReset = true}}));
            
            
            //WHEN A request is made to get an organisation's policy
            
            IOrganisationPolicy result = await client.Organisations().GetOrganisationPolicy(ExampleOktaOrgName, CancellationToken.None);
            
            //THEN The correct url should be called and all the contents should be suitably deserialised

            Assert.That(result.AccountRecovery.SmsPasswordReset, Is.True, "Mocked org should be returned");
            
            mockClient.VerifyAll();
            
        }
    }
}