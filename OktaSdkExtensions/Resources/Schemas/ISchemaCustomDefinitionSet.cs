using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Schemas
{
    public interface ISchemaCustomDefinitionSet : IResource
    {
        ISchemaDefinition Custom { get; set; }
    }
}