using System;
using System.Threading;
using System.Threading.Tasks;
using Finbourne.Extensions.Okta.Sdk.Resources.AuthorisationServers;
using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Clients
{
    public class AuthorisationServersClient : IAuthorisationServersClient
    {
        private readonly IOktaClient _client;

        /// <summary>
        /// Create an client for interacting with Okta authorisation servers
        /// </summary>
        /// <param name="client">A sufficiently provisioned and authorised Okta SDK client</param>
        public AuthorisationServersClient(IOktaClient client)
        {
            _client = client;
        }

        public async Task<IAuthorisationServer> CreateAuthorisationServer(CreateAuthorisationServerOptions options,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestUrl = _client.Configuration.BuildUrl("/api/v1/authorizationServers");
            return await _client.PostAsync<AuthorisationServer>(requestUrl.AbsoluteUri, options, cancellationToken);
        }

        public async Task<IAuthorisationServer> UpdateAuthorisationServer(string authorisationServerId,
            UpdateAuthorisationServerOptions options,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestUrl = _client.Configuration.BuildUrl($"/api/v1/authorizationServers/{authorisationServerId}");
            return await _client.PutAsync<AuthorisationServer>(requestUrl.AbsoluteUri, options, cancellationToken);
        }
        
        public ICollectionClient<AuthorisationServer> ListAuthorisationServers()
        {
            var requestUrl = _client.Configuration.BuildUrl($"/api/v1/authorizationServers");
            return _client.GetCollection<AuthorisationServer>(requestUrl.AbsoluteUri);
        }
        
        public async Task<IAuthorisationServer> GetAuthorisationServer(string id, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestUrl = _client.Configuration.BuildUrl($"/api/v1/authorizationServers/{id}");
            return await _client.GetAsync<AuthorisationServer>(requestUrl.AbsoluteUri, cancellationToken);
        }

        public ICollectionClient<AuthorisationServerPolicy> ListAuthorisationServerPolicies(string id)
        {
            var requestUrl = _client.Configuration.BuildUrl($"/api/v1/authorizationServers/{id}/policies");
            return _client.GetCollection<AuthorisationServerPolicy>(requestUrl.AbsoluteUri);
        }

        public ICollectionClient<AuthorisationServerPolicyRule> ListAuthorisationServerPolicyRules(
            string authorisationServerId, string policyId)
        {
            var requestUrl = _client.Configuration.BuildUrl($"/api/v1/authorizationServers/{authorisationServerId}/policies/{policyId}/rules");
            return _client.GetCollection<AuthorisationServerPolicyRule>(requestUrl.AbsoluteUri);
        }
        
        public ICollectionClient<AuthorisationServerClaim> ListAuthorisationServerClaims(string id, bool includeSystemClaims = false)
        {
            var requestUrl = _client.Configuration.BuildUrl($"/api/v1/authorizationServers/{id}/claims" + (includeSystemClaims ? string.Empty : "?includeClaims=custom,sub"));
            return _client.GetCollection<AuthorisationServerClaim>(requestUrl.AbsoluteUri);
        }
        
        public async Task<IAuthorisationServerClaim> GetAuthorisationServerClaim(string authorisationServerId, string id,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestUrl = _client.Configuration.BuildUrl($"/api/v1/authorizationServers/{authorisationServerId}/claims/{id}");
            return await _client.GetAsync<AuthorisationServerClaim>(requestUrl.AbsoluteUri, cancellationToken);
        }
        
        public async Task<IAuthorisationServerClaim> CreateAuthorisationServerClaim(string authorisationServerId, CreateAuthorisationServerClaimOptions options,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestUrl = _client.Configuration.BuildUrl($"/api/v1/authorizationServers/{authorisationServerId}/claims");
            return await _client.PostAsync<AuthorisationServerClaim>(requestUrl.AbsoluteUri, options, cancellationToken);
        }

        public async Task<IAuthorisationServerClaim> UpdateAuthorisationServerClaim(string authorisationServerId, string id, UpdateAuthorisationServerClaimOptions options,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestUrl = _client.Configuration.BuildUrl($"/api/v1/authorizationServers/{authorisationServerId}/claims/{id}");
            return await _client.PutAsync<AuthorisationServerClaim>(requestUrl.AbsoluteUri, options, cancellationToken);
        }
        
        public async Task<IAuthorisationServerPolicy> CreateAuthorisationServerPolicy(string authorisationServerId, CreateAuthorisationServerPolicyOptions options,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                var requestUrl = _client.Configuration.BuildUrl($"/api/v1/authorizationServers/{authorisationServerId}/policies");
                return await _client.PostAsync<AuthorisationServerPolicy>(requestUrl.AbsoluteUri, options, cancellationToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<IAuthorisationServerPolicy> UpdateAuthorisationServerPolicy(string authorisationServerId, string id, UpdateAuthorisationServerPolicyOptions options,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestUrl = _client.Configuration.BuildUrl($"/api/v1/authorizationServers/{authorisationServerId}/policies/{id}");
            return await _client.PutAsync<AuthorisationServerPolicy>(requestUrl.AbsoluteUri, options, cancellationToken);
        }
        
        public async Task<IAuthorisationServerPolicyRule> CreateAuthorisationServerPolicyRule(string authorisationServerId, string policyId, CreateAuthorisationServerPolicyRuleOptions options,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestUrl = _client.Configuration.BuildUrl($"/api/v1/authorizationServers/{authorisationServerId}/policies/{policyId}/rules");
            return await _client.PostAsync<AuthorisationServerPolicyRule>(requestUrl.AbsoluteUri, options, cancellationToken);
        }

        public async Task<IAuthorisationServerPolicyRule> UpdateAuthorisationServerPolicyRule(string authorisationServerId, string policyId, string id, UpdateAuthorisationServerPolicyRuleOptions options,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestUrl = _client.Configuration.BuildUrl($"/api/v1/authorizationServers/{authorisationServerId}/policies/{policyId}/rules/{id}");
            return await _client.PutAsync<AuthorisationServerPolicyRule>(requestUrl.AbsoluteUri, options, cancellationToken);
        }
        
    }
}