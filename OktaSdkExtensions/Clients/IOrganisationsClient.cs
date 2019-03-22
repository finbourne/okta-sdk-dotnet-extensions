using System.Threading;
using System.Threading.Tasks;
using Finbourne.Extensions.Okta.Sdk.Resources.Organisations;

namespace Finbourne.Extensions.Okta.Sdk.Clients
{
    /// <summary>A client that works with Okta Organisation resources.</summary>
    public interface IOrganisationsClient
    {
        /// <summary>
        /// Create an Okta Organisation
        /// </summary>
        /// <remarks>
        /// This is a protected feature and requires a special level of authorisation token
        /// </remarks>
        /// <param name="options">The specifications for the new organisation</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The <see cref="T:Finbourne.Extensions.Okta.Sdk.Resources.ICreatedOrganisation" /> response</returns>
        Task<ICreatedOrganisation> CreateOrganisation(CreateOrganisationOptions options, CancellationToken cancellationToken = default(CancellationToken));
        
        /// <summary>
        /// Get the details about a specific organisation (must be name of current organisation/subdomain)
        /// </summary>
        /// <param name="orgName">The name of the organisation to get (must be the subdomain of current org)</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The <see cref="T:Finbourne.Extensions.Okta.Sdk.Resources.IOrganisation" /> response</returns>
        Task<IOrganisation> GetOrganisation(string orgName, CancellationToken cancellationToken = default(CancellationToken));


        /// <summary>
        /// Get the contact information related to the specified organisation
        /// </summary>
        /// <param name="orgName">The name of the organisation from which to retrieve the contacts</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The <see cref="T:Finbourne.Extensions.Okta.Sdk.Resources.IOrganisationContacts" /> response</returns>
        Task<IOrganisationContacts> GetOrganisationContacts(string orgName, CancellationToken cancellationToken = default(CancellationToken));
        
        /// <summary>
        /// Get the policy information related to the specified organisation
        /// </summary>
        /// <param name="orgName">The name of the organisation from which to retrieve the policy</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The <see cref="T:Finbourne.Extensions.Okta.Sdk.Resources.IOrganisationPolicy" /> response</returns>
        Task<IOrganisationPolicy> GetOrganisationPolicy(string orgName, CancellationToken cancellationToken = default(CancellationToken));
    }
}