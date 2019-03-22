using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Schemas
{
    public interface ISchemaDefinitionMaster : IResource
    {
        string Type { get; set; }
    }
}