using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Finbourne.Extensions.Okta.Sdk.Resources.Schemas;
using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Clients
{
    public class SchemasClient : ISchemasClient
    {
        private readonly IOktaClient _client;

        /// <summary>
        /// Create an client for interacting with Okta authorisation servers
        /// </summary>
        /// <param name="client">A sufficiently provisioned and authorised Okta SDK client</param>
        public SchemasClient(IOktaClient client)
        {
            _client = client;
        }
        
        public async Task<ISchema> GetUserSchema(CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestUrl = _client.Configuration.BuildUrl($"/api/v1/meta/schemas/user/default");
            return await _client.GetAsync<Schema>(requestUrl.AbsoluteUri, cancellationToken);
        }
        
        public async Task<ISchema> CreateUserProperty(string propertyName, ISchemaDefinitionProperty options, CancellationToken cancellationToken = default(CancellationToken))
        {
            var createOptions = new CreateUserPropertyOptions
            {
                Definitions = new SchemaCustomDefinitionSet()
                {
                    Custom = new SchemaDefinition()
                    {
                        Id = "#custom",
                        Type = "object",
                        Properties = new Resource()
                        {
                            [propertyName] = options
                        },
                        Required = new List<string>()
                    }
                }
            };
            
            var requestUrl = _client.Configuration.BuildUrl("/api/v1/meta/schemas/user/default");
            return await _client.PostAsync<Schema>(requestUrl.AbsoluteUri, createOptions, cancellationToken);
        }

        
        public async Task<ISchema> UpdateUserProperty(string propertyName, ISchemaDefinitionProperty options, CancellationToken cancellationToken = default(CancellationToken))
        {
            var createOptions = new UpdateUserPropertyOptions
            {
                Definitions = new SchemaCustomDefinitionSet()
                {
                    Custom = new SchemaDefinition()
                    {
                        Id = "#custom",
                        Type = "object",
                        Properties = new Resource()
                        {
                            [propertyName] = options
                        },
                        Required = new List<string>()
                    }
                }
            };
            
            var requestUrl = _client.Configuration.BuildUrl("/api/v1/meta/schemas/user/default");
            return await _client.PostAsync<Schema>(requestUrl.AbsoluteUri, createOptions, cancellationToken);
        }
        
        public async Task<ISchema> DeleteUserProperty(string propertyName, CancellationToken cancellationToken = default(CancellationToken))
        {
            // As per https://developer.okta.com/docs/api/resources/schemas#remove-property-from-user-profile-schema 
            // deletion is done by essentially patch updating the specific property
            // "Properties must be explicitly set to null to be removed from schema, otherwise the POST will be interpreted as a partial update."
            
            var deleteOptions = new UpdateUserPropertyOptions
            {
                Definitions = new SchemaCustomDefinitionSet()
                {
                    Custom = new SchemaDefinition()
                    {
                        Id = "#custom",
                        Type = "object",
                        Properties = new Resource()
                        {
                            [propertyName] = null
                        },
                        Required = new List<string>()
                    }
                }
            };
            
            var requestUrl = _client.Configuration.BuildUrl("/api/v1/meta/schemas/user/default");
            return await _client.PostAsync<Schema>(requestUrl.AbsoluteUri, deleteOptions, cancellationToken);
        }
        
        
        public async Task<IApplicationSchema> GetApplicationUserSchema(string applicationId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var requestUrl = _client.Configuration.BuildUrl($"/api/v1/meta/schemas/apps/${applicationId}/default");
            return await _client.GetAsync<ApplicationSchema>(requestUrl.AbsoluteUri, cancellationToken);
        }
    }
}