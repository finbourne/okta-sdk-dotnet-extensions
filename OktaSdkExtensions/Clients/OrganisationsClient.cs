using System.Threading;
using System.Threading.Tasks;
using Finbourne.Extensions.Okta.Sdk.Resources.Organisations;
using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Clients
{
    public class OrganisationsClient : IOrganisationsClient
    {
        private readonly IOktaClient _client;

        /// <summary>
        /// Create an client for interacting with Okta organisations. If creating, the supplied client bust be suitable authorised.
        /// </summary>
        /// <param name="client">A sufficiently provisioned and authorised Okta SDK client</param>
        public OrganisationsClient(IOktaClient client)
        {
            _client = client;
        }
        
        /// <inheritdoc />
        public async Task<ICreatedOrganisation> CreateOrganisation(
            CreateOrganisationOptions options, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestUrl = _client.Configuration.BuildUrl("/api/v1/orgs");
            return await _client.PostAsync<CreatedOrganisation>(requestUrl.AbsoluteUri, options, cancellationToken);            
        }

        /// <inheritdoc />
        public async Task<IOrganisation> GetOrganisation(
            string orgName, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestUrl = _client.Configuration.BuildUrl($"/api/v1/orgs/{orgName}");
            return await _client.GetAsync<Organisation>(requestUrl.AbsoluteUri, cancellationToken);
        }
        
        /// <inheritdoc />
        public async Task<IOrganisationContacts> GetOrganisationContacts(
            string orgName, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestUrl = _client.Configuration.BuildUrl($"/api/v1/orgs/{orgName}/contacts");
            return await _client.GetAsync<OrganisationContacts>(requestUrl.AbsoluteUri, cancellationToken);
        }
        
        /// <inheritdoc />
        public async Task<IOrganisationPolicy> GetOrganisationPolicy(
            string orgName, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestUrl = _client.Configuration.BuildUrl($"/api/v1/orgs/{orgName}/policy");
            return await _client.GetAsync<OrganisationPolicy>(requestUrl.AbsoluteUri, cancellationToken);
        }
    }
}