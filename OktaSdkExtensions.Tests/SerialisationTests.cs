using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Finbourne.Extensions.Okta.Sdk.Resources;
using Finbourne.Extensions.Okta.Sdk.Resources.Applications;
using Finbourne.Extensions.Okta.Sdk.Resources.AuthorisationServers;
using Finbourne.Extensions.Okta.Sdk.Resources.IdentityProviders;
using Finbourne.Extensions.Okta.Sdk.Resources.Organisations;
using Finbourne.Extensions.Okta.Sdk.Resources.Schemas;
using Finbourne.Extensions.Okta.Sdk.Resources.Settings;
using Finbourne.Extensions.Okta.Sdk.Resources.Tokens;
using Finbourne.Extensions.Okta.Sdk.Resources.TrustedOrigins;
using Finbourne.Extensions.Okta.Sdk.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NUnit.Framework;
using Okta.Sdk;
using Okta.Sdk.Internal;

namespace Finbourne.Extensions.Okta.Sdk.Tests
{
    public class SerialisationTests
    {
        private static readonly IList<string> EmptyList = new List<string>();
        private static IList<T> Empty<T>() => new List<T>();
        
        #region Organisations
        [Test]
        public void CanDeserialiseAnOrganisationTest()
        {
            //GIVEN Some valid response json for an organisation
            //WHEN The request is deserialised into its type

            var obj = GetFromOktaResponse<Organisation>("Organisations/GetOrganisation.json");
            
            //THEN All fields are present and populated

            AreEqual(obj.Id, "UniqueOktaIdCode123", nameof(obj.Id));
            AreEqual(obj.SubDomain, "testorganisation", nameof(obj.SubDomain));
            AreEqual(obj.Name, "Test Organisation", nameof(obj.Name));
            AreEqual(obj.Website, "https://testorganisation.com", nameof(obj.Website));
            AreEqual(obj.Status, "ACTIVE", nameof(obj.Status));
            AreEqual(obj.Edition, "SKU", nameof(obj.Edition));
            AreEqual(obj.ExpiresAt, null, nameof(obj.ExpiresAt));
            AreEqual(obj.Created, DateTimeOffset.Parse("2017-02-27T08:47:48.000Z"), nameof(obj.Created));
            AreEqual(obj.LastUpdated, DateTimeOffset.Parse("2019-03-01T03:01:06.000Z"), nameof(obj.LastUpdated));
            
            AreEqual(obj.Licensing.Apps.Single(), "testOrgApplication", $"Licensing.Apps");
            
            AreEqual(obj.Settings.App.ErrorRedirectUrl, "https://errorRedirectUrl", $"Settings.App.ErrorRedirectUrl");
            AreEqual(obj.Settings.App.InterstitialUrl, "https://interstitialUrl", $"Settings.App.InterstitialUrl");
            AreEqual(obj.Settings.App.InterstitialMinWaitTime, 1200, $"Settings.App.InterstitialMinWaitTime");
            
            AreEqual(obj.Settings.UserAccount.Attributes.SecondaryEmail, true, $"Settings.UserAccount.Attributes.SecondaryEmail");
            AreEqual(obj.Settings.UserAccount.Attributes.SecondaryImage, true, $"Settings.UserAccount.Attributes.SecondaryImage");
            
            AreEqual(obj.Settings.Portal.ErrorRedirectUrl, "https://portalErrorRedirectUrl", $"Settings.Portal.ErrorRedirectUrl");
            AreEqual(obj.Settings.Portal.SignOutUrl, "https://portalSignOutUrl", $"Settings.Portal.SignOutUrl");
            AreEqual(obj.Settings.Logs.Level, "INFO", $"Settings.Logs.Level");
        }


        [Test]
        public void CanDeserialiseOrganisationContactsTest()
        {
            //GIVEN A valid response
            //WHEN The request is deserialised into its type
            
            var obj = GetFromOktaResponse<OrganisationContacts>("Organisations/GetContacts.json");
            
            //THEN All fields are present and populated

            AreEqual(obj.Support.PhoneNumber, "0123456789", "Support.PhoneNumber");
            AreEqual(obj.Organization.Country, "GBR", "Support.Country");
            AreEqual(obj.Organization.PostalCode, "SW1A 1AA", "Support.PostalCode");
            AreEqual(obj.Organization.Locality, "London", "Support.Locality");
            
            AreEqual(obj.Organization.StreetAddress.First(), "123 Example Road, London", "Organization.StreetAddress");
        }
        
        
        [Test]
        public void CanDeserialiseOrganisationPolicyTest()
        {
            //GIVEN A valid response
            //WHEN The request is deserialised into its type
            
            var obj = GetFromOktaResponse<OrganisationPolicy>("Organisations/GetPolicy.json");
            
            //THEN All fields are present and populated

            AreEqual(obj.TokenLifetime.IdleSession, 120, "TokenLifetime.IdleSession");
            AreEqual(obj.TokenLifetime.Activation, 168, "TokenLifetime.Activation");
            
            AreEqual(obj.JitProvisioning.Enabled, true, "JitProvisioning.Enabled");
            AreEqual(obj.AccountRecovery.SmsPasswordReset, false, "AccountRecovery.SmsPasswordReset");
            AreEqual(obj.IdpSettings.DefaultIdp, "Dummy", "IdpSettings.DefaultIdp");
            AreEqual(obj.Visibility.Hide.RememberMe, false, "Visibility.Hide.RememberMe");
            AreEqual(obj.Visibility.Hide.LockedStatus, true, "Visibility.Hide.LockedStatus");
        }
        #endregion
        
        #region AuthServers
        [Test]
        public void CanDeserialiseAuthorisationServerTest()
        {
            //GIVEN A valid response
            //WHEN The request is deserialised into its type
            
            var obj = GetFromOktaResponse<AuthorisationServer>("AuthorisationServers/GetAuthorisationServer.json");
            
            //THEN All fields are present and populated

            AreEqual(obj.Id, "exampleOktaUniqueAuthServerId", nameof(obj.Id));
            AreEqual(obj.Name, "example-auth-server", nameof(obj.Name));
            AreEqual(obj.Description, "Example authorisation server", nameof(obj.Description));
            AreEqual(obj.Status, "ACTIVE", nameof(obj.Status));
            AreEqual(obj.Issuer, "https://testorganisation.okta.com/oauth2/exampleOktaUniqueAuthServerId", nameof(obj.Issuer));
            AreEqual(obj.Created, DateTimeOffset.Parse("2017-08-15T13:29:31.000"), nameof(obj.Created));
            AreEqual(obj.LastUpdated, DateTimeOffset.Parse("2017-08-15T13:29:31.000"), nameof(obj.LastUpdated));
            
            AreEqual(obj.Audiences.First(), "exampleapi.testorganisation.com", nameof(obj.Audiences));
            
            AreEqual(obj.Credentials.Signing.Kid, "ABC123-ABCDEFGHIJKLMNOPQRSTUVRJQDBa6go", "Credentials.Signing.Kid");
            AreEqual(obj.Credentials.Signing.RotationMode, "AUTO", "Credentials.Signing.RotationMode");
            AreEqual(obj.Credentials.Signing.LastRotated, DateTimeOffset.Parse("2019-02-11T03:01:05.000"), "Credentials.Signing.LastRotated");
            AreEqual(obj.Credentials.Signing.NextRotation, DateTimeOffset.Parse("2019-05-12T03:01:05.000"), "Credentials.Signing.NextRotation");
            
        }
        
        
        [Test]
        public void CanDeserialiseAuthorisationServerPoliciesTest()
        {
            //GIVEN A valid response
            //WHEN The request is deserialised into its type
            
            var list = GetFromOktaArrayResponse<AuthorisationServerPolicy>("AuthorisationServers/GetPolicies.json");
            var obj = list.Single();
            
            //THEN All fields are present and populated

            AreEqual(obj.Id, "ExampleAuthorisationServerPolicyUid", nameof(obj.Id));
            AreEqual(obj.Name, "default", nameof(obj.Name));
            AreEqual(obj.Description, "default policy", nameof(obj.Description));
            AreEqual(obj.Status, "INACTIVE", nameof(obj.Status));
            AreEqual(obj.Type, "OAUTH_AUTHORIZATION_POLICY", nameof(obj.Type));
            AreEqual(obj.Created, DateTimeOffset.Parse("2017-08-15T13:29:39.000"), nameof(obj.Created));
            AreEqual(obj.LastUpdated, DateTimeOffset.Parse("2018-10-27T16:09:07.000"), nameof(obj.LastUpdated));
            AreEqual(obj.Priority, 1, nameof(obj.Priority));
            AreEqual(obj.System, false, nameof(obj.System));
            
            AreEqual(obj.Conditions.Clients.Include.First(), "example client include", "Conditions.Clients.Include"); 
            AreEqual(obj.Conditions.Clients.Exclude.First(), "example client exclude", "Conditions.Clients.Exclude"); 
        }
        
        [Test]
        public void CanDeserialiseAuthorisationServerPolicyRulesTest()
        {
            //GIVEN A valid response
            //WHEN The request is deserialised into its type
            
            var list = GetFromOktaArrayResponse<AuthorisationServerPolicyRule>("AuthorisationServers/GetPolicyRules.json");
            var obj = list.Single();
            
            //THEN All fields are present and populated

            AreEqual(obj.Id, "examplepolicyruleuniqueid1", nameof(obj.Id));
            AreEqual(obj.Name, "Default policy rule name", nameof(obj.Name));
            AreEqual(obj.Status, "ACTIVE", nameof(obj.Status));
            AreEqual(obj.Type, "RESOURCE_ACCESS", nameof(obj.Type));
            AreEqual(obj.Created, DateTimeOffset.Parse("2017-08-15T13:29:40.000"), nameof(obj.Created));
            AreEqual(obj.LastUpdated, DateTimeOffset.Parse("2017-08-15T13:29:40.000"), nameof(obj.LastUpdated));
            AreEqual(obj.Priority, 1, nameof(obj.Priority));
            AreEqual(obj.System, false, nameof(obj.System));
            
            AreEqual(obj.Conditions.People.Users.Include.First(), "includedUser", "Conditions.People.Users.Include");
            AreEqual(obj.Conditions.People.Users.Exclude.First(), "excludedUser", "Conditions.People.Users.Exclude");
            
            AreEqual(obj.Conditions.People.Groups.Include.First(), "EVERYONE", "Conditions.People.GroupsGroups.Include");
            AreEqual(obj.Conditions.People.Groups.Exclude.First(), "excludedGroupUser","Conditions.People.Users.Exclude");
            
            
            AreEqual(obj.Conditions.GrantTypes.Include.First(), "implicit", "Conditions.GrantTypes.Include");
            AreEqual(obj.Conditions.GrantTypes.Exclude.First(), "grantTypeToExclude", "Conditions.GrantTypes.Exclude");
            
            AreEqual(obj.Conditions.Scopes.Include.First(), "*", "Conditions.Scopes.Include");
            AreEqual(obj.Conditions.Scopes.Exclude.First(), "scopesExclude", "Conditions.Scopes.Exclude");

            AreEqual(obj.Actions.Token.AccessTokenLifetimeMinutes, 60, "Actions.Token.AccessTokenLifetimeMinutes");
            AreEqual(obj.Actions.Token.RefreshTokenWindowMinutes, 10080, "Actions.Token.RefreshTokenWindowMinutes");
            AreEqual(obj.Actions.Token.RefreshTokenLifetimeMinutes, 5, "Actions.Token.RefreshTokenLifetimeMinutes");
        }
        
        
        
        [Test]
        public void CanDeserialiseAuthorisationServerClaimsTest()
        {
            //GIVEN A valid response
            //WHEN The request is deserialised into its type
            
            var list = GetFromOktaArrayResponse<AuthorisationServerClaim>("AuthorisationServers/GetClaims.json");
            var obj = list.Single();
            
            //THEN All fields are present and populated

            AreEqual(obj.Id, "testclaimid1", nameof(obj.Id));
            AreEqual(obj.Name, "custom-claim-name", nameof(obj.Name));
            
            AreEqual(obj.Status, "ACTIVE", nameof(obj.Status));
            AreEqual(obj.ClaimType, "RESOURCE", nameof(obj.ClaimType));
            AreEqual(obj.ValueType, "EXPRESSION", nameof(obj.ValueType));
            AreEqual(obj.Value, "user.customclaimval", nameof(obj.Value));
            AreEqual(obj.System, false, nameof(obj.System));
            AreEqual(obj.AlwaysIncludeInToken, true, nameof(obj.AlwaysIncludeInToken));
            
            AreEqual(obj.Conditions.Scopes.Single(), "test-condition-scope", "Conditions.Scopes");  
        }
        
        #endregion
        
        #region Tokens
        [Test]
        public void CanDeserialisePopulatedTokenTest()
        {
            //GIVEN A valid response
            //WHEN The request is deserialised into its type
            
            var obj = GetFromOktaResponse<PopulatedToken>("Tokens/CreateToken.json");
            
            //THEN All fields are present and populated

            AreEqual(obj.TokenType, "orn:okta:token:ssws", nameof(obj.TokenType));
            AreEqual(obj.ClientName, "Okta API", nameof(obj.ClientName));
            AreEqual(obj.Id, "ExampleUniqueTokenId", nameof(obj.Id));
            AreEqual(obj.Name, "Example created token name", nameof(obj.Name));
            AreEqual(obj.Status, "ACTIVE", nameof(obj.Status));
            AreEqual(obj.Created, DateTimeOffset.Parse("2019-03-04T08:59:20.000"), nameof(obj.Created));
            AreEqual(obj.LastUpdated, DateTimeOffset.Parse("2019-03-04T08:59:20.000"), nameof(obj.LastUpdated));
            AreEqual(obj.ExpiresAt, DateTimeOffset.Parse("2019-04-03T08:59:20.000"), nameof(obj.ExpiresAt));
            AreEqual(obj.Token, "Example Secret Token", nameof(obj.ExpiresAt));
            
            AreEqual(obj.Embedded.User.Id, "CreatingUserId", "Embedded.User.Id");
            AreEqual(obj.Embedded.User.DisplayName, "Example User", "Embedded.User.DisplayName");
            AreEqual(obj.Embedded.User.Login, "example.user@exampledomain.com", "Embedded.User.Login");
            AreEqual(obj.Embedded.User.Role, "Super Admin", "Embedded.User.Roled");
        }
        
        
        [Test]
        public void CanDeserialiseListOfTokenInfoTest()
        {
            //GIVEN A valid response
            //WHEN The request is deserialised into its type
            
            var list = GetFromOktaArrayResponse<TokenInfo>("Tokens/ListTokens.json");
            var obj = list.Single();
            
            //THEN All fields are present and populated

            AreEqual(obj.TokenType, "orn:okta:token:ssws", nameof(obj.TokenType));
            AreEqual(obj.ClientName, "Okta API", nameof(obj.ClientName));
            AreEqual(obj.Id, "exampleUniqueTokenId", nameof(obj.Id));
            AreEqual(obj.Name, "Example Token Name", nameof(obj.Name));
            AreEqual(obj.Status, "ACTIVE", nameof(obj.Status));
            AreEqual(obj.Created, DateTimeOffset.Parse("2019-01-24T22:44:41.000"), nameof(obj.Created));
            AreEqual(obj.LastUpdated, DateTimeOffset.Parse("2019-03-04T08:58:56.000"), nameof(obj.LastUpdated));
            AreEqual(obj.ExpiresAt, DateTimeOffset.Parse("2019-04-03T08:58:56.000"), nameof(obj.ExpiresAt));
            
            AreEqual(obj.Embedded.User.Id, "exampleUserId1", "Embedded.User.Id");
            AreEqual(obj.Embedded.User.DisplayName, "Example User Number One", "Embedded.User.DisplayName");
            AreEqual(obj.Embedded.User.Login, "example.user1@exampledomain.com", "Embedded.User.Login");
            AreEqual(obj.Embedded.User.Role, "Super Admin", "Embedded.User.Roled");
        }
        #endregion

        #region Trusted Origin
        [Test]
        public void CanDeserialiseACreateTrustedOriginResponseTest()
        {
            //GIVEN A valid response
            //WHEN The request is deserialised into its type
            
            var obj = GetFromOktaResponse<TrustedOrigin>("TrustedOrigins/CreateTrustedOrigin.json");
            
            //THEN All fields are present and populated

            AreEqual(obj.Id, "trustedoriginuniqueId", nameof(obj.Id));
            AreEqual(obj.Name, "Test Trusted Origin", nameof(obj.Name));
            AreEqual(obj.Origin, "https://originurl", nameof(obj.Origin));
            
            AreEqual(obj.Status, "ACTIVE", nameof(obj.Status));
            AreEqual(obj.Created, DateTimeOffset.Parse("2019-03-04T16:44:23.000"), nameof(obj.Created));
            AreEqual(obj.CreatedBy, "createdUserId", nameof(obj.CreatedBy));
            AreEqual(obj.LastUpdated, DateTimeOffset.Parse("2019-03-04T16:44:23.000"), nameof(obj.LastUpdated));
            AreEqual(obj.LastUpdatedBy, "modifiedByUserId", nameof(obj.LastUpdatedBy));
            
            AreEqual(obj.Scopes.First().Type, "CORS", "Scopes.Type");
        }
        
        
        [Test]
        public void CanDeserialiseAListOfTrustedOriginResponseTest()
        {
            //GIVEN A valid response
            //WHEN The request is deserialised into its type
            
            var list = GetFromOktaArrayResponse<TrustedOrigin>("TrustedOrigins/ListTrustedOrigins.json");
            var obj = list.Single();
            
            //THEN All fields are present and populated

            AreEqual(obj.Id, "trustedoriginuniqueId", nameof(obj.Id));
            AreEqual(obj.Name, "Test Trusted Origin", nameof(obj.Name));
            AreEqual(obj.Origin, "https://originurl", nameof(obj.Origin));
            
            AreEqual(obj.Status, "ACTIVE", nameof(obj.Status));
            AreEqual(obj.Created, DateTimeOffset.Parse("2019-03-04T16:44:23.000"), nameof(obj.Created));
            AreEqual(obj.CreatedBy, "createdUserId", nameof(obj.CreatedBy));
            AreEqual(obj.LastUpdated, DateTimeOffset.Parse("2019-03-04T16:44:23.000"), nameof(obj.LastUpdated));
            AreEqual(obj.LastUpdatedBy, "modifiedByUserId", nameof(obj.LastUpdatedBy));
            
            AreEqual(obj.Scopes.First().Type, "CORS", "Scopes.Type");
        }
        #endregion
        
        #region Schemas
        [Test]
        public void CanDeserialiseAGetDefaultSchemaResponseTest()
        {
            //GIVEN A valid response
            //WHEN The request is deserialised into its type
            
            var obj = GetFromOktaResponse<Schema>("Schemas/GetDefault.json");
            
            //THEN All fields are present and populated

            AreEqual(obj.Id, "https://exampledomain.okta.com/meta/schemas/user/default", nameof(obj.Id));
            AreEqual(obj.Name, "user", nameof(obj.Name));
            AreEqual(obj.Title, "User", nameof(obj.Title));
            AreEqual(obj.Description, "Okta user profile template with default permission settings", nameof(obj.Description));
            AreEqual(obj.Created, DateTimeOffset.Parse("2017-02-27T08:47:49.000"), nameof(obj.Created));
            AreEqual(obj.LastUpdated, DateTimeOffset.Parse("2018-11-30T09:55:44.000"), nameof(obj.LastUpdated));
            
            //Custom property 1
            AreEqual(obj.Definitions.Custom.Id, "#custom", "Definitions.Custom.Id");
            AreEqual(obj.Definitions.Custom.Type, "object", "Definitions.Custom.Type");
            AreEqual(obj.Definitions.Custom.Required[0], "client", "Definitions.Custom.Required[0]");
            AreEqual(obj.Definitions.Custom.Required[1], "employee", "Definitions.Custom.Required[1]");
            
            
            AreEqual(obj.Definitions.Custom.GetProperties()["exampleProperty1"].Title, "Example Property One", "Definitions.Custom.Properties[].Title");
            AreEqual(obj.Definitions.Custom.GetProperties()["exampleProperty1"].Description, "The first example property", "Definitions.Custom.Properties[].Description");
            AreEqual(obj.Definitions.Custom.GetProperties()["exampleProperty1"].Type, "string", "Definitions.Custom.Properties[].Type");
            AreEqual(obj.Definitions.Custom.GetProperties()["exampleProperty1"].Required, true, "Definitions.Custom.Properties[].Required");
            AreEqual(obj.Definitions.Custom.GetProperties()["exampleProperty1"].Mutability, "READ_WRITE", "Definitions.Custom.Properties[].Mutability");
            AreEqual(obj.Definitions.Custom.GetProperties()["exampleProperty1"].Scope, "NONE", "Definitions.Custom.Properties[].Scope");
            AreEqual(obj.Definitions.Custom.GetProperties()["exampleProperty1"].Permissions.Single().Action, "READ_ONLY", "Definitions.Custom.Properties[].Permissions.Action");
            AreEqual(obj.Definitions.Custom.GetProperties()["exampleProperty1"].Permissions.Single().Principal, "SELF", "Definitions.Custom.Properties[].Permissions.Principal");
            AreEqual(obj.Definitions.Custom.GetProperties()["exampleProperty1"].Master.Type, "OKTA","Definitions.Custom.Properties[].Master.Type");
            
            //Custom property 2
            AreEqual(obj.Definitions.Custom.GetProperties()["exampleProperty2"].Title, "Example Property Two", "Definitions.Custom.Properties[].Title");
            AreEqual(obj.Definitions.Custom.GetProperties()["exampleProperty2"].Description, "The second example property", "Definitions.Custom.Properties[].Description");
            AreEqual(obj.Definitions.Custom.GetProperties()["exampleProperty2"].Type, "string", "Definitions.Custom.Properties[].Type");
            AreEqual(obj.Definitions.Custom.GetProperties()["exampleProperty2"].Required, null, "Definitions.Custom.Properties[].Required");
            AreEqual(obj.Definitions.Custom.GetProperties()["exampleProperty2"].Mutability, "READ_WRITE", "Definitions.Custom.Properties[].Mutability");
            AreEqual(obj.Definitions.Custom.GetProperties()["exampleProperty2"].Scope, "NONE", "Definitions.Custom.Properties[].Scope");
            AreEqual(obj.Definitions.Custom.GetProperties()["exampleProperty2"].Permissions.Single().Action, "READ_ONLY", "Definitions.Custom.Properties[].Permissions.Action");
            AreEqual(obj.Definitions.Custom.GetProperties()["exampleProperty2"].Permissions.Single().Principal, "SELF", "Definitions.Custom.Properties[].Permissions.Principal");
            AreEqual(obj.Definitions.Custom.GetProperties()["exampleProperty2"].Master.Type, "OKTA","Definitions.Custom.Properties[].Master.Type");

            //Base property 1            
            AreEqual(obj.Definitions.Base.Id, "#base", "Definitions.Base.Id");
            AreEqual(obj.Definitions.Base.Type, "object", "Definitions.Base.Type");
            AreEqual(obj.Definitions.Base.GetProperties()["login"].Title, "Username", "Definitions.Base.Properties[].Title");
            AreEqual(obj.Definitions.Base.GetProperties()["login"].Description, null, "Definitions.Base.Properties[].Description");
            AreEqual(obj.Definitions.Base.GetProperties()["login"].Type, "string", "Definitions.Base.Properties[].Type");
            AreEqual(obj.Definitions.Base.GetProperties()["login"].Required, true, "Definitions.Base.Properties[].Required");
            AreEqual(obj.Definitions.Base.GetProperties()["login"].Mutability, "READ_WRITE", "Definitions.Base.Properties[].Mutability");
            AreEqual(obj.Definitions.Base.GetProperties()["login"].Scope, "NONE", "Definitions.Base.Properties[].Scope");
            
            AreEqual(obj.Definitions.Base.GetProperties()["login"].MaxLength, 100, "Definitions.Base.Properties[].MaxLength");
            AreEqual(obj.Definitions.Base.GetProperties()["login"].MinLength, 5, "Definitions.Base.Properties[].MinLength");
            
            AreEqual(obj.Definitions.Base.GetProperties()["login"].Permissions.Single().Action, "READ_ONLY", "Definitions.Base.Properties[].Permissions.Action");
            AreEqual(obj.Definitions.Base.GetProperties()["login"].Permissions.Single().Principal, "SELF", "Definitions.Base.Properties[].Permissions.Principal");
            AreEqual(obj.Definitions.Base.GetProperties()["login"].Master.Type, "PROFILE_MASTER","Definitions.Base.Properties[].Master.Type");
            
            //Base property 1
            AreEqual(obj.Definitions.Base.Id, "#base", "Definitions.Base.Id");
            AreEqual(obj.Definitions.Base.Type, "object", "Definitions.Base.Type");
            AreEqual(obj.Definitions.Base.GetProperties()["firstName"].Title, "First name", "Definitions.Base.Properties[].Title");
            AreEqual(obj.Definitions.Base.GetProperties()["firstName"].Description, null, "Definitions.Base.Properties[].Description");
            AreEqual(obj.Definitions.Base.GetProperties()["firstName"].Type, "string", "Definitions.Base.Properties[].Type");
            AreEqual(obj.Definitions.Base.GetProperties()["firstName"].Required, true, "Definitions.Base.Properties[].Required");
            AreEqual(obj.Definitions.Base.GetProperties()["firstName"].Mutability, "READ_WRITE", "Definitions.Base.Properties[].Mutability");
            AreEqual(obj.Definitions.Base.GetProperties()["firstName"].Scope, "NONE", "Definitions.Base.Properties[].Scope");
            
            AreEqual(obj.Definitions.Base.GetProperties()["firstName"].MaxLength, 50, "Definitions.Base.Properties[].MaxLength");
            AreEqual(obj.Definitions.Base.GetProperties()["firstName"].MinLength, 1, "Definitions.Base.Properties[].MinLength");
            
            AreEqual(obj.Definitions.Base.GetProperties()["firstName"].Permissions.Single().Action, "READ_WRITE", "Definitions.Base.Properties[].Permissions.Action");
            AreEqual(obj.Definitions.Base.GetProperties()["firstName"].Permissions.Single().Principal, "SELF", "Definitions.Base.Properties[].Permissions.Principal");
            AreEqual(obj.Definitions.Base.GetProperties()["firstName"].Master.Type, "PROFILE_MASTER","Definitions.Base.Properties[].Master.Type");
            
            
            AreEqual(obj.Definitions.Base.Required[0], "login", "Definitions.Custom.Required[0]");
            AreEqual(obj.Definitions.Base.Required[1], "firstName", "Definitions.Base.Required[1]");
            AreEqual(obj.Definitions.Base.Required[2], "lastName", "Definitions.Base.Required[2]");
            AreEqual(obj.Definitions.Base.Required[3], "email", "Definitions.Base.Required[3]");
            
        }
        
        
        [Test]
        public void CanDeserialiseAGetApplicationSchemaResponseTest()
        {
            //GIVEN A valid response
            //WHEN The request is deserialised into its type
            
            var obj = GetFromOktaResponse<Schema>("Schemas/GetApplicationUserSchema.json");
            
            //THEN All fields are present and populated

            AreEqual(obj.Id, "https://exampledomain.okta.com/meta/schemas/apps/exampleuniqueapplicationid/default", nameof(obj.Id));
            AreEqual(obj.Name, "exampleAppProfileName1", nameof(obj.Name));
            AreEqual(obj.Title, "Example Application User", nameof(obj.Title));
            AreEqual(obj.Created, DateTimeOffset.Parse("2018-11-29T18:21:08.000"), nameof(obj.Created));
            AreEqual(obj.LastUpdated, DateTimeOffset.Parse("2018-11-29T21:53:22.000"), nameof(obj.LastUpdated));
            
            //Custom property 1
            AreEqual(obj.Definitions.Custom.Id, "#custom", "Definitions.Custom.Id");
            AreEqual(obj.Definitions.Custom.Type, "object", "Definitions.Custom.Type");
            AreEqual(obj.Definitions.Custom.Required.Count, 0, "Definitions.Custom.Required");
            AreEqual(obj.Definitions.Custom.GetProperties()["exampleProperty1"].Title, "Example Property One", "Definitions.Custom.Properties[].Title");
            AreEqual(obj.Definitions.Custom.GetProperties()["exampleProperty1"].Description, "The first example property", "Definitions.Custom.Properties[].Description");
            AreEqual(obj.Definitions.Custom.GetProperties()["exampleProperty1"].Type, "string", "Definitions.Custom.Properties[].Type");
            AreEqual(obj.Definitions.Custom.GetProperties()["exampleProperty1"].Required, null, "Definitions.Custom.Properties[].Required");
            AreEqual(obj.Definitions.Custom.GetProperties()["exampleProperty1"].Mutability, null, "Definitions.Custom.Properties[].Mutability");
            AreEqual(obj.Definitions.Custom.GetProperties()["exampleProperty1"].Scope, "NONE", "Definitions.Custom.Properties[].Scope");
            AreEqual(obj.Definitions.Custom.GetProperties()["exampleProperty1"].Permissions, EmptyList, "Definitions.Custom.Properties[].Permissions");
            AreEqual(obj.Definitions.Custom.GetProperties()["exampleProperty1"].Master.Type, "PROFILE_MASTER","Definitions.Custom.Properties[].Master.Type");
            
            //Base property 2
            AreEqual(obj.Definitions.Base.Id, "#base", "Definitions.Base.Id");
            AreEqual(obj.Definitions.Base.Type, "object", "Definitions.Base.Type");
            AreEqual(obj.Definitions.Base.GetProperties()["userName"].Title, "Username", "Definitions.Base.Properties[].Title");
            AreEqual(obj.Definitions.Base.GetProperties()["userName"].Description, null, "Definitions.Base.Properties[].Description");
            AreEqual(obj.Definitions.Base.GetProperties()["userName"].Type, "string", "Definitions.Base.Properties[].Type");
            AreEqual(obj.Definitions.Base.GetProperties()["userName"].Required, true, "Definitions.Base.Properties[].Required");
            AreEqual(obj.Definitions.Base.GetProperties()["userName"].Mutability, null, "Definitions.Base.Properties[].Mutability");
            AreEqual(obj.Definitions.Base.GetProperties()["userName"].Scope, "NONE", "Definitions.Base.Properties[].Scope");
            
            AreEqual(obj.Definitions.Base.GetProperties()["userName"].MaxLength, 100, "Definitions.Base.Properties[].MaxLength");
            AreEqual(obj.Definitions.Base.GetProperties()["userName"].MinLength, null, "Definitions.Base.Properties[].MinLength");
            
            AreEqual(obj.Definitions.Base.GetProperties()["userName"].Permissions, EmptyList, "Definitions.Base.Properties[].Permissions");
            AreEqual(obj.Definitions.Base.GetProperties()["userName"].Master.Type, "PROFILE_MASTER","Definitions.Base.Properties[].Master.Type");
            
            
            //Base property 1
            AreEqual(obj.Definitions.Base.Id, "#base", "Definitions.Base.Id");
            AreEqual(obj.Definitions.Base.Type, "object", "Definitions.Base.Type");
            AreEqual(obj.Definitions.Base.GetProperties()["initialStatus"].Title, "Initial status", "Definitions.Base.Properties[].Title");
            AreEqual(obj.Definitions.Base.GetProperties()["initialStatus"].Description, null, "Definitions.Base.Properties[].Description");
            AreEqual(obj.Definitions.Base.GetProperties()["initialStatus"].Type, "string", "Definitions.Base.Properties[].Type");
            AreEqual(obj.Definitions.Base.GetProperties()["initialStatus"].Required, true, "Definitions.Base.Properties[].Required");
            AreEqual(obj.Definitions.Base.GetProperties()["initialStatus"].Mutability, null, "Definitions.Base.Properties[].Mutability");
            AreEqual(obj.Definitions.Base.GetProperties()["initialStatus"].Scope, "NONE", "Definitions.Base.Properties[].Scope");
            
            AreEqual(obj.Definitions.Base.GetProperties()["initialStatus"].Enum[0], "active_with_pass", "Definitions.Base.Properties[].Enum[0]");
            AreEqual(obj.Definitions.Base.GetProperties()["initialStatus"].Enum[1], "pending_with_pass", "Definitions.Base.Properties[].Enum[1]");
            AreEqual(obj.Definitions.Base.GetProperties()["initialStatus"].Enum[2], "active_without_pass", "Definitions.Base.Properties[].Enum[2]");
            AreEqual(obj.Definitions.Base.GetProperties()["initialStatus"].Enum[3], "pending_without_pass", "Definitions.Base.Properties[].Enum[3]");
            
            AreEqual(obj.Definitions.Base.GetProperties()["initialStatus"].MaxLength, null, "Definitions.Base.Properties[].MaxLength");
            AreEqual(obj.Definitions.Base.GetProperties()["initialStatus"].MinLength, null, "Definitions.Base.Properties[].MinLength");
            
            AreEqual(obj.Definitions.Base.GetProperties()["initialStatus"].Permissions, Empty<ISchemaDefinitionPermission>(), "Definitions.Base.Properties[].Permissions");
            AreEqual(obj.Definitions.Base.GetProperties()["initialStatus"].Master.Type, "PROFILE_MASTER","Definitions.Base.Properties[].Master.Type");
            
            AreEqual(obj.Definitions.Base.Required[0], "userName", "Definitions.Custom.Required[0]");
            AreEqual(obj.Definitions.Base.Required[1], "firstName", "Definitions.Base.Required[1]");
            AreEqual(obj.Definitions.Base.Required[2], "lastName", "Definitions.Base.Required[2]");
            AreEqual(obj.Definitions.Base.Required[3], "email", "Definitions.Base.Required[3]");
            AreEqual(obj.Definitions.Base.Required[4], "initialStatus", "Definitions.Base.Required[4]");
            
            
        }
        
        
        
        
        #endregion
        
        #region Settings
        
        [Test]
        public void CanDeserialiseBrowserPluginSettingsTest()
        {
            //GIVEN A valid response
            //WHEN The request is deserialised into its type
            
            var obj = GetFromOktaResponse<BrowserPluginSettings>("Settings/GetBrowserPluginSettings.json");
            
            //THEN All fields are present and populated

            AreEqual(obj.AdminManaged, true, nameof(obj.AdminManaged));
            AreEqual(obj.EnabledGroup, "enabledGroupId", nameof(obj.EnabledGroup));
            AreEqual(obj.PreventBrowserPasswordSave, true, nameof(obj.PreventBrowserPasswordSave));
            AreEqual(obj.PreventBrowserOktaPasswordSave, true, nameof(obj.PreventBrowserOktaPasswordSave));
            AreEqual(obj.AntiPhishingEnabled, true, nameof(obj.AntiPhishingEnabled));
            AreEqual(obj.AntiPhishingWhiteListedUrls, null, nameof(obj.AntiPhishingWhiteListedUrls));
            AreEqual(obj.WarningState, null, nameof(obj.WarningState));
        }
        
        
        [Test]
        public void CanDeserialiseCustomDomainCertificateSettingsTest()
        {
            //GIVEN A valid response
            //WHEN The request is deserialised into its type
            
            var obj = GetFromOktaResponse<CustomDomainCertificateSettings>("Settings/GetCustomDomainCertificateSettings.json");
            
            //THEN All fields are present and populated

            AreEqual(obj.CustomDomain, "examplecustomdomain", nameof(obj.CustomDomain));
            AreEqual(obj.Fingerprint, "examplefingerprint", nameof(obj.Fingerprint));
            AreEqual(obj.Subject, "examplesubject", nameof(obj.Subject));
            AreEqual(obj.ExpirationTime, DateTimeOffset.Parse("2019-04-03T08:58:56.000"), nameof(obj.ExpirationTime));
            
        }
        
        [Test]
        public void CanDeserialiseCustomDomainSettingsTest()
        {
            //GIVEN A valid response
            //WHEN The request is deserialised into its type
            
            var obj = GetFromOktaResponse<CustomDomainSettings>("Settings/GetCustomDomainSettings.json");
            
            //THEN All fields are present and populated

            AreEqual(obj.CustomDomain, "ExampleCustomDomain", nameof(obj.CustomDomain));
            AreEqual(obj.TxtRecord, "exampleTxtRecord", nameof(obj.TxtRecord));
            AreEqual(obj.TxtSubdomainRecord, "exampletxtSubdomainRecord", nameof(obj.TxtSubdomainRecord));
            AreEqual(obj.ValidationStatus, "exampleValidationStatus", nameof(obj.ValidationStatus));
            AreEqual(obj.OktaSubdomain, "exampleOkta", nameof(obj.OktaSubdomain));
            AreEqual(obj.Cname, "exampleCname", nameof(obj.Cname));
        }
        
        
        [Test]
        public void CanDeserialiseDefaultApplicationSettingsTest()
        {
            //GIVEN A valid response
            //WHEN The request is deserialised into its type
            
            var obj = GetFromOktaResponse<DefaultApplicationSettings>("Settings/GetDefaultApplicationSettings.json");
            
            //THEN All fields are present and populated

            AreEqual(obj.DefaultApplicationSpecified, true, nameof(obj.DefaultApplicationSpecified));
            AreEqual(obj.DefaultApplicationURI, "https://default.application.url", nameof(obj.DefaultApplicationURI));
        }
        
        [Test]
        public void CanDeserialiseInterstitialSettingsTest()
        {
            //GIVEN A valid response
            //WHEN The request is deserialised into its type
            
            var obj = GetFromOktaResponse<InterstitialPageSettings>("Settings/GetInterstitialSettings.json");
            
            //THEN All fields are present and populated

            AreEqual(obj.OktaInterstitialEnabled, true, nameof(obj.OktaInterstitialEnabled));
        }
        
        [Test]
        public void CanDeserialiseLocalSettingsTest()
        {
            //GIVEN A valid response
            //WHEN The request is deserialised into its type
            
            var obj = GetFromOktaResponse<LocaleSettings>("Settings/GetLocaleSettings.json");
            
            //THEN All fields are present and populated

            AreEqual(obj.LocaleString, "en", nameof(obj.LocaleString));
            AreEqual(obj.LocaleSetByUser, false, nameof(obj.LocaleSetByUser));
            AreEqual(obj.GetAvailableLocaleStrings()["de"], "Deutsch", nameof(obj.AvailableLocaleStrings));
        }
        
        [Test]
        public void CanDeserialiseSignOutSettingsTest()
        {
            //GIVEN A valid response
            //WHEN The request is deserialised into its type
            
            var obj = GetFromOktaResponse<SignOutSettings>("Settings/GetSignOutSettings.json");
            
            //THEN All fields are present and populated

            AreEqual(obj.SignOutPage, "DEFAULT", nameof(obj.SignOutPage));
            AreEqual(obj.SignOutPageUrl, "https://default.signout.url", nameof(obj.SignOutPageUrl));
        }
        
        
        [Test]
        public void CanDeserialiseSignInSettingsTest()
        {
            //GIVEN A valid response
            //WHEN The request is deserialised into its type
            
            var obj = GetFromOktaResponse<SignInPageSettings>("Settings/GetSignInSettings.json");
            
            //THEN All fields are present and populated

            AreEqual(obj.SigninLabel, "ExampleSignInLabel", nameof(obj.SigninLabel));
            AreEqual(obj.UsernameLabel, "ExampleUsernameLabel", nameof(obj.UsernameLabel));
            AreEqual(obj.UsernameInlineLabel, "ExampleUsernameInlineLabel", nameof(obj.UsernameInlineLabel));
            AreEqual(obj.PasswordLabel, "ExamplePasswordLabel", nameof(obj.PasswordLabel));
            AreEqual(obj.PasswordInlineLabel, "ExamplePasswordInlineLabel", nameof(obj.PasswordInlineLabel));
            AreEqual(obj.ForgottenPasswordLabel, "ExamplePasswordLabel", nameof(obj.ForgottenPasswordLabel));
            AreEqual(obj.ForgottenPasswordHref, "https://forgotten.password.href", nameof(obj.ForgottenPasswordHref));
            AreEqual(obj.UnlockAccountLabel, "ExampleUnlockAccountLabel", nameof(obj.UnlockAccountLabel));
            AreEqual(obj.UnlockAccountHref, "ExampleAccountHref", nameof(obj.UnlockAccountHref));
            AreEqual(obj.OktaHelpLabel, "ExampleOktaHelpLabel", nameof(obj.OktaHelpLabel));
            AreEqual(obj.OktaHelpHref, "https://example.oktahelphref", nameof(obj.OktaHelpHref));
            AreEqual(obj.CustomLinkOneText, "ExampleCustomLink1Text", nameof(obj.CustomLinkOneText));
            AreEqual(obj.CustomLinkOneHref, "https://custom.link.one", nameof(obj.CustomLinkOneHref));
            AreEqual(obj.CustomLinkTwoText, "ExampleCustomLink2Text", nameof(obj.CustomLinkTwoText));
            AreEqual(obj.CustomLinkTwoHref, "https://custom.link.two", nameof(obj.CustomLinkTwoHref));
            AreEqual(obj.FooterHelpTitle, "ExampleFooterHelpTitle", nameof(obj.FooterHelpTitle));
            AreEqual(obj.RecoveryFlowPlaceholder, "ExampleRecoveryFlowPlaceHolder", nameof(obj.RecoveryFlowPlaceholder));
            
            AreEqual(obj.DefaultOrgLoginPageSettings.Locale, "en", "DefaultOrgLoginPageSettings.Locale");
            AreEqual(obj.DefaultOrgLoginPageSettings.DefaultForgottenPasswordHrefDisplay, "/reset-password", "DefaultOrgLoginPageSettings.DefaultForgottenPasswordHrefDisplay");
            AreEqual(obj.DefaultOrgLoginPageSettings.DefaultUnlockAccountHrefDisplay, "/user/unlock/request", "DefaultOrgLoginPageSettings.DefaultUnlockAccountHrefDisplay");
            AreEqual(obj.DefaultOrgLoginPageSettings.DefaultOktaHelpHrefDisplay, "/help/login", "DefaultOrgLoginPageSettings.DefaultOktaHelpHrefDisplay");
            AreEqual(obj.DefaultOrgLoginPageSettings.SigninLabel, "Sign In", "DefaultOrgLoginPageSettings.SigninLabel");
            AreEqual(obj.DefaultOrgLoginPageSettings.UsernameLabel, "Username", "DefaultOrgLoginPageSettings.UsernameLabel");
            AreEqual(obj.DefaultOrgLoginPageSettings.UsernameInlineLabel, "ExampleUsernameInlineLabel", "DefaultOrgLoginPageSettings.UsernameInlineLabel");
            AreEqual(obj.DefaultOrgLoginPageSettings.PasswordLabel, "Password", "DefaultOrgLoginPageSettings.PasswordLabel");
            AreEqual(obj.DefaultOrgLoginPageSettings.PasswordInlineLabel, "ExamplePasswordInlineLabel", "DefaultOrgLoginPageSettings.PasswordInlineLabel");
            AreEqual(obj.DefaultOrgLoginPageSettings.UnlockAccountLabel, "Unlock account?", "DefaultOrgLoginPageSettings.UnlockAccountLabel");
            AreEqual(obj.DefaultOrgLoginPageSettings.UnlockAccountHref, "https://unlock.account.href", "DefaultOrgLoginPageSettings.UnlockAccountHref");
            AreEqual(obj.DefaultOrgLoginPageSettings.ForgottenPasswordLabel, "Forgot password?", "DefaultOrgLoginPageSettings.ForgottenPasswordLabel");
            AreEqual(obj.DefaultOrgLoginPageSettings.ForgottenPasswordHref, "https://forgotten.password.href", "DefaultOrgLoginPageSettings.ForgottenPasswordHref");
            AreEqual(obj.DefaultOrgLoginPageSettings.OktaHelpLabel, "Help", "DefaultOrgLoginPageSettings.OktaHelpLabel");
            AreEqual(obj.DefaultOrgLoginPageSettings.OktaHelpHref, "https://okta.help.href", "DefaultOrgLoginPageSettings.OktaHelpHref");
            AreEqual(obj.DefaultOrgLoginPageSettings.CustomLinkOneText, "CustomLinkText1", "DefaultOrgLoginPageSettings.CustomLinkOneText");
            AreEqual(obj.DefaultOrgLoginPageSettings.CustomLinkOneHref, "CustomLinkText2", "DefaultOrgLoginPageSettings.CustomLinkOneHref");
            AreEqual(obj.DefaultOrgLoginPageSettings.CustomLinkTwoText, "CustomLinkText3", "DefaultOrgLoginPageSettings.CustomLinkTwoText");
            AreEqual(obj.DefaultOrgLoginPageSettings.CustomLinkTwoHref, "CustomLinkText4", "DefaultOrgLoginPageSettings.CustomLinkTwoHref");
            AreEqual(obj.DefaultOrgLoginPageSettings.FooterHelpTitle, "Need help signing in?", "DefaultOrgLoginPageSettings.FooterHelpTitle");
            AreEqual(obj.DefaultOrgLoginPageSettings.RecoveryFlowPlaceholder, "Email or Username", "DefaultOrgLoginPageSettings.RecoveryFlowPlaceholder");
        }
        
        
        
        #endregion

        #region Org2Org Applications

        [Test]
        public void CanDeserialiseOrg2OrgApplicationTest()
        {
            //GIVEN A valid response
            //WHEN The request is deserialised into its type
            
            var obj = GetFromOktaResponse<Org2OrgApplication>("Applications/GetOrg2OrgApplication.json");
            
            //THEN All fields are present and populated

            AreEqual(obj.Id, "uniqueorg2orgappid", nameof(obj.Id));
            AreEqual(obj.Name, "okta_org2org", nameof(obj.Name));
            AreEqual(obj.Label, "Example Org2Org App to testtargetorg", nameof(obj.Label));
            AreEqual(obj.Status, "ACTIVE", nameof(obj.Status));
            AreEqual(obj.LastUpdated, DateTimeOffset.Parse("2019-02-17T09:50:25.000"), nameof(obj.LastUpdated));
            AreEqual(obj.Created, DateTimeOffset.Parse("2017-10-17T16:47:22.000"), nameof(obj.Created));
            
            AreEqual(obj.SignOnMode, ApplicationSignOnMode.Saml2, nameof(obj.SignOnMode));
                        
            AreEqual(obj.Accessibility.SelfService, false, "Accessibility.SelfService");
            AreEqual(obj.Accessibility.ErrorRedirectUrl, "example://errorredirecturl", "Accessibility.ErrorRedirectUrl");
            AreEqual(obj.Accessibility.LoginRedirectUrl, "example://loginRedirectUrl", "Accessibility.LoginRedirectUrl");
            AreEqual(obj.Visibility.AutoSubmitToolbar, false, "Visibility.AutoSubmitToolbar");
            AreEqual(obj.Visibility.Hide.IOs, true, "Visibility.Hide.IOs");
            AreEqual(obj.Visibility.Hide.Web, true, "Visibility.Hide.Web");
            AreEqual(obj.Visibility.AppLinks.Login, true, "Visibility.AppLinks.Login");
            AreEqual(obj.Features[0], "PUSH_NEW_USERS", "Features[0]");
            AreEqual(obj.Features[1], "PUSH_USER_DEACTIVATION", "Features");
            AreEqual(obj.Features[2], "GROUP_PUSH", "Features");
            AreEqual(obj.Features[3], "REACTIVATE_USERS", "Features");
            AreEqual(obj.Features[4], "IMPORT_USER_SCHEMA", "Features");
            AreEqual(obj.Features[5], "IMPORT_NEW_USERS", "Features");
            AreEqual(obj.Features[6], "PUSH_PROFILE_UPDATES", "Features");
            AreEqual(obj.Credentials.UserNameTemplate.Template,  "user.getInternalProperty(\"id\") + \"@testorganisation.okta.com\"", "Credentials.UserNameTemplate.Template");
            AreEqual(obj.Credentials.UserNameTemplate.Type, "BUILT_IN", "Credentials.UserNameTemplate.Type");
            AreEqual(obj.Credentials.Signing.Kid, "UNiqueKidForApplication", "Credentials.Signing.Kid");
            AreEqual(obj.Settings.App.AcsUrl, "https://testtargetorg.okta.com/sso/saml2/uniquetargetsaml2id", "Settings.App.AcsUrl");
            AreEqual(obj.Settings.App.AudRestriction, "https://www.okta.com/saml2/service-provider/uniqueoktaserviceproviderid", "Settings.App.AudRestriction");
            AreEqual(obj.Settings.App.BaseUrl, "https://testtargetorg.okta.com", "Settings.App.BaseUrl");
            AreEqual(obj.Settings.Notifications.Vpn.Network.Connection, "DISABLED", "Settings.Notifications.Vpn.Network.Connection");
            AreEqual(obj.Settings.Notifications.Vpn.Message, "Test message", "Settings.Notifications.Vpn.Message");
            AreEqual(obj.Settings.Notifications.Vpn.HelpUrl, "example://helpurl", "Settings.Notifications.Vpn.HelpUrl");
            AreEqual(obj.Settings.SignOn.DefaultRelayState, "https://testtargetorg.okta.com/home/bookmark/targetbookmarkappid/1234", "Settings.SignOn.DefaultRelayState");
            AreEqual(obj.Settings.SignOn.SsoAcsUrlOverride, "ExampleSSOAcsUrlOverride", "Settings.SignOn.SsoAcsUrlOverride");
            AreEqual(obj.Settings.SignOn.AudienceOverride, "ExampleAudienceOverride", "Settings.SignOn.AudienceOverride");
            AreEqual(obj.Settings.SignOn.RecipientOverride, "ExampleRecipientOverride", "Settings.SignOn.RecipientOverride");
            AreEqual(obj.Settings.SignOn.DestinationOverride, "ExampleDestinationOverride", "Settings.SignOn.DestinationOverride");
            
            AreEqual(obj.Links.MetaData.Href, "https://testorganisation.okta.com/api/v1/apps/uniqueorg2orgappid/sso/saml/metadata", "Links.MetaData.Href");
            AreEqual(obj.Links.MetaData.Type, "application/xml", "Links.MetaData.Type");
            
            AreEqual(obj.Links.AppLinks[0].Name, "login", "Links.AppLinks[0].Name");
            AreEqual(obj.Links.AppLinks[0].Href, "https://testorganisation.okta.com/home/okta_org2org/uniqueorg2orgappid/12345", "Links.AppLinks[0].Href");
            AreEqual(obj.Links.AppLinks[0].Type, "text/html", "Links.AppLinks[0].Type");
            
        }

        [Test]
        public void CanDeserialiseTheSaml2MetaDataTest()
        {   
            var dd = new XmlDocument()
            {
                PreserveWhitespace = true,
                XmlResolver = null
            };

            var entityDescriptor =
                Saml2MessageParser.ParseEntityDescriptor(
                    File.ReadAllText(Path.Combine("Responses", "Applications/GetSAML2MetaData.xml")));
            
            
            Assert.That(entityDescriptor.HttpPostSsoLocation, Is.EqualTo("https://exampleorganisation.okta.com/app/okta_org2org/org2orgappid/sso/saml"), "Incorrect sso post path");
            Assert.That(entityDescriptor.HttpRedirectSsoLocation, Is.EqualTo("https://exampleorganisation.okta.com/app/okta_org2org/org2orgappid/sso/saml"), "Incorrect sso redirect path");
                
            Assert.That(entityDescriptor.EntityId, Is.EqualTo("http://www.okta.com/org2orgappid"), "Incorrect entity id");
            Assert.That(entityDescriptor.X509Certificate, Is.EqualTo("Certificate content goes here"), "Incorrectly parse out cert");
            
        }
        
        
        #endregion


        #region Identity Providers

        [Test]
        public void CanDeserialiseCredentialKeysTest()
        {
            //GIVEN A valid response
            //WHEN The request is deserialised into its type
            
            var objCollection = GetFromOktaArrayResponse<IdentityProviderCredentialKey>("IdentityProviders/ListCredentialsKeys.json");
            var obj = objCollection.Single();
            //THEN All fields are present and populated

            AreEqual(obj.Kty, "RSA", nameof(obj.Kty));
            AreEqual(obj.Created, DateTimeOffset.Parse("2018-10-08T15:29:58.000"), nameof(obj.Created));
            AreEqual(obj.LastUpdated, DateTimeOffset.Parse("2018-10-08T15:29:58.000"), nameof(obj.LastUpdated));
            AreEqual(obj.ExpiresAt, DateTimeOffset.Parse("2028-09-13T15:35:27.000"), nameof(obj.ExpiresAt));
            AreEqual(obj.X5C.Single(), "ExampleX5CValue", nameof(obj.X5C));
            AreEqual(obj.Kid, "ExampleKid", nameof(obj.Kid));
            AreEqual(obj.Use, "sig", nameof(obj.Use));
            AreEqual(obj.E, "ExampleE", nameof(obj.E));
            AreEqual(obj.N, "ExampleN", nameof(obj.N));
            AreEqual(obj.X5tS256Hash, "ExampleS256Hash", nameof(obj.X5tS256Hash));
            
            
            
        }
        
        [Test]
        public void CanDeserialiseIdentityProvidersTest()
        {
            //GIVEN A valid response
            //WHEN The request is deserialised into its type
            
            var objCollection = GetFromOktaArrayResponse<IdentityProvider>("IdentityProviders/ListIdentityProviders.json");
            var obj = objCollection.Single();
            //THEN All fields are present and populated

            AreEqual(obj.Id, "uniqueidpidentifier", nameof(obj.Id));
            AreEqual(obj.Type, "SAML2", nameof(obj.Type));
            AreEqual(obj.Name, "Example other Okta Tenant", nameof(obj.Name));
            AreEqual(obj.Status, "ACTIVE", nameof(obj.Status));
            AreEqual(obj.Created, DateTimeOffset.Parse("2017-11-01T14:36:20.000"), nameof(obj.Created));
            AreEqual(obj.LastUpdated, DateTimeOffset.Parse("2019-01-17T01:02:30.000"), nameof(obj.LastUpdated));
            AreEqual(obj.Protocol.Type, "SAML2", "Protocol.Type");
            
            AreEqual(obj.Protocol.Endpoints.Sso.Url, "https://exampleremoteorganisation.okta.com/app/okta_org2org/remoteorganisationssosamlid/sso/saml", "Protocol.Endpoints.Sso.Url");
            AreEqual(obj.Protocol.Endpoints.Sso.Binding, "HTTP-POST", "Protocol.Endpoints.Sso.Binding");
            AreEqual(obj.Protocol.Endpoints.Sso.Destination, "https://exampleremoteorganisation.okta.com/app/okta_org2org/remoteorganisationssosamlid/sso/saml", "Protocol.Endpoints.Sso.Destination");
            AreEqual(obj.Protocol.Endpoints.Acs.Type, "INSTANCE", "Protocol.Endpoints.Acs.Type");
            AreEqual(obj.Protocol.Endpoints.Acs.Binding, "HTTP-POST", "Protocol.Endpoints.Acs.Binding");

            AreEqual(obj.Protocol.Algorithms.Request.Signature.Algorithm, "SHA-256", "Protocol.Algorithms.Request.Signature.Algorithm");
            AreEqual(obj.Protocol.Algorithms.Request.Signature.Scope, "REQUEST", "Protocol.Algorithms.Request.Signature.Scope");
            AreEqual(obj.Protocol.Algorithms.Response.Signature.Algorithm, "SHA-256", "Protocol.Algorithms.Response.Signature.Algorithm");
            AreEqual(obj.Protocol.Algorithms.Response.Signature.Scope, "ANY", "Protocol.Algorithms.Response.Signature.Scope");
            
            AreEqual(obj.Protocol.Settings.NameFormat, "urn:oasis:names:tc:SAML:1.1:nameid-format:unspecified", "Protocol.Settings.NameFormat");
            AreEqual(obj.Protocol.Credentials.Trust.Issuer, "http://www.okta.com/credentialstrustissueroktaid", "Protocol.Credentials.Trust.Issuer");
            AreEqual(obj.Protocol.Credentials.Trust.Audience, "https://www.okta.com/saml2/service-provider/oktasaml2serviceproviderid", "Protocol.Credentials.Trust.Audience");
            AreEqual(obj.Protocol.Credentials.Trust.Kid, "examplecredentialkidid", "Protocol.Credentials.Trust.Kid");
            AreEqual(obj.Protocol.Credentials.Trust.Revocation, "example revocation value", "Protocol.Credentials.Trust.Revocation");
            AreEqual(obj.Protocol.Credentials.Trust.RevocationCacheLifetime, 0, "Protocol.Credentials.Trust.RevocationCacheLifetime");
            AreEqual(obj.Protocol.Credentials.Signing.Kid, "examplekid", "Protocol.Credentials.Signing.Kid");
            
            AreEqual(obj.Policy.Provisioning.Action, "AUTO", "Policy.Provisioning.Action");
            AreEqual(obj.Policy.Provisioning.ProfileMaster, true, "Policy.Provisioning.ProfileMaster");
            AreEqual(obj.Policy.Provisioning.Groups.Action, "ASSIGN", "Policy.Provisioning.Groups.Action");
            AreEqual(obj.Policy.Provisioning.Groups.Assignments[0], "exampleassignmentgroupid", "Policy.Provisioning.Groups.Assignments");
            AreEqual(obj.Policy.Provisioning.Conditions.Deprovisioned.Action, "NONE", "Policy.Provisioning.Conditions.Deprovisioned.Action");
            AreEqual(obj.Policy.Provisioning.Conditions.Suspended.Action, "NONE", "Policy.Provisioning.Conditions.Suspended.Action");
            AreEqual(obj.Policy.AccountLink.Filter, "example account link filter", "Policy.AccountLink.Filter");
            AreEqual(obj.Policy.AccountLink.Action, "AUTO", "Policy.AccountLink.Action");
            AreEqual(obj.Policy.Subject.UserNameTemplate.Template, "idpuser.subjectNameId", "Policy.Subject.UserNameTemplate.Template");
            AreEqual(obj.Policy.Subject.Filter, "example filter", "Policy.Subject.Filter");
            AreEqual(obj.Policy.Subject.MatchType, "USERNAME", "Policy.Subject.MatchType");
            AreEqual(obj.Policy.Subject.MatchAttribute, "example match attribute", "Policy.Subject.MatchAttribute");
            AreEqual(obj.Policy.MaxClockSkew, 120000, "Policy.MaxClockSkew");
        }

        #endregion
        
        #region Test helper methods
        private static void AreEqual(object value, object expected, string fieldName)
        {
            Assert.That(value, Is.EqualTo(expected), $"Unexpected value in field {fieldName}");
        }
        
        private static T GetFromOktaResponse<T>(string file)
        {
            return new ResourceFactory(null,null) 
                .CreateNew<T>(new DefaultSerializer().Deserialize(File.ReadAllText(Path.Combine("Responses", file))));
        }
        
        private static IList<T> GetFromOktaArrayResponse<T>(string file)
        {
            var resFactory = new ResourceFactory(null,null); 
            return new DefaultSerializer().DeserializeArray(File.ReadAllText(Path.Combine("Responses", file)))
                        .Select(dictionary => resFactory.CreateNew<T>(dictionary))
                        .ToList(); 
        }
        #endregion
    }
}