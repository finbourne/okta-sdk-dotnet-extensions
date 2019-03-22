using System.Collections.Generic;
using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Schemas
{
    public interface ISchemaDefinition : IResource
    {
        string Id { get; set; }
        string Type { get; set; }
        
        IDictionary<string, ISchemaDefinitionProperty> GetProperties();
        Resource Properties { get; set; }
        IList<string> Required { get; set; }
        
        
    }
}