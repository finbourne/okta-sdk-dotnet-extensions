using System.Threading;
using System.Threading.Tasks;
using Finbourne.Extensions.Okta.Sdk.Resources.AuthorisationServers;
using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Clients
{
    /// <summary>A client that works with Okta Authorisation Server resources.</summary>
    public interface IAuthorisationServersClient 
    {
        Task<IAuthorisationServer> CreateAuthorisationServer(CreateAuthorisationServerOptions options, CancellationToken cancellationToken = default(CancellationToken));
        Task<IAuthorisationServer> GetAuthorisationServer(string id, CancellationToken cancellationToken = default(CancellationToken));
        
        ICollectionClient<AuthorisationServerPolicy> ListAuthorisationServerPolicies(string id);
        
        ICollectionClient<AuthorisationServerPolicyRule> ListAuthorisationServerPolicyRules(
            string authorisationServerId, 
            string policyId);

        Task<IAuthorisationServer> UpdateAuthorisationServer(string authorisationServerId,
            UpdateAuthorisationServerOptions options,
            CancellationToken cancellationToken = default(CancellationToken));

        ICollectionClient<AuthorisationServer> ListAuthorisationServers();


        ICollectionClient<AuthorisationServerClaim> ListAuthorisationServerClaims(string id, bool includeSystemClaims = false);
        
        Task<IAuthorisationServerClaim> GetAuthorisationServerClaim(string authorisationServerId, string id,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<IAuthorisationServerClaim> CreateAuthorisationServerClaim(string authorisationServerId,
            CreateAuthorisationServerClaimOptions options,
            CancellationToken cancellationToken = default(CancellationToken));
        
        Task<IAuthorisationServerClaim> UpdateAuthorisationServerClaim(string authorisationServerId,
            string id, UpdateAuthorisationServerClaimOptions options,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<IAuthorisationServerPolicy> CreateAuthorisationServerPolicy(string authorisationServerId,
            CreateAuthorisationServerPolicyOptions options,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<IAuthorisationServerPolicy> UpdateAuthorisationServerPolicy(string authorisationServerId, string id,
            UpdateAuthorisationServerPolicyOptions options,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<IAuthorisationServerPolicyRule> CreateAuthorisationServerPolicyRule(string authorisationServerId,
            string policyId, CreateAuthorisationServerPolicyRuleOptions options,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<IAuthorisationServerPolicyRule> UpdateAuthorisationServerPolicyRule(
            string authorisationServerId, string policyId, string id,
            UpdateAuthorisationServerPolicyRuleOptions options,
            CancellationToken cancellationToken = default(CancellationToken));



    }
}