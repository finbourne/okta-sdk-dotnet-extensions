using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Schemas
{
    public interface ISchemaDefinitionPermission : IResource
    {
        string Principal { get; set; }
        string Action { get; set; }
    }
}