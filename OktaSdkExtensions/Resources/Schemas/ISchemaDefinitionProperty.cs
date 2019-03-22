using System.Collections.Generic;
using Okta.Sdk;

namespace Finbourne.Extensions.Okta.Sdk.Resources.Schemas
{
    public interface ISchemaDefinitionProperty : IResource
    {
        string Title { get; set; }
        string Description { get; set; }
        string Type { get; set; }
        bool? Required { get; set; }
        string Mutability { get; set; }
        int? MinLength { get; set; }
        int? MaxLength { get; set; }
        string Scope { get; set; }
        IList<string> Enum { get; set; }
        IList<ISchemaDefinitionPermission> Permissions { get; set; }
        ISchemaDefinitionMaster Master { get; set; }
    }
}