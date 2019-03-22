using System.Threading;
using System.Threading.Tasks;
using Finbourne.Extensions.Okta.Sdk.Resources.Schemas;

namespace Finbourne.Extensions.Okta.Sdk.Clients
{
    /// <summary>A client that works with Okta Authorisation Schema resources.</summary>
    public interface ISchemasClient 
    {
        /// <summary>
        /// Get the default user schema for the organisation
        /// </summary>
        Task<ISchema> GetUserSchema(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Get the user schema for a specific application
        /// </summary>
        /// <returns></returns>
        Task<IApplicationSchema> GetApplicationUserSchema(string applicationId,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Create a user property in the default user profile
        /// </summary>
        Task<ISchema> CreateUserProperty(string propertyName, ISchemaDefinitionProperty options,
            CancellationToken cancellationToken = default(CancellationToken));
        
        /// <summary>
        /// Update a user property in the default user profile
        /// </summary>
        Task<ISchema> UpdateUserProperty(string propertyName, ISchemaDefinitionProperty options,
            CancellationToken cancellationToken = default(CancellationToken));
        
        Task<ISchema> DeleteUserProperty(string propertyName,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}